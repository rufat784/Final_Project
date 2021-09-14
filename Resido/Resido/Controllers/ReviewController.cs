using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Resido.Data;
using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;
        public ReviewController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }





        [HttpPost]
        public IActionResult AddReview(string text, int propertyId)
        {
            string valid = (HttpContext.Session.GetString("ValidAgentCustomer"));
            MyProfileForAgents agents = null;
            if (valid != null)
            {
                agents = JsonConvert.DeserializeObject<MyProfileForAgents>(valid);
                Review review = new Review()
                {
                    Content = text,
                    PropertyId = propertyId,
                    MyProfileForAgentsId = agents.Id,
                    AddedDate = DateTime.Now

                };
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction("details", "properties", new { id = propertyId });
            }
            else
            {
                return RedirectToAction("login", "account", new { isCommentPrdId = propertyId });
            }
        }
    }
}
