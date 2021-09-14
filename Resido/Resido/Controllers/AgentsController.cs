using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Resido.Data;
using Resido.Models;
using Resido.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Controllers
{
    public class AgentsController : Controller
    {
        private readonly AppDbContext _context;
        public AgentsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Agents()
        {
            List<MyProfileForAgents> agents = _context.MyProfileForAgents.Include(r=>r.RegistrationOptionSelect)
                                                                         .Include(s=>s.SocialToMyProfs).ThenInclude(st=>st.SocialsMyProfile)
                                                                         .Include(p=>p.Properties).Include(pt=>pt.Reviews).Where(b=>b.RegistrationOptionSelect.OptionSelect=="Agent").ToList();

            ViewBag.Page = "agents";
            return View(agents);
        }



        public IActionResult SingleAgent(int id)
        {
            VmAgents agent = new VmAgents
            {
                SingleAgent = _context.MyProfileForAgents.Include(p => p.Properties)
                                                         .Include(s => s.SocialToMyProfs).ThenInclude(sl => sl.SocialsMyProfile).Include(pt => pt.Reviews)
                                                         .FirstOrDefault(a => a.Id == id),

                Properties_rent = _context.Properties.Include(p=>p.PropertyStatus)
                                                .Include(b=>b.BathroomCount)
                                                .Include(bed=>bed.BedroomsCount)
                                                .Include(c=>c.CityOfProperty).Where(b=>b.MyProfileForAgentsId==id&&b.PropertyStatus.Name == "For Rent").ToList(),

                Properties_sale = _context.Properties.Include(p => p.PropertyStatus)
                                                .Include(b => b.BathroomCount)
                                                .Include(bed => bed.BedroomsCount)
                                                .Include(c => c.CityOfProperty).Where(b => b.MyProfileForAgentsId == id && b.PropertyStatus.Name == "For Sale").ToList(),

               Properties_monthrent = _context.Properties.Include(p => p.PropertyStatus)
                                                .Include(b => b.BathroomCount)
                                                .Include(bed => bed.BedroomsCount)
                                                .Include(c => c.CityOfProperty).Where(b => b.MyProfileForAgentsId == id && b.PropertyStatus.Name == "For Monthly rent").ToList(),

                LatestProps = _context.Properties.Include(c => c.CityOfProperty).Where((b => b.MyProfileForAgentsId == id)).Take(3).ToList(),

            };
            return View(agent);
        }




        public IActionResult Agencies()
        {
            List<MyProfileForAgents> agencies = _context.MyProfileForAgents.Include(r => r.RegistrationOptionSelect).Include(pt => pt.Reviews)
                                                                           .Include(s => s.SocialToMyProfs).ThenInclude(st => st.SocialsMyProfile)
                                                                           .Include(p => p.Properties).Where(b => b.RegistrationOptionSelect.OptionSelect == "Agency").ToList();

            ViewBag.Page = "agencies";
            return View(agencies);
        }


        public IActionResult SingleAgency(int id)
        {
            VmAgents agent = new VmAgents
            {
                SingleAgent = _context.MyProfileForAgents.Include(p => p.Properties).Include(pt => pt.Reviews)
                                             .Include(s => s.SocialToMyProfs).ThenInclude(sl => sl.SocialsMyProfile)
                                             .FirstOrDefault(a => a.Id == id),

                Properties_rent = _context.Properties.Include(p => p.PropertyStatus)
                                                .Include(b => b.BathroomCount)
                                                .Include(bed => bed.BedroomsCount)
                                                .Include(c => c.CityOfProperty).Where(b => b.MyProfileForAgentsId == id && b.PropertyStatus.Name == "For Rent").ToList(),

                Properties_sale = _context.Properties.Include(p => p.PropertyStatus)
                                                .Include(b => b.BathroomCount)
                                                .Include(bed => bed.BedroomsCount)
                                                .Include(c => c.CityOfProperty).Where(b => b.MyProfileForAgentsId == id && b.PropertyStatus.Name == "For Sale").ToList(),

                Properties_monthrent = _context.Properties.Include(p => p.PropertyStatus)
                                                .Include(b => b.BathroomCount)
                                                .Include(bed => bed.BedroomsCount)
                                                .Include(c => c.CityOfProperty).Where(b => b.MyProfileForAgentsId == id && b.PropertyStatus.Name == "For Monthly rent").ToList(),

                LatestProps = _context.Properties.Include(c => c.CityOfProperty).Where((b => b.MyProfileForAgentsId == id)).Take(3).ToList(),

            };
            return View(agent);
        }




    }
}
