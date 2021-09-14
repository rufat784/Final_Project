using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resido.Areas.admin.ViewModels;
using Resido.Data;
using Resido.Filters;
using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Areas.admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]

    public class AgentsController : Controller
    {
        private readonly AppDbContext _context;
        public AgentsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Agents()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.Include(a => a.MyProfileForAgents).ToList(),
                MyProfileForAgents=_context.MyProfileForAgents.Where(a=>a.RegistrationOptionSelectId==1).ToList()
            };
            return View(model);
        }


        //Delete Agent
        public IActionResult DeleteAgent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            MyProfileForAgents agent = _context.MyProfileForAgents.FirstOrDefault(i => i.Id == id);
            if (agent == null)
            {
                return NotFound();
            }
            _context.MyProfileForAgents.Remove(agent);
            _context.SaveChanges();
            return RedirectToAction("agents","agents");
        }




        public IActionResult Agencies()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.Include(a => a.MyProfileForAgents).ToList(),
                MyProfileForAgents = _context.MyProfileForAgents.Where(a => a.RegistrationOptionSelectId == 2).ToList()
            };
            return View(model);
        }



        //Delete Agencie
        public IActionResult DeleteAgencie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            MyProfileForAgents agent = _context.MyProfileForAgents.FirstOrDefault(i => i.Id == id);
            if (agent == null)
            {
                return NotFound();
            }
            _context.MyProfileForAgents.Remove(agent);
            _context.SaveChanges();
            return RedirectToAction("agencies", "agents");
        }





        public IActionResult Customers()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.Include(a => a.MyProfileForAgents).ToList(),
                MyProfileForAgents = _context.MyProfileForAgents.Where(a => a.RegistrationOptionSelectId == 3).ToList()
            };
            return View(model);
        }



        //Delete Agencie
        public IActionResult DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            MyProfileForAgents agent = _context.MyProfileForAgents.FirstOrDefault(i => i.Id == id);
            if (agent == null)
            {
                return NotFound();
            }
            _context.MyProfileForAgents.Remove(agent);
            _context.SaveChanges();
            return RedirectToAction("customers", "agents");
        }
    }
}
