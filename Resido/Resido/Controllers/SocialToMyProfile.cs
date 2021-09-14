using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resido.Data;
using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Resido.Controllers
{
    public class SocialToMyProfile : Controller
    {
        private readonly AppDbContext _context;
        public SocialToMyProfile(AppDbContext context)
        {
            _context = context;
        }



        public IActionResult Index(MyProfileForAgents model)
        {
            model.Id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;

            List<SocialToMyProf> socialToMyProfs = _context.SocialToMyProfs.Include(c => c.MyProfileForAgents).Include(u => u.SocialsMyProfile).ToList();

            return View(socialToMyProfs);
        }



        //Create
        public IActionResult Create()                                  //get
        {
            int? agentId = null;
            try
            {
                agentId = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {

            }
            if (agentId == null)
            {
                return NotFound();
            }
            List<SocialsMyProfile> socials = _context.SocialsMyProfiles.Include(e => e.SocialToMyProfs).ToList();
            socials.Insert(0, new SocialsMyProfile() { Id = 0, Icon = "Select" });
            ViewBag.Socials = socials;
            return View();
        }


        [HttpPost]
        public IActionResult Create(SocialToMyProf model)               //post
        {
            if (ModelState.IsValid)
            {
                if (model.SocialsMyProfileId == 0)
                {
                    ModelState.AddModelError("SocialsMyProfileId", "Required");
                    List<SocialsMyProfile> socials = _context.SocialsMyProfiles.Include(e => e.SocialToMyProfs).ToList();
                    socials.Insert(0, new SocialsMyProfile() { Id = 0, Icon = "Select" });
                    ViewBag.Socials = socials;

                    return View();
                }
                if (model.Link == null)
                {
                    ModelState.AddModelError("Link", "Required");
                    List<SocialsMyProfile> socials = _context.SocialsMyProfiles.Include(e => e.SocialToMyProfs).ToList();
                    socials.Insert(0, new SocialsMyProfile() { Id = 0, Icon = "Select" });
                    ViewBag.Socials = socials;

                    return View();
                }

                model.MyProfileForAgentsId = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
                _context.SocialToMyProfs.Add(model);
                _context.SaveChanges();
                return RedirectToAction("updatemyprofile", "account");
            }
            return View(model);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SocialToMyProf social = _context.SocialToMyProfs.FirstOrDefault(i => i.Id == id);
            if (social == null)
            {
                return NotFound();
            }

            _context.SocialToMyProfs.Remove(social);
            _context.SaveChanges();
            return RedirectToAction("updatemyprofile", "account");

        }


    }
}
