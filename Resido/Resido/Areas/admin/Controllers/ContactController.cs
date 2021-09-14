using Microsoft.AspNetCore.Mvc;
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

    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult ContactMessage()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList()
            };

            return View(model);
        }



        public IActionResult ContactPhones()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                ContactPhones= _context.ContactPhones.ToList()
            };
            return View(model);
        }



        //Delete Message
        public IActionResult DeleteContactMessage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Contact contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("contactmessage", "contact");
        }







        //Create Phone Numbs
        public IActionResult CreatePhone()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreatePhone(ContactPhone model)
        {
            VmBase modelbase = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                if (model.Phone != null)
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("contactphones", "contact");
                }
                else
                {
                    ModelState.AddModelError("Phone", "Required");
                }
            }
            return View(modelbase);
        }



        //Delete Phone
        public IActionResult DeletePhone(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ContactPhone contact = _context.ContactPhones.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.ContactPhones.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("contactphones", "contact");
        }
    }
}
