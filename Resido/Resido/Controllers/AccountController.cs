using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Resido.Data;
using Resido.Models;
using Resido.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Crypto = BCrypt.Net.BCrypt;


namespace Resido.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult SignUp()
        {
            List<RegistrationOptionSelect> registrationOption = _context.RegistrationOptionSelects.ToList();
            registrationOption.Insert(0, new RegistrationOptionSelect() { Id = 0, OptionSelect = "Select" });
            ViewBag.RegistrationOption = registrationOption;
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(VmSignUp model)
        {
            if (ModelState.IsValid)
            {
                if (model.RegistrationOptionSelectId == 0)
                {
                    ModelState.AddModelError("RegistrationOptionSelectId", "Choose Registration Option");
                    List<RegistrationOptionSelect> registrationOption = _context.RegistrationOptionSelects.ToList();
                    registrationOption.Insert(0, new RegistrationOptionSelect() { Id = 0, OptionSelect = "Select" });
                    ViewBag.RegistrationOption = registrationOption;

                    return View(model);
                }
                if (model.Password == model.ConfirmPass)
                {
                    MyProfileForAgents agent = _context.MyProfileForAgents.FirstOrDefault(c => (c.Phone == model.Phone) || (c.Email == model.Email));
                    if (agent == null)
                    {
                        MyProfileForAgents agent1 = new MyProfileForAgents();
                        agent1.OwnerName = model.FullName;
                        agent1.Email = model.Email;
                        agent1.Phone = model.Phone;
                        agent1.AddedDAte = DateTime.Now;
                        agent1.Password = Crypto.HashPassword(model.Password);
                        agent1.RegistrationOptionSelectId = model.RegistrationOptionSelectId;

                        _context.MyProfileForAgents.Add(agent1);
                        _context.SaveChanges();
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        if (agent.Phone == model.Phone)
                        {
                            ModelState.AddModelError("Phone", "Phone already exists");
                        }
                        else
                        {
                            ModelState.AddModelError("Email", "Email already exists");
                        }
                        List<RegistrationOptionSelect> registrationOption = _context.RegistrationOptionSelects.ToList();
                        registrationOption.Insert(0, new RegistrationOptionSelect() { Id = 0, OptionSelect = "Select" });
                        ViewBag.RegistrationOption = registrationOption;
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("ConfirmPass", "Password is wrong");
                    List<RegistrationOptionSelect> registrationOption = _context.RegistrationOptionSelects.ToList();
                    registrationOption.Insert(0, new RegistrationOptionSelect() { Id = 0, OptionSelect = "Select" });
                    ViewBag.RegistrationOption = registrationOption;
                    return View(model);
                }
            }
            else
            {
                List<RegistrationOptionSelect> registrationOption = _context.RegistrationOptionSelects.ToList();
                registrationOption.Insert(0, new RegistrationOptionSelect() { Id = 0, OptionSelect = "Select" });
                ViewBag.RegistrationOption = registrationOption;
                return View(model);
            }

        }





        public IActionResult Login(int? isCommentPrdId)
        {
            VmLogin model = new VmLogin()
            {
                isCommentPrdId = isCommentPrdId,

            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Login(VmLogin model)
        {
            if (ModelState.IsValid)
            {
                MyProfileForAgents agent = _context.MyProfileForAgents.FirstOrDefault(c => c.Email == model.Email);
                if (agent != null)
                {
                    if (Crypto.Verify(model.Password, agent.Password))
                    {
                        string usertObj = JsonConvert.SerializeObject(agent);
                        HttpContext.Session.SetString("ValidAgentCustomer", usertObj);

                        if (model.isCommentPrdId != null)
                        {
                            return RedirectToAction("details", "properties", new { id = model.isCommentPrdId });

                        }
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
            else
            {
                ModelState.AddModelError("", "");
                return View(model);
            }
        }




        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("ValidAgentCustomer");
            return RedirectToAction("index", "home");
        }





        //Update
        public IActionResult UpdateMyProfile()
        {
            int? id = null;

            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {

                
            }

            if (id == null)
            {
                return RedirectToAction("login", "account");
            }
            MyProfileForAgents myProfileForAgents = _context.MyProfileForAgents.Include(s=>s.SocialToMyProfs).ThenInclude(p=>p.SocialsMyProfile).Include(op=>op.RegistrationOptionSelect).FirstOrDefault(i => i.Id == id); 
            if (myProfileForAgents == null)
            {
                return NotFound();
            }
            return View(myProfileForAgents);
        }


        [HttpPost]
        public IActionResult UpdateMyProfile(MyProfileForAgents profile)
        {
            if (ModelState.IsValid)
            {
                profile.Id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;

                if (profile.ImageFile != null)
                {
                    if (profile.ImageFile.ContentType == "image/png" || profile.ImageFile.ContentType == "image/jpeg")
                    {
                        if (profile.ImageFile.Length <= 2097152)
                        {
                            if (profile.ProfileImage != null)
                            {
                                string oldFilePath = Path.Combine("wwwroot/Uploads/Images", profile.ProfileImage); //if image !=null
                                if (System.IO.File.Exists(oldFilePath))
                                {
                                    System.IO.File.Delete(oldFilePath);
                                }
                            }

                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss") + "-" + profile.ImageFile.FileName;
                            string filePath = Path.Combine("wwwroot/Uploads/Images", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                profile.ImageFile.CopyTo(stream);
                            }
                            profile.ProfileImage = fileName;

                            _context.Entry(profile).State = EntityState.Modified;
                            _context.SaveChanges();


                            return RedirectToAction("index", "home");
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
                else //no image version
                {
                    _context.Entry(profile).State = EntityState.Modified;
                    _context.SaveChanges();

                    return RedirectToAction("index", "home");
                }

            }
            return View(profile);
        }






        //Change password
        public IActionResult ChangePassword()
        {
            int? id = null;

            try
            {
                id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
            }
            catch (Exception)
            {
            }

            if (id == null)
            {
                return NotFound();
            }
            ChangePasswordVM changePassword = new ChangePasswordVM()
            {
                SingleAgent= _context.MyProfileForAgents.Include(s => s.SocialToMyProfs).ThenInclude(p => p.SocialsMyProfile).Include(op => op.RegistrationOptionSelect).FirstOrDefault(i => i.Id == id)
            };

            return View(changePassword);
        }


        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                int? id = null;
                try
                {
                    id = JsonConvert.DeserializeObject<MyProfileForAgents>(HttpContext.Session.GetString("ValidAgentCustomer")).Id;
                }
                catch (Exception)
                {
                }
                MyProfileForAgents agent = _context.MyProfileForAgents.FirstOrDefault(i => i.Id == id);

                if (Crypto.Verify(model.CurrentPassword, agent.Password))
                {
                    if (model.NewPassword==model.ConfirmPassword)
                    {
                        agent.Password = Crypto.HashPassword(model.NewPassword);
                        _context.Entry(agent).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("ConfirmPassword", "No match with new password");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("CurrentPassword", "Wrong current password");
                    return View(model);
                }
            }
            return RedirectToAction("logout", "account");
        }





        //Forget password
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(VmForgetPW model)
        {
            if (model.Email != null)
            {
                MyProfileForAgents customer = _context.MyProfileForAgents.FirstOrDefault(c => c.Email == model.Email);
                if (customer == null)
                {
                    ModelState.AddModelError("Email", "Wrong e-mail");
                    return View(model);
                }

                string token = "dfdsfqwerwerwerdsf";
                customer.Token = token;
                _context.Update(customer);
                _context.SaveChanges();


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("ruslanemircanov123@gmail.com", "Coders Life");
                mail.To.Add(model.Email);
                mail.Body = "<h1>Hello</h1>" +
                    "<p>For resetting password please go to the link below</p>" +
                    "<a href='https://localhost:44317/account/resetpassword?email=" + model.Email + "&token=" + token + "'>Reset Password</a>";
                mail.IsBodyHtml = true;
                mail.Subject = "Reset Password";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("ruslanemircanov123@gmail.com", "Gunahker123");

                smtpClient.Send(mail);

                HttpContext.Session.SetString("mailSending", "true");
                return RedirectToAction("login", "account");
            }
            else
            {
                ModelState.AddModelError("Email", "Wrong mail");
            }
            return View(model);
        }




        //Reset password
        public IActionResult ResetPassword(string email, string token)
        {
            VmReset model2 = new VmReset()
            {

            };
            MyProfileForAgents customer = _context.MyProfileForAgents.FirstOrDefault(c => c.Email == email);
            if (customer == null)
            {
                return RedirectToAction("signup", "account");
            }
            else
            {
                if (customer.Token != token)
                {
                    return RedirectToAction("signup", "account");

                }
                HttpContext.Session.SetString("token", token);

                return View(model2);
                
            }
        }


        [HttpPost]
        public IActionResult ResetPassword(VmReset model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPass)
                {
                    ModelState.AddModelError("", "Password does not match");
                    return View(model);

                }

                string token = HttpContext.Session.GetString("token");

                if (token == null)
                {
                    return RedirectToAction("register", "home");

                }

                MyProfileForAgents agent = _context.MyProfileForAgents.FirstOrDefault(c => c.Token == token);
                agent.Password = Crypto.HashPassword(model.Password);
                agent.Token = null;
                _context.Update(agent);
                _context.SaveChanges();
                return RedirectToAction("login", "account");

            }
            return View(model);
        }
    }
}
