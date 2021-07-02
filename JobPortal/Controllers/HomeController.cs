using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobPortal.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using JobPortal.ViewModels;
using Microsoft.AspNetCore.Http;
using JobPortal.Data;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment
            , ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            
            return View();
        }


        public  IActionResult Create()
        {
            try
            {
                ApplicationVM VM = new ApplicationVM();
                VM.HafizeQuran = "Yes";
                VM.GovtService = "No";
                VM.Disability = "Yes";
                return View(VM);
            }
            catch (Exception)
            {
                return RedirectToAction("Error","Account");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationVM applicationVM)
        {
           try
           {

                if (ModelState.IsValid)
                {
                    var files = HttpContext.Request.Form.Files;

                    //New Service
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(_webHostEnvironment.WebRootPath, @"images\myFiles");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }
                    applicationVM.Profile = @"\images\myFiles\" + fileName + extension;
                    Application application = new Application();

                    application.Profile = applicationVM.Profile;
                    application.PlacePosting = applicationVM.PlacePosting;
                    application.PostAppliedFor = applicationVM.PostAppliedFor;
                    application.Name = applicationVM.Name;
                    application.FatherName = applicationVM.FatherName;
                    application.DateofBirth = applicationVM.DateofBirth;
                    application.Age = applicationVM.Age;
                    application.Domicile = applicationVM.Domicile;
                    application.Contact = applicationVM.Contact;
                    application.Contact1 = applicationVM.Contact1;
                    application.CNIC = applicationVM.CNIC;
                    application.PermanentAddress = applicationVM.PermanentAddress;
                    application.PostalAddress = applicationVM.PostalAddress;
                    application.Email = applicationVM.Email;
                    application.HafizeQuran = applicationVM.HafizeQuran;
                    application.GovtService = applicationVM.GovtService;
                    application.Disability = applicationVM.Disability;
                    application.MartialStatus = applicationVM.MartialStatus;
                    application.Gender = applicationVM.Gender;
                    application.Religion = applicationVM.Religion;

                    _db.Applications.Add(application);
                    _db.SaveChanges();


                    return RedirectToAction("Congratulations", "Home");
                }
                else
                {
                    ViewBag.Message = " Error";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Message = " Error";
                return RedirectToAction("Error","Account");
            }
        }
       
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Congratulations()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
