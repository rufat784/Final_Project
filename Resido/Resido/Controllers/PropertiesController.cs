using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Resido.Data;
using Resido.Filters;
using Resido.Models;
using Resido.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly AppDbContext _context;
        public PropertiesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(VmAllProperties filter, int? locationId, string searchData, int page=1)
        {
            ViewBag.Filter = new Dictionary<string, string>
            {
                {"cityId",filter.cityId+""},
                {"typeId",filter.typeId+""},
                {"statusId",filter.statusId+""},
                {"bedId",filter.bedId+""},
                {"bathId",filter.bathId+""},
                {"ageId",filter.ageId+""},
                {"garageId",filter.garageId+""},
                {"searchData",searchData+"" },
                {"minPrice",filter.minPrice+"" },
                {"maxPrice",filter.maxPrice+"" },

            };

            List<Property> propsList = _context.Properties.Include(i => i.PropertyImages).Include(b => b.BedroomsCount).Include(ba => ba.BathroomCount)
                                                           .Include(c => c.CityOfProperty).Include(st => st.PropertyStatus)
                                                           .Where(pr =>(filter.cityId != null ? pr.CityOfPropertyId == filter.cityId : true) &&
                                                                      (filter.typeId != 0 ? pr.PropertyTypeId == filter.typeId : true) &&
                                                                      (filter.statusId != 0 ? pr.PropertyStatusId == filter.statusId : true) &&
                                                                      (filter.bedId != 0 ? pr.BedroomsCountId == filter.bedId : true) &&
                                                                      (filter.bathId != null ? pr.BathroomCountId == filter.bathId : true) &&
                                                                      (filter.ageId != null ? pr.BuildingAgeId == filter.ageId : true)&&
                                                                      //(locationId != null ? pr.CityOfPropertyId == locationId : true) &&
                                                                      (filter.garageId != null ? pr.GarageCountId == filter.garageId : true)&&
                                                                      (filter.maxPrice != null ? pr.Price <= filter.maxPrice : true) &&
                                                                      (filter.minPrice != null ? pr.Price >= filter.minPrice : true)&&
                                                                      (searchData != null ? pr.CityOfProperty.Name.Contains(searchData) : true))                                                          
                                                           .ToList();

            decimal pageItemsCount = 4;
            decimal a = propsList.Count / pageItemsCount;
            ViewBag.PageCount = Convert.ToInt32(Math.Ceiling(a));
            ViewBag.ActivePage = page;


            List<Property> properties= propsList.OrderBy(i => i.Id)
            .Skip((page - 1) * (int)pageItemsCount).Take((int)pageItemsCount)
            .ToList();



            VmAllProperties model = new VmAllProperties()
            {
                Properties = properties,
                Filter=filter,
                CityOfProperties=_context.CityOfProperties.ToList(),
                PropertyTypes=_context.PropertyTypes.ToList(),
                PropertyStatuses=_context.PropertyStatuses.ToList(),
                BedroomsCounts=_context.BedroomsCounts.ToList(),
                BathroomCounts = _context.BathroomCounts.ToList(),
                BuildingAges=_context.BuildingAges.ToList(),
                Garages = _context.GarageCounts.ToList(),
            };

            ViewBag.Page = "properties";
            return View(model);
        }




        public IActionResult Details(int id)
        {
            VmAllProperties model = new VmAllProperties()
            {
                Property = _context.Properties.Include(i=>i.PropertyImages).Include(r=>r.RoomsCount).Include(u=>u.MyProfileForAgents).Include(s=>s.PropertyStatus)
                                              .Include(b => b.BedroomsCount).Include(ba => ba.BathroomCount).Include(rvp=>rvp.Reviews).ThenInclude(i=>i.MyProfileForAgents).Include(age=>age.BuildingAge)
                                              .Include(g=>g.GarageCount).Include(o=>o.OtherFeatures).Include(food=>food.FoodsArounds).Include(pt=>pt.PropertyType)
                                              .Include(c => c.CityOfProperty).Include(sc=>sc.SchoolsArounds).Include(am=>am.AmenetiesProperties).FirstOrDefault(b => b.Id == id),
                
                PropertyImages=_context.PropertyImages.Include(pr=>pr.Property).Where(p=>p.PropertyId==id).ToList(),
                Featured=_context.Properties.Include(c => c.CityOfProperty).Include(s=>s.PropertyStatus).OrderByDescending(d=>d.AddedDate).Take(6).ToList()
               
            };
            return View(model);
        }



        [Auth]
        //Create
        public IActionResult SubmitProperty()                                  
        {

            MyProfileForAgents agents = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer"));
            if (agents.RegistrationOptionSelectId==3)
            {
                return RedirectToAction("index", "home");
            }

            List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
            propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
            ViewBag.Status = propertyStatuses;

            List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
            propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
            ViewBag.Type = propertyTypes;

            List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
            bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
            ViewBag.Bedroom = bedroomsCounts;

            List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
            bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
            ViewBag.Bathroom = bathroomCounts;

            List<CityOfProperty> city = _context.CityOfProperties.ToList();
            city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
            ViewBag.City = city;

            List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
            buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
            ViewBag.Age = buildingAges;

            List<GarageCount> garageCounts = _context.GarageCounts.ToList();
            garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
            ViewBag.Garage = garageCounts;

            List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
            roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
            ViewBag.Rooms = roomsCounts;
            return View();
        }


        [HttpPost]
        public IActionResult SubmitProperty(Property model)                      
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.PropertyStatusId==0)
                    {
                        ModelState.AddModelError("PropertyStatusId", "Please add status");
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View();
                    }
                    if (model.PropertyTypeId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        ModelState.AddModelError("PropertyTypeId", "Please add property type");
                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View();
                    }
                    if (model.BedroomsCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        ModelState.AddModelError("BedroomsCountId", "Please bedroom count");
                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View();
                    }
                    if (model.BathroomCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        ModelState.AddModelError("BathroomCountId", "Please bathroom count");
                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View();
                    }
                    if (model.CityOfPropertyId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        ModelState.AddModelError("CityOfPropertyId", "Please add city");
                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View();
                    }
                    if (model.BuildingAgeId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        ModelState.AddModelError("BuildingAgeId", "Please set building age");
                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View();
                    }
                    if (model.GarageCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        ModelState.AddModelError("GarageCountId", "Please add garage count");
                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View();
                    }
                    if (model.RoomsCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        ModelState.AddModelError("RoomsCountId", "Please add room count");
                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View();
                    }

                    if (model.PropImages.Length>0)
                    {
                        foreach (var item in model.PropImages)
                        {
                            if (!(item.ContentType == "image/png" || item.ContentType == "image/jpeg"))
                            {
                                List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                                propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                                ViewBag.Status = propertyStatuses;

                                List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                                propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                                ViewBag.Type = propertyTypes;

                                List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                                bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                                ViewBag.Bedroom = bedroomsCounts;

                                List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                                bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                                ViewBag.Bathroom = bathroomCounts;

                                List<CityOfProperty> city = _context.CityOfProperties.ToList();
                                city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                                ViewBag.City = city;

                                List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                                buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                                ViewBag.Age = buildingAges;

                                List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                                garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                                ViewBag.Garage = garageCounts;

                                List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                                roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                                ViewBag.Rooms = roomsCounts;

                                ModelState.AddModelError("PropImages", "Only .png, .jpeg formats");
                                return View();
                            }
                        }
                    }

                    if (model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg")
                    {
                        if (model.ImageFile.Length <= 2097152)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine("wwwroot/Uploads/Images", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            model.MainImage = fileName;
                            model.MyProfileForAgentsId = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
                            model.AddedDate = DateTime.Now;
                            _context.Properties.Add(model);
                            _context.SaveChanges();

                            if (model.PropImages.Length>0)
                            {
                                foreach (var item in model.PropImages)
                                {
                                    PropertyImages propertyImages = new PropertyImages();

                                    string fileNameImages = Guid.NewGuid() + "-" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss") + "-" + item.FileName;
                                    string filePathImages = Path.Combine("wwwroot/Uploads/Images", fileNameImages);
                                    using (var stream = new FileStream(filePathImages, FileMode.Create))
                                    {
                                        item.CopyTo(stream);
                                    }

                                    propertyImages.Image = fileNameImages;
                                    propertyImages.PropertyId = model.Id;
                                    _context.PropertyImages.Add(propertyImages);
                                }
                            }

                            _context.SaveChanges();

                            return RedirectToAction("index", "home");
                        }
                        else
                        {
                            List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                            propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                            ViewBag.Status = propertyStatuses;

                            List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                            propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                            ViewBag.Type = propertyTypes;

                            List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                            bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                            ViewBag.Bedroom = bedroomsCounts;

                            List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                            bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                            ViewBag.Bathroom = bathroomCounts;

                            List<CityOfProperty> city = _context.CityOfProperties.ToList();
                            city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                            ViewBag.City = city;

                            List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                            buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                            ViewBag.Age = buildingAges;

                            List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                            garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                            ViewBag.Garage = garageCounts;

                            List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                            roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                            ViewBag.Rooms = roomsCounts;

                            ModelState.AddModelError("ImageFile", "Can upload max 2MB");
                        }
                    }
                    else
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;

                        ModelState.AddModelError("ImageFile", "Only .png, .jpeg formats");
                    }

                }
                else
                {
                    List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                    propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                    ViewBag.Status = propertyStatuses;

                    List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                    propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                    ViewBag.Type = propertyTypes;

                    List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                    bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                    ViewBag.Bedroom = bedroomsCounts;

                    List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                    bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                    ViewBag.Bathroom = bathroomCounts;

                    List<CityOfProperty> city = _context.CityOfProperties.ToList();
                    city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                    ViewBag.City = city;

                    List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                    buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                    ViewBag.Age = buildingAges;

                    List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                    garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                    ViewBag.Garage = garageCounts;

                    List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                    roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                    ViewBag.Rooms = roomsCounts;

                    ModelState.AddModelError("ImageFile", "Please add photo");
                }
            }
            return View(model);
        }





        //Update
        public IActionResult UpdateProperty(int? id)                                  
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
            Property model = _context.Properties.Include(i=>i.PropertyImages).Where(b=>b.MyProfileForAgentsId==agentId).FirstOrDefault(i => i.Id == id); //prop which have to be updated
            if (model == null)
            {
                return NotFound();
            }
            List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
            propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
            ViewBag.Status = propertyStatuses;

            List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
            propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
            ViewBag.Type = propertyTypes;

            List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
            bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
            ViewBag.Bedroom = bedroomsCounts;

            List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
            bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
            ViewBag.Bathroom = bathroomCounts;

            List<CityOfProperty> city = _context.CityOfProperties.ToList();
            city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
            ViewBag.City = city;

            List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
            buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
            ViewBag.Age = buildingAges;

            List<GarageCount> garageCounts = _context.GarageCounts.ToList();
            garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
            ViewBag.Garage = garageCounts;

            List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
            roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
            ViewBag.Rooms = roomsCounts;
            return View(model);
        }



        [HttpPost]
        public IActionResult UpdateProperty(Property model)                     
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.PropertyStatusId == 0)
                    {
                        ModelState.AddModelError("PropertyStatusId", "Please add status");
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.PropertyTypeId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        ModelState.AddModelError("PropertyTypeId", "Please add property type");
                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.BedroomsCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        ModelState.AddModelError("BedroomsCountId", "Please bedroom count");
                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.BathroomCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        ModelState.AddModelError("BathroomCountId", "Please bathroom count");
                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.CityOfPropertyId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        ModelState.AddModelError("CityOfPropertyId", "Please add city");
                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.BuildingAgeId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        ModelState.AddModelError("BuildingAgeId", "Please set building age");
                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.GarageCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        ModelState.AddModelError("GarageCountId", "Please add garage count");
                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.RoomsCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        ModelState.AddModelError("RoomsCountId", "Please add room count");
                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }

                    if (model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg")
                    {
                        if (model.ImageFile.Length <= 2097152)
                        {
                            if (model.MainImage != null)
                            {
                                string oldFilePath = Path.Combine("wwwroot/Uploads/Images", model.MainImage); //if image !=null
                                if (System.IO.File.Exists(oldFilePath))
                                {
                                    System.IO.File.Delete(oldFilePath);
                                }
                            }
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine("wwwroot/Uploads/Images", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            model.MainImage = fileName;

                            _context.Entry(model).State = EntityState.Modified;
                            _context.Entry(model).Property(u => u.MyProfileForAgentsId).IsModified = false; //we prevent user to be updated
                            _context.Entry(model).Property(u => u.AddedDate).IsModified = false; //we prevent date to be updated
                            _context.SaveChanges();


                            return RedirectToAction("myproperties", "home");
                        }
                        else
                        {
                            List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                            propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                            ViewBag.Status = propertyStatuses;

                            List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                            propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                            ViewBag.Type = propertyTypes;

                            List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                            bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                            ViewBag.Bedroom = bedroomsCounts;

                            List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                            bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                            ViewBag.Bathroom = bathroomCounts;

                            List<CityOfProperty> city = _context.CityOfProperties.ToList();
                            city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                            ViewBag.City = city;

                            List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                            buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                            ViewBag.Age = buildingAges;

                            List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                            garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                            ViewBag.Garage = garageCounts;

                            List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                            roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                            ViewBag.Rooms = roomsCounts;

                            ModelState.AddModelError("ImageFile", "Can upload max 2MB");
                        }
                    }
                    else
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;

                        ModelState.AddModelError("ImageFile", "Only .png, .jpeg types");
                    }

                }
                else //if no photo
                {
                    if (model.PropertyStatusId == 0)
                    {
                        ModelState.AddModelError("PropertyStatusId", "Please add status");
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.PropertyTypeId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        ModelState.AddModelError("PropertyTypeId", "Please add property type");
                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.BedroomsCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        ModelState.AddModelError("BedroomsCountId", "Please bedroom count");
                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.BathroomCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        ModelState.AddModelError("BathroomCountId", "Please bathroom count");
                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.CityOfPropertyId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        ModelState.AddModelError("CityOfPropertyId", "Please add city");
                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.BuildingAgeId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        ModelState.AddModelError("BuildingAgeId", "Please set building age");
                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.GarageCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        ModelState.AddModelError("GarageCountId", "Please add garage count");
                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }
                    if (model.RoomsCountId == 0)
                    {
                        List<PropertyStatus> propertyStatuses = _context.PropertyStatuses.ToList();
                        propertyStatuses.Insert(0, new PropertyStatus() { Id = 0, Name = "Select" });
                        ViewBag.Status = propertyStatuses;

                        List<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                        propertyTypes.Insert(0, new PropertyType() { Id = 0, Name = "Select" });
                        ViewBag.Type = propertyTypes;

                        List<BedroomsCount> bedroomsCounts = _context.BedroomsCounts.ToList();
                        bedroomsCounts.Insert(0, new BedroomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bedroom = bedroomsCounts;

                        List<BathroomCount> bathroomCounts = _context.BathroomCounts.ToList();
                        bathroomCounts.Insert(0, new BathroomCount() { Id = 0, CountName = "Select" });
                        ViewBag.Bathroom = bathroomCounts;

                        List<CityOfProperty> city = _context.CityOfProperties.ToList();
                        city.Insert(0, new CityOfProperty() { Id = 0, Name = "Select" });
                        ViewBag.City = city;

                        List<BuildingAge> buildingAges = _context.BuildingAges.ToList();
                        buildingAges.Insert(0, new BuildingAge() { Id = 0, Years = "Select" });
                        ViewBag.Age = buildingAges;

                        List<GarageCount> garageCounts = _context.GarageCounts.ToList();
                        garageCounts.Insert(0, new GarageCount() { Id = 0, CountName = "Select" });
                        ViewBag.Garage = garageCounts;

                        ModelState.AddModelError("RoomsCountId", "Please add room count");
                        List<RoomsCount> roomsCounts = _context.RoomsCounts.ToList();
                        roomsCounts.Insert(0, new RoomsCount() { Id = 0, CountName = "Select" });
                        ViewBag.Rooms = roomsCounts;
                        return View(model);
                    }

                    _context.Entry(model).State = EntityState.Modified;
                    _context.Entry(model).Property(u => u.MyProfileForAgentsId).IsModified = false; //we prevent user to be updated
                    _context.Entry(model).Property(u => u.AddedDate).IsModified = false; //we prevent date to be updated
                    _context.SaveChanges();
                    return RedirectToAction("myproperties", "home");
                }
            }
            return View(model);
        }




        //Delete
        public IActionResult DeleteProperty(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Property property = _context.Properties.Include(im=>im.PropertyImages).FirstOrDefault(i => i.Id == id);
            if (property == null)
            {
                return NotFound();
            }

            //Delete main image
            if (property.MainImage != null)
            {
                string oldFilePath = Path.Combine("wwwroot/Uploads/Images", property.MainImage);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

            }

            //Delete images
                foreach (var item in property.PropertyImages)
                {
                    if (item.Image!=null)
                    {
                        string oldFilePath = Path.Combine("wwwroot/Uploads/Images", item.Image);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }
                }
            _context.Properties.Remove(property);
            _context.SaveChanges();
            return RedirectToAction("myproperties", "home");

        }




        //ErrorMessage
        public IActionResult ErrorMessage()
        {
            return View();

        }


        //prop images
        public IActionResult PropertyImages(int? id)
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
            List<PropertyImages> propertyImages = _context.PropertyImages.Include(p=>p.Property).Where(i=>i.PropertyId==id)
                                                                                                .Where(p=>p.Property.MyProfileForAgentsId==agentId).ToList();
            if (propertyImages == null)
            {
                return NotFound();
            }
            return View(propertyImages);
        }




        //Add PropertyImages
        public IActionResult AddPropertyImage()                                  
        {
            int? id = null;
            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }
            List<Property> properties = _context.Properties.Include(pr=>pr.PropertyImages).Where(p=>p.MyProfileForAgentsId==id).ToList();
            properties.Insert(0, new Property() { Id = 0, Name = "Select" });
            ViewBag.Properties = properties;
            return View();
        }



        [HttpPost]
        public IActionResult AddPropertyImage(PropertyImages model)                      
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
                if (model.ImageFile != null)
                {
                    if (model.PropertyId==0)
                    {
                        ModelState.AddModelError("PropertyId", "Required");
                        List<Property> properties = _context.Properties.Include(pr => pr.PropertyImages).Where(p => p.MyProfileForAgentsId == id).ToList();
                        properties.Insert(0, new Property() { Id = 0, Name = "Select" });
                        ViewBag.Properties = properties;
                        return View(model);
                    }
                    if (model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg")
                    {
                        if (model.ImageFile.Length <= 2097152)
                        {

                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine("wwwroot/Uploads/Images", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            model.Image = fileName;
                            _context.PropertyImages.Add(model);
                            _context.SaveChanges();

                            return RedirectToAction("myproperties", "home");
                        }
                        else
                        {
                            List<Property> properties = _context.Properties.Include(pr => pr.PropertyImages).Where(p => p.MyProfileForAgentsId == id).ToList();
                            properties.Insert(0, new Property() { Id = 0, Name = "Select" });
                            ViewBag.Properties = properties;

                            ModelState.AddModelError("ImageFile", "Can upload max 2MB");
                        }
                    }
                    else
                    {
                        List<Property> properties = _context.Properties.Include(pr => pr.PropertyImages).Where(p => p.MyProfileForAgentsId == id).ToList();
                        properties.Insert(0, new Property() { Id = 0, Name = "Select" });
                        ViewBag.Properties = properties;

                        ModelState.AddModelError("ImageFile", "Only .png, .jpeg types");
                    }
                }
                else
                {
                    List<Property> properties = _context.Properties.Include(pr => pr.PropertyImages).Where(p => p.MyProfileForAgentsId == id).ToList();
                    properties.Insert(0, new Property() { Id = 0, Name = "Select" });
                    ViewBag.Properties = properties;

                    ModelState.AddModelError("ImageFile", "Please Add Photo");
                }
            }
            return View(model);
        }




        //Delete Property Image
        public IActionResult DeletePropertyImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PropertyImages property = _context.PropertyImages.FirstOrDefault(i => i.Id == id);
            if (property == null)
            {
                return NotFound();
            }

            //Delete image
            if (property.Image != null)
            {
                string oldFilePath = Path.Combine("wwwroot/Uploads/Images", property.Image);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

            }
            _context.PropertyImages.Remove(property);
            _context.SaveChanges();
            return RedirectToAction("myproperties", "home");

        }










        //Load more
        public JsonResult LoadMore(int propertyId, int page=1)
        {
            if (propertyId==0)
            {
                return Json("ok");
            }
            List<Review> model = _context.Reviews.Where(p=>p.PropertyId==propertyId).ToList();

            return Json(model);
        }

    }
}
