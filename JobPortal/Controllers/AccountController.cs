using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Data;
using JobPortal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPortal.ViewModels;

namespace JobPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IActionResult Error()
        {
            return View();
        }
        public AccountController(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ApplicationUser applicationUser)
        {
            try
            {
                applicationUser.Role = "Staff";
                applicationUser.Status = "Active";
                _db.ApplicationUsers.Add(applicationUser);
                _db.SaveChanges();
                ViewBag.Message = "User " + applicationUser.Username + " Registered SuccessFully";
                ModelState.Clear();
                return View();
            }
            catch(Exception) 
            {

                ViewBag.Message = "Unable to create the user :(";
                return RedirectToAction("Error","Account");
            }

           
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ApplicationUser applicationUser)
        {
            try
            {
                var user = _db.ApplicationUsers.Where(x => x.Username == applicationUser.Username &&
                x.Password == applicationUser.Password).FirstOrDefault();
                if (user == null)
                {
                    ViewBag.Message = "Invalid Username or password !";
                    return View();
                }

                HttpContext.Session.SetString("Username", applicationUser.Username);

                return RedirectToAction(nameof(DashBoard));
            }
            catch (Exception)
            {
               
               


                return RedirectToAction("Error", "Account");
            }

        }
        public IActionResult Logout()
        {
            try
            {

                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Account");
            }
            catch (Exception)
            {
                return RedirectToAction("Error","Account");
            }
        }

        public IActionResult DashBoard()
        {
            try
            {
                if (HttpContext.Session.GetString("Username") != null)
                {

                    var apps = _db.Applications.ToList();
                    return View(apps);
                }
                else
                {
                    return RedirectToAction("Login","Account");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Account");
            }
        }


        public IActionResult Details(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Username") != null)
                {

                    var app = _db.Applications.Where(x => x.Id == id).FirstOrDefault();
                    return View(app);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
               
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Account");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Username") != null)
                {
                    var app = _db.Applications.Where(x => x.Id == id).FirstOrDefault();
                    string webRootPath = _webHostEnvironment.WebRootPath;
                   
                    var profile = Path.Combine(webRootPath, app.Profile.TrimStart('\\'));

                    if (System.IO.File.Exists(profile))
                    {
                        System.IO.File.Delete(profile);
                    }
                  

                    _db.Applications.Remove(app);
                    _db.SaveChanges();

                    return RedirectToAction(nameof(DashBoard));
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Account");
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Username") != null)
                {
                    var app = _db.Applications.Where(x => x.Id == id).FirstOrDefault();

                    EditForm EditViewModel = new EditForm
                    {
                        Id = app.Id,
                        ExistingPhotoPath = app.Profile,
                        PlacePosting = app.PlacePosting,
                        PostAppliedFor = app.PostAppliedFor,
                        Name = app.Name,
                        FatherName = app.FatherName,
                        DateofBirth = app.DateofBirth,
                        Age = app.Age,
                        CNIC = app.CNIC,
                        Domicile = app.Domicile,
                        Contact = app.Contact,
                        Contact1 = app.Contact1,
                        PostalAddress = app.PostalAddress,
                        PermanentAddress = app.PermanentAddress,
                        Email = app.Email,
                        Religion = app.Religion,
                        HafizeQuran = app.HafizeQuran,
                        Disability=app.Disability,
                        GovtService=app.GovtService,
                        Gender = app.Gender,
                        MartialStatus = app.MartialStatus

                    };

                    return View(EditViewModel);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
               }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Account");
            }
        }
        [HttpPost]
        public IActionResult Edit(EditForm temp)
        {
            try
            {
                if (HttpContext.Session.GetString("Username") != null)
                {
                    var app = _db.Applications.Where(x => x.Id == temp.Id).FirstOrDefault();

                    var files = HttpContext.Request.Form.Files;

                    //New Service
                    if (files.Count == 1)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, @"images\myFiles");
                        var extension = Path.GetExtension(files[0].FileName);

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }
                        app.Profile = @"\images\myFiles\" + fileName + extension;
                    }

                    app.PlacePosting = temp.PlacePosting;
                    app.PostAppliedFor = temp.PostAppliedFor;
                    app.Name = temp.Name;
                    app.FatherName = temp.FatherName;
                    app.DateofBirth = temp.DateofBirth;
                    app.Age = temp.Age;
                    app.Domicile = temp.Domicile;
                    app.Contact = temp.Contact;
                    app.Contact1 = temp.Contact1;
                    app.CNIC = temp.CNIC;
                    app.PermanentAddress = temp.PermanentAddress;
                    app.PostalAddress = temp.PostalAddress;
                    app.Email = temp.Email;
                    app.MartialStatus = temp.MartialStatus;
                    app.Gender = temp.Gender;
                    app.Religion = temp.Religion;
                    app.GovtService = temp.GovtService;
                    app.HafizeQuran = temp.HafizeQuran;
                    app.Disability = temp.Disability;




                    _db.Applications.Update(app);
                    _db.SaveChanges();
                    return RedirectToAction("DashBoard", "Account");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception)
            {
                //      return RedirectToAction("DashBoard", "Account");
                return RedirectToAction("Error", "Account");
            }
        }
        

    }
}
