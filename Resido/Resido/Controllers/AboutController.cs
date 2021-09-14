using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resido.Data;
using Resido.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            VmAbout model = new VmAbout()
            {
                Aboutcs = _context.Aboutcs.FirstOrDefault(),
                OurAgents=_context.MyProfileForAgents.Include(s=>s.SocialToMyProfs).ThenInclude(sc=>sc.SocialsMyProfile)
                                                     .Where(reg=>reg.RegistrationOptionSelectId==1 ||reg.RegistrationOptionSelectId==2).ToList(),
                OurMission=_context.OurMissionInAbouts.ToList(),
                OurMissionMainImage=_context.OurMissionMainImages.FirstOrDefault(),

            };

            ViewBag.Page = "about";
            return View(model);

        }
    }
}
