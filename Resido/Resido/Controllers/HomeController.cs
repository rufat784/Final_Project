using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Resido.Data;
using Resido.Models;
using Resido.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
            propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
            ViewBag.Type = propertyTypes;

            List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
            bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
            ViewBag.Bedroom = bedroomsCounts;

            List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
            propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
            ViewBag.Status = propertyStatuses;

            VmHome model = new VmHome()
            {
                HowItWorks = _context.HowItWorks.ToList(),
                Properties = _context.Properties.Include(s=>s.PropertyStatus).Include(b=>b.BedroomsCount).Include(ba=>ba.BathroomCount).Include(c=>c.CityOfProperty).Take(6).ToList(),
                CityOfProperties=_context.CityOfProperties.Include(p=>p.Properties).ToList(),
                Reviews=_context.Reviews.Include(m=>m.MyProfileForAgents).Where(t=>t.MyProfileForAgents.RegistrationOptionSelectId==3).ToList()
            };

            ViewBag.Page = "home";
            return View(model);
        }



        [HttpPost]
        public IActionResult Subscribe(string message, string email, string phone, int agentId)
        {

            Subscribed subscribe = new Subscribed()
            {
                Message = message,
                Phone = phone,
                MyProfileForAgentsId = agentId,
                Email = email,
                AddedDate = DateTime.Now

            };
            _context.Subscribeds.Add(subscribe);
            _context.SaveChanges();
            return RedirectToAction("agents", "agents");
        }


        public IActionResult Messages()
        {
            int? id = null;
            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {


            }
            List<Subscribed> messages = _context.Subscribeds.Include(t => t.MyProfileForAgents).Where((b => b.MyProfileForAgentsId == id)).ToList();
            return View(messages);
        }


        public IActionResult DeleteMessage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Subscribed messages = _context.Subscribeds.FirstOrDefault(i => i.Id == id);
            if (messages == null)
            {
                return NotFound();
            }
            _context.Subscribeds.Remove(messages);
            _context.SaveChanges();
            return RedirectToAction("messages", "home");

        }


        public IActionResult MyProperties()
        {
            int? id = null;
            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {


            }
            List<Property> properties = _context.Properties.Include(r=>r.RoomsCount)
                                                            .Include(g=>g.GarageCount).Include(a=>a.BuildingAge)
                                                            .Include(t=>t.PropertyType).Include(s=>s.PropertyStatus)
                                                            .Include(c=>c.CityOfProperty).Include(bed=>bed.BedroomsCount)
                                                            .Include(b=>b.BathroomCount).Include(t => t.MyProfileForAgents)
                                                            .Where((b => b.MyProfileForAgentsId == id)).ToList();
            return View(properties);
        }

    }
}
