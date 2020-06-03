using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Models;
using DempApp.Data;
using DempApp.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{

    //Working with images in .net core, code is not optimised.
    //this is just to show how to work with images
    public class ImageUploadController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        private ApplicationDbConnection _context;

        public ImageUploadController(ApplicationDbConnection context, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            var phoneList = new List<PhoneViewModel>();
            var phone = _context.Phone;
            foreach(var item in phone)
            {
                var phoneViewModel = new PhoneViewModel() { PhoneId = item.PhoneId, Model = item.Model, ImagePath = item.ImageFile, Manufacturer = item.Manufacturer };
                phoneList.Add(phoneViewModel);
            }
            return View(phoneList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PhoneViewModel phonemodel)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (phonemodel.ImageFile != null)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + phonemodel.ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    phonemodel.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var phone = new Phone() { PhoneId = Guid.NewGuid(), ImageFile = fileName, Manufacturer = phonemodel.Manufacturer, Model = phonemodel.Manufacturer };
                _context.Phone.Add(phone);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}