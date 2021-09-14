using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Resido.Data;
using Resido.Filters;
using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crypto = BCrypt.Net.BCrypt;


namespace Resido.Areas.admin.Controllers
{
    [Area("Admin")]

    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }


        [AdminAuth]

        //Create user
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserAdmin model)
        {

            if (ModelState.IsValid)
            {

                UserAdmin user = _context.UserAdmins.FirstOrDefault(c => c.Email == model.Email);
                if (user == null)
                {
                    UserAdmin user1 = new UserAdmin();
                    user1.Name = model.Name;
                    user1.Email = model.Email;
                    user1.Password = Crypto.HashPassword(model.Password);
                    _context.UserAdmins.Add(user1);
                    _context.SaveChanges();
                    return RedirectToAction("index", "home");

                }
                else
                {
                    ModelState.AddModelError("Email", "Email is exists");
                    return View(model);
                }

            }
            return RedirectToAction("login", "account");
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserAdmin model)
        {
            if (ModelState.IsValid)
            {

                UserAdmin user = _context.UserAdmins.FirstOrDefault(c => c.Email == model.Email);
                if (user != null)
                {
                    if (Crypto.Verify(model.Password, user.Password))
                    {
                        string usertObj = JsonConvert.SerializeObject(user);
                        HttpContext.Session.SetString("ValidAdminUser", usertObj);
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Wrong password");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Wrong mail");
                    return View(model);
                }
            }
            return View();
        }



        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("ValidAdminUser");
            return RedirectToAction("index", "home");
        }
    }
}
