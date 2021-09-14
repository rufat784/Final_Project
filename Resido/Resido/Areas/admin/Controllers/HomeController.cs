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

    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.Include(p => p.CityOfProperty).ToList(),
                MyProfileForAgents = _context.MyProfileForAgents.ToList(),
                LatestUsers = _context.MyProfileForAgents.OrderByDescending(a => a.AddedDAte)
                                                         .Where(t => t.RegistrationOptionSelect.OptionSelect == "Agent" || t.RegistrationOptionSelect.OptionSelect == "Agency").ToList(),
                LatestCustomers=_context.MyProfileForAgents.OrderByDescending(d=>d.AddedDAte).Where(a=>a.RegistrationOptionSelect.OptionSelect=="Customer").ToList()
            };
            return View(model);
        }


        public IActionResult HowItWorks()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                HowItWorks=_context.HowItWorks.ToList()
            };
            return View(model);
        }


        public IActionResult About()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                About = _context.Aboutcs.FirstOrDefault(),
                Abouts = _context.Aboutcs.ToList()

            };
            return View(model);
        }


        public IActionResult OurMission()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                OurMissions = _context.OurMissionInAbouts.ToList()
            };
            return View(model);
        }



        public IActionResult OurMissionImage()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                OurMissionMainImage = _context.OurMissionMainImages.FirstOrDefault(),
                OurMissionMainImages = _context.OurMissionMainImages.ToList()

            };
            return View(model);
        }




        //Create HIW
        public IActionResult CreateHiw()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateHiw(HowItWorks model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                    _context.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("howitworks", "home");
            }
            return View(model2);
        }



        //Update HIW
        public IActionResult UpdateHiw(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            HowItWorks model = _context.HowItWorks.FirstOrDefault(i => i.Id == id); //city which have to be updated
            if (model == null)
            {
                return NotFound();
            }
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                Icon = model
            };
            return View(model2);
        }


        [HttpPost]
        public IActionResult UpdateHiw(HowItWorks model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {

                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("howitworks", "home");
            }
            return View(model2);
        }



        //Delete Hiw 
        public IActionResult DeleteHiw(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HowItWorks how = _context.HowItWorks.Find(id);
            if (how == null)
            {
                return NotFound();
            }

            _context.HowItWorks.Remove(how);
            _context.SaveChanges();
            return RedirectToAction("howitworks", "home");

        }







        //Create About
        public IActionResult CreateAbout()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList()
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult CreateAbout(Aboutcs model)
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


                            _context.Aboutcs.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("about", "home");
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
                else
                {
                    ModelState.AddModelError("ImageFile", "Please add photo");
                }
            }
            return View(modelcity);
        }


        //Update About
        public IActionResult UpdateAbout(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Aboutcs model = _context.Aboutcs.FirstOrDefault(i => i.Id == id); 
            if (model == null)
            {
                return NotFound();
            }
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                About = model,
            };
            return View(model2);
        }

        [HttpPost]
        public IActionResult UpdateAbout(Aboutcs model)
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

                            return RedirectToAction("about", "home");
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
                else
                {
                    ModelState.AddModelError("ImageFile", "Please add photo");
                }
            }
            return View(model2);
        }







        //Create OM
        public IActionResult CreateOM()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateOM(OurMissionInAbout model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
            };
            if (ModelState.IsValid)
            {
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ourmission", "home");
            }
            return View(model2);
        }



        //Update OM
        public IActionResult UpdateOM(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            OurMissionInAbout model = _context.OurMissionInAbouts.FirstOrDefault(i => i.Id == id); 
            if (model == null)
            {
                return NotFound();
            }
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                OurMissionInAbout = model
            };
            return View(model2);
        }

        [HttpPost]
        public IActionResult UpdateOM(OurMissionInAbout model)
        {
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                OurMissionInAbout = model

            };
            if (ModelState.IsValid)
            {

                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("ourmission", "home");
            }
            return View(model2);
        }


        //Delete OM 
        public IActionResult DeleteOM(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            OurMissionInAbout how = _context.OurMissionInAbouts.Find(id);
            if (how == null)
            {
                return NotFound();
            }

            _context.OurMissionInAbouts.Remove(how);
            _context.SaveChanges();
            return RedirectToAction("ourmission", "home");

        }







        //Create OurMission Image
        public IActionResult CreateImage()
        {
            VmBase model = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateImage(OurMissionMainImage model)
        {
            VmBase modelimage = new VmBase()
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


                            _context.OurMissionMainImages.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("OurMissionImage", "home");
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
                else
                {
                    ModelState.AddModelError("ImageFile", "Please add photo");
                }
            }
            return View(modelimage);
        }



        //Update OurMission Image
        public IActionResult UpdateImage(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            OurMissionMainImage model = _context.OurMissionMainImages.FirstOrDefault(i => i.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            VmBase model2 = new VmBase()
            {
                Contacts = _context.Contacts.ToList(),
                Properties = _context.Properties.ToList(),
                OurMissionMainImage = model,
            };
            return View(model2);
        }

        [HttpPost]
        public IActionResult UpdateImage(OurMissionMainImage model)
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

                            return RedirectToAction("OurMissionImage", "home");
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
    }
}
