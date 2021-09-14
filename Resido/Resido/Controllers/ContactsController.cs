using Microsoft.AspNetCore.Mvc;
using Resido.Data;
using Resido.Models;
using Resido.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Controllers
{
    public class ContactsController : Controller
    {
        private readonly AppDbContext _context;
        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VmContacts model = new VmContacts()
            {
                ContactAdresses= _context.ContactAdresses.ToList(),
                ContactEmails= _context.ContactEmails.ToList(),
                ContactPhones= _context.ContactPhones.ToList()
            };

            ViewBag.Page = "contacts";
            return View(model);
        }


        [HttpPost]
        public IActionResult Index(string message, string email, string name, string subject)
        {

            Contact contact = new Contact()
            {
                Message = message,
                Name = name,
                Email = email,
                Subject=subject
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("index", "home");
        }
    }
}
