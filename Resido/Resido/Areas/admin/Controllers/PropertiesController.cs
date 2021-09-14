using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resido.Areas.admin.ViewModels;
using Resido.Data;
using Resido.Filters;
using Resido.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Areas.admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]

    public class PropertiesController : Controller
    {
        private readonly AppDbContext _context;
        public PropertiesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.Include(a => a.MyProfileForAgents).ToList()
            };
            return View(model);
        }


        public IActionResult PropertyStatus()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.Include(a => a.MyProfileForAgents).ToList(),
                Statuses= _context.PropertyStatuses.ToList()
            };
            return View(model);
        }


        public IActionResult PropertyType()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.Include(a => a.MyProfileForAgents).ToList(),
                Types = _context.PropertyTypes.ToList()
            };
            return View(model);
        }


        public IActionResult PropertyCities()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.Include(a => a.MyProfileForAgents).ToList(),
                City = _context.CityOfProperties.ToList()
            };
            return View(model);
        }


        public IActionResult BathroomCount()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                BathroomCounts= _context.BathroomCounts.ToList()
            };

            return View(model);
        }

        public IActionResult BedroomCount()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                BedroomsCounts = _context.BedroomsCounts.ToList()
            };
            return View(model);
        }



        public IActionResult RoomsCount()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                RoomsCounts = _context.RoomsCounts.ToList()
            };
            return View(model);
        }


        public IActionResult BuildingAge()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                BuildingAges = _context.BuildingAges.ToList()
            };
            return View(model);
        }



        public IActionResult GarageCount()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                GarageCounts = _context.GarageCounts.ToList()
            };
            return View(model);
        }



        //Delete Property
        public IActionResult DeleteProperty(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Property property = _context.Properties.Include(im => im.PropertyImages).FirstOrDefault(i => i.Id == id);
            if (property == null)
            {
                return NotFound();
            }

            //Delete image
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
                if (item.Image != null)
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
            return RedirectToAction("index");

        }





        //Create City
        public IActionResult CreateCity()                                  
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList()
            };

            return View(model);
        }



        [HttpPost]
        public IActionResult CreateCity(CityOfProperty model)                     
        {
            VmBase modelcity = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList()
            };
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
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


                            _context.CityOfProperties.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("propertycities", "properties");
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "Can upload max 2MB");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Only .png, .jpeg types");
                    }
                }
            }
            return View(modelcity);
        }



        //Update City
        public IActionResult UpdateCity(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            CityOfProperty model = _context.CityOfProperties.FirstOrDefault(i => i.Id == id); //city which have to be updated
            if (model == null)
            {
                return NotFound();
            }
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                Name=model
            };
            return View(model2);
        }



        [HttpPost]
        public IActionResult UpdateCity(CityOfProperty model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg")
                    {
                        if (model.ImageFile.Length <= 2097152)
                        {
                            if (model.Image != null)
                            {
                                string oldFilePath = Path.Combine("wwwroot/Uploads/Images", model.Image); //if image !=null
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

                            model.Image = fileName;

                            _context.Entry(model).State = EntityState.Modified;

                            _context.SaveChanges();

                            return RedirectToAction("propertycities", "properties");
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "Can upload max 2MB");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Only .png, .jpeg types");
                    }

                }
            }
            return View(model2);
        }


        //Delete city
        public IActionResult DeleteCity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CityOfProperty city = _context.CityOfProperties.FirstOrDefault(i => i.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            //Delete image
            if (city.Image != null)
            {
                string oldFilePath = Path.Combine("wwwroot/Uploads/Images", city.Image);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

            }
            _context.CityOfProperties.Remove(city);
            _context.SaveChanges();
            return RedirectToAction("propertycities", "properties");

        }






        //Create Bathroom Count
        public IActionResult CreateBathroomCount()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateBathroomCount(BathroomCount model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                if (model.CountName != null)
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("bathroomcount", "properties");
                }
                else
                {
                    ModelState.AddModelError("CountName", "Create Bathroom Count");
                }
            }
            return View(model2);
        }


        //Delete Bathroom Count
        public IActionResult DeleteBathroomCount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            BathroomCount bathroom = _context.BathroomCounts.Find(id);
            if (bathroom == null)
            {
                return NotFound();
            }

            _context.BathroomCounts.Remove(bathroom);
            _context.SaveChanges();
            return RedirectToAction("bathroomcount", "properties");

        }





        //Create Bedroom Count
        public IActionResult CreateBedroomCount()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateBedroomCount(BedroomsCount model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                if (model.CountName != null)
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("bedroomcount", "properties");
                }
                else
                {
                    ModelState.AddModelError("CountName", "Create Bedroom Count");

                }
            }
            return View(model2);
        }


        //Delete Bedroom Count
        public IActionResult DeleteBedroomCount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            BedroomsCount bedroomsCount = _context.BedroomsCounts.Find(id);
            if (bedroomsCount == null)
            {
                return NotFound();
            }

            _context.BedroomsCounts.Remove(bedroomsCount);
            _context.SaveChanges();
            return RedirectToAction("bedroomcount", "properties");

        }





        //Create building age
        public IActionResult CreateAge()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateAge(BuildingAge model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                if (model.Years != null)
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("buildingage", "properties");
                }
                else
                {
                    ModelState.AddModelError("Years", "Create Building Age");

                }
            }
            return View(model2);
        }


        //Delete building age
        public IActionResult DeleteAge(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            BuildingAge age = _context.BuildingAges.Find(id);
            if (age == null)
            {
                return NotFound();
            }

            _context.BuildingAges.Remove(age);
            _context.SaveChanges();
            return RedirectToAction("buildingage", "properties");

        }






        //Create garage count
        public IActionResult CreateGarageCount()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateGarageCount(GarageCount model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                if (model.CountName != null)
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("garagecount", "properties");
                }
                else
                {
                    ModelState.AddModelError("CountName", "Create Garage Count");

                }
            }
            return View(model2);
        }


        //Delete garage count
        public IActionResult DeleteGarageCount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GarageCount count = _context.GarageCounts.Find(id);
            if (count == null)
            {
                return NotFound();
            }

            _context.GarageCounts.Remove(count);
            _context.SaveChanges();
            return RedirectToAction("garagecount", "properties");

        }






        //Create prop type
        public IActionResult CreateType()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateType(PropertyType model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                if (model.Name != null)
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("propertytype", "properties");
                }
                else
                {
                    ModelState.AddModelError("Name", "Add Property Type");

                }
            }
            return View(model2);
        }



        //Update prop type
        public IActionResult UpdateType(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PropertyType model = _context.PropertyTypes.FirstOrDefault(i => i.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                Type = model
            };
            return View(model2);
        }

        [HttpPost]
        public IActionResult UpdateType(PropertyType model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                if (model.Name != null)
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("propertytype", "properties");
                }
                else
                {
                    ModelState.AddModelError("Name", "Add Property Type");

                }
            }
            return View(model2);
        }


        //Delete prop type
        public IActionResult DeleteType(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PropertyType type = _context.PropertyTypes.Find(id);
            if (type == null)
            {
                return NotFound();
            }

            _context.PropertyTypes.Remove(type);
            _context.SaveChanges();
            return RedirectToAction("propertytype", "properties");

        }






        //Create Bedroom Count
        public IActionResult CreateRoomCount()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateRoomCount(RoomsCount model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                if (model.CountName != null)
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("roomscount", "properties");
                }
                else
                {
                    ModelState.AddModelError("CountName", "Create Room Count");

                }
            }
            return View(model2);
        }


        //Delete Bedroom Count
        public IActionResult DeleteRoomCount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            RoomsCount roomcount = _context.RoomsCounts.Find(id);
            if (roomcount == null)
            {
                return NotFound();
            }

            _context.RoomsCounts.Remove(roomcount);
            _context.SaveChanges();
            return RedirectToAction("roomscount", "properties");

        }
    }
}
