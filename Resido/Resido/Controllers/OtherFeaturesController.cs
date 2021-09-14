using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Resido.Data;
using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Controllers
{
    public class OtherFeaturesController : Controller
    {
        private readonly AppDbContext _context;
        public OtherFeaturesController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            int? id = null;
            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {

            }
 
            List<OtherFeatures> features = _context.OtherFeatures.Include(c => c.Property).Where((b => b.Property.MyProfileForAgentsId == id)).OrderBy(q => q.PropertyId).ToList();
            if (features == null)
            {
                return NotFound();
            }
            return View(features);
        }


        public IActionResult Amenities()
        {
            int? id = null;
            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {

            }

            List<AmenetiesProperty> features = _context.AmenetiesProperties.Include(c => c.Property).Where((b => b.Property.MyProfileForAgentsId == id)).OrderBy(q=>q.PropertyId).ToList();
            if (features == null)
            {
                return NotFound();
            }
            return View(features);
        }



        public IActionResult SchoolsAround()
        {
            int? id = null;
            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            List<SchoolsAround> school = _context.SchoolsArounds.Include(c => c.Property).Where((b => b.Property.MyProfileForAgentsId == id)).OrderBy(q => q.PropertyId).ToList();
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }


        public IActionResult FoodAround()
        {
            int? id = null;
            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            List<FoodsAround> food = _context.FoodsArounds.Include(c => c.Property).Where((b => b.Property.MyProfileForAgentsId == id)).OrderBy(q => q.PropertyId).ToList();
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }




        //Create feature
        public IActionResult Create()                                  
        {
            int? id = null;

            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            List<Property> props = _context.Properties.Where(i=>i.MyProfileForAgentsId==id).ToList();
            props.Insert(0, new Property() { Id = 0, Name = "Select" });
            ViewBag.Props = props;

            return View();
        }



        [HttpPost]
        public IActionResult Create(OtherFeatures model)                      
        {
            int? id = null;

            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            if (ModelState.IsValid)
            {
                if (model.PropertyId == 0)
                {
                    ModelState.AddModelError("PropertyId", "Choose property");
                    List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == id).ToList();
                    props.Insert(0, new Property() { Id = 0, Name = "Select" });
                    ViewBag.Props = props;
                    return View(model);
                }
                _context.OtherFeatures.Add(model);
                _context.SaveChanges();
                return RedirectToAction("index", "otherfeatures");

            }
            else
            {
                ModelState.AddModelError("PropertyId", "Choose property");
                List<Property> props = _context.Properties.Where(i=>i.MyProfileForAgentsId==id).ToList();
                props.Insert(0, new Property() { Id = 0, Name = "Select" });
                ViewBag.Props = props;
                return View(model);
            }
        }



        //Update feature
        public IActionResult Update(int? id)
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
            OtherFeatures features = _context.OtherFeatures.Include(t => t.Property).Where((b => b.Property.MyProfileForAgentsId == agentId)).FirstOrDefault(i => i.Id == id);
            if (features == null)
            {
                return NotFound();
            }
            List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
            props.Insert(0, new Property() { Id = 0, Name = "Select" });
            ViewBag.Props = props;

            return View(features);
        }



        [HttpPost]
        public IActionResult Update(OtherFeatures model)                      
        {
            int? agentId = null;

            try
            {
                agentId = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            if (ModelState.IsValid)
            {
                if (model.PropertyId == 0)
                {
                    ModelState.AddModelError("PropertyId", "Choose property");
                    List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
                    props.Insert(0, new Property() { Id = 0, Name = "Select" });
                    ViewBag.Props = props;
                    return View(model);
                }
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index", "otherfeatures");

            }
            else
            {
                ModelState.AddModelError("PropertyId", "Choose property");
                List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
                props.Insert(0, new Property() { Id = 0, Name = "Select" });
                ViewBag.Props = props;
                return View(model);
            }
        }




        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            OtherFeatures features = _context.OtherFeatures.Find(id);
            if (features == null)
            {
                return NotFound();
            }

            _context.OtherFeatures.Remove(features);
            _context.SaveChanges();
            return RedirectToAction("index", "otherfeatures");

        }






        //Create Amenities
        public IActionResult CreateAmenities()                                  
        {
            int? id = null;

            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == id).ToList();
            props.Insert(0, new Property() { Id = 0, Name = "Select" });
            ViewBag.Props = props;

            return View();
        }



        [HttpPost]
        public IActionResult CreateAmenities(AmenetiesProperty model)                      
        {
            int? id = null;

            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            if (ModelState.IsValid)
            {
                if (model.PropertyId == 0)
                {
                    ModelState.AddModelError("PropertyId", "Choose property");
                    List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == id).ToList();
                    props.Insert(0, new Property() { Id = 0, Name = "Select" });
                    ViewBag.Props = props;
                    return View(model);
                }
                _context.AmenetiesProperties.Add(model);
                _context.SaveChanges();
                return RedirectToAction("index", "otherfeatures");

            }
            else
            {
                ModelState.AddModelError("PropertyId", "Choose property");
                List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == id).ToList();
                props.Insert(0, new Property() { Id = 0, Name = "Select" });
                ViewBag.Props = props;
                return View(model);
            }
        }




        //Update amenities
        public IActionResult UpdateAmenities(int? id)
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
            AmenetiesProperty ameneties = _context.AmenetiesProperties.Include(t => t.Property).Where((b => b.Property.MyProfileForAgentsId == agentId)).FirstOrDefault(i => i.Id == id);
            if (ameneties == null)
            {
                return NotFound();
            }
            List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
            props.Insert(0, new Property() { Id = 0, Name = "Select" });
            ViewBag.Props = props;

            return View(ameneties);
        }



        [HttpPost]
        public IActionResult UpdateAmenities(AmenetiesProperty model)                      
        {
            int? agentId = null;

            try
            {
                agentId = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            if (ModelState.IsValid)
            {
                if (model.PropertyId == 0)
                {
                    ModelState.AddModelError("PropertyId", "Choose property");
                    List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
                    props.Insert(0, new Property() { Id = 0, Name = "Select" });
                    ViewBag.Props = props;
                    return View(model);
                }
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index", "otherfeatures");

            }
            else
            {
                ModelState.AddModelError("PropertyId", "Choose property");
                List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
                props.Insert(0, new Property() { Id = 0, Name = "Select" });
                ViewBag.Props = props;
                return View(model);
            }
        }

        //Delete amenetie
        public IActionResult DeleteAmenities(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AmenetiesProperty ameneties = _context.AmenetiesProperties.Find(id);
            if (ameneties == null)
            {
                return NotFound();
            }

            _context.AmenetiesProperties.Remove(ameneties);
            _context.SaveChanges();
            return RedirectToAction("index", "otherfeatures");

        }







        //Create School
        public IActionResult CreateSchool()
        {
            int? id = null;

            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == id).ToList();
            props.Insert(0, new Property() { Id = 0, Name = "Select" });
            ViewBag.Props = props;

            return View();
        }



        [HttpPost]
        public IActionResult CreateSchool(SchoolsAround model)
        {
            int? id = null;

            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            if (ModelState.IsValid)
            {
                if (model.PropertyId == 0)
                {
                    ModelState.AddModelError("PropertyId", "Choose property");
                    List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == id).ToList();
                    props.Insert(0, new Property() { Id = 0, Name = "Select" });
                    ViewBag.Props = props;
                    return View(model);
                }
                _context.SchoolsArounds.Add(model);
                _context.SaveChanges();
                return RedirectToAction("schoolsaround", "otherfeatures");
            }
            else
            {
                ModelState.AddModelError("PropertyId", "Choose property");
                List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == id).ToList();
                props.Insert(0, new Property() { Id = 0, Name = "Select" });
                ViewBag.Props = props;
                return View(model);
            }

        }



        //Update school
        public IActionResult UpdateSchool(int? id)
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
            SchoolsAround schools = _context.SchoolsArounds.Include(t => t.Property).Where((b => b.Property.MyProfileForAgentsId == agentId)).FirstOrDefault(i => i.Id == id);
            if (schools == null)
            {
                return NotFound();
            }
            List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
            props.Insert(0, new Property() { Id = 0, Name = "Select" });
            ViewBag.Props = props;

            return View(schools);
        }



        [HttpPost]
        public IActionResult UpdateSchool(SchoolsAround model)
        {
            int? agentId = null;

            try
            {
                agentId = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            if (ModelState.IsValid)
            {
                if (model.PropertyId == 0)
                {
                    ModelState.AddModelError("PropertyId", "Choose property");
                    List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
                    props.Insert(0, new Property() { Id = 0, Name = "Select" });
                    ViewBag.Props = props;
                    return View(model);
                }
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("schoolsaround", "otherfeatures");

            }
            else
            {
                ModelState.AddModelError("PropertyId", "Choose property");
                List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
                props.Insert(0, new Property() { Id = 0, Name = "Select" });
                ViewBag.Props = props;
                return View(model);
            }
        }

        //Delete school
        public IActionResult DeleteSchool(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SchoolsAround schools = _context.SchoolsArounds.Find(id);
            if (schools == null)
            {
                return NotFound();
            }

            _context.SchoolsArounds.Remove(schools);
            _context.SaveChanges();
            return RedirectToAction("schoolsaround", "otherfeatures");

        }




        //Create Food
        public IActionResult CreateFood()
        {
            int? id = null;

            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == id).ToList();
            props.Insert(0, new Property() { Id = 0, Name = "Select" });
            ViewBag.Props = props;

            return View();
        }



        [HttpPost]
        public IActionResult CreateFood(FoodsAround model)
        {
            int? id = null;

            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            if (ModelState.IsValid)
            {
                if (model.PropertyId == 0)
                {
                    ModelState.AddModelError("PropertyId", "Choose property");
                    List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == id).ToList();
                    props.Insert(0, new Property() { Id = 0, Name = "Select" });
                    ViewBag.Props = props;
                    return View(model);
                }
                _context.FoodsArounds.Add(model);
                _context.SaveChanges();
                return RedirectToAction("foodaround", "otherfeatures");
            }
            else
            {
                ModelState.AddModelError("PropertyId", "Choose property");
                List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == id).ToList();
                props.Insert(0, new Property() { Id = 0, Name = "Select" });
                ViewBag.Props = props;
                return View(model);
            }

        }


        //Update school
        public IActionResult UpdateFood(int? id)
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
            FoodsAround food = _context.FoodsArounds.Include(t => t.Property).Where((b => b.Property.MyProfileForAgentsId == agentId)).FirstOrDefault(i => i.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
            props.Insert(0, new Property() { Id = 0, Name = "Select" });
            ViewBag.Props = props;
            return View(food);
        }



        [HttpPost]
        public IActionResult UpdateFood(FoodsAround model)
        {
            int? agentId = null;

            try
            {
                agentId = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            if (ModelState.IsValid)
            {
                if (model.PropertyId == 0)
                {
                    ModelState.AddModelError("PropertyId", "Choose property");
                    List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
                    props.Insert(0, new Property() { Id = 0, Name = "Select" });
                    ViewBag.Props = props;
                    return View(model);
                }
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("foodaround", "otherfeatures");

            }
            else
            {
                ModelState.AddModelError("PropertyId", "Choose property");
                List<Property> props = _context.Properties.Where(i => i.MyProfileForAgentsId == agentId).ToList();
                props.Insert(0, new Property() { Id = 0, Name = "Select" });
                ViewBag.Props = props;
                return View(model);
            }
        }


        //Delete food
        public IActionResult DeleteFood(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FoodsAround foods = _context.FoodsArounds.Find(id);
            if (foods == null)
            {
                return NotFound();
            }

            _context.FoodsArounds.Remove(foods);
            _context.SaveChanges();
            return RedirectToAction("foodaround", "otherfeatures");

        }
    }
}

