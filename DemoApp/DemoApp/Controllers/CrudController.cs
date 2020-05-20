using DempApp.Data;
using DempApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DemoApp.Controllers
{
    /// <summary>
    /// Play with CRUD Operations, Delete not implemented as its matter of copy paste
    /// </summary>
    public class CrudController : Controller
    {

        [BindProperty] //This takes care of the save when doing a HTTP POST
        public Vehicle Vehicle { get; set; }

         private ApplicationDbConnection _context;
        public CrudController(ApplicationDbConnection context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vehicleData = _context.Vehicle;
            return View(vehicleData);
        }

        public IActionResult ViewDetails(Guid id)
        {
            var vehicleDetail = _context.Vehicle.Find(id);
            return View(vehicleDetail);
        }
        
        [HttpGet]
        public IActionResult EditDetails(Guid? id)
        {
            var vehicleDetail = _context.Vehicle.FirstOrDefault(x => x.VehicleId == id);
            if (vehicleDetail == null)
            {
                vehicleDetail = new Vehicle();
                return View(vehicleDetail);
            }
            else
                vehicleDetail = _context.Vehicle.Find(id);

            return View(vehicleDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDetails()
        {
            var vehicleDetail = _context.Vehicle.FirstOrDefault(x=>x.VehicleId == Vehicle.VehicleId);
            if (vehicleDetail == null)
            {
                vehicleDetail = new Vehicle
                {
                    VehicleId = System.Guid.NewGuid()
                };
                _context.Vehicle.Add(vehicleDetail);
            }

            vehicleDetail.Make = Vehicle.Make;
            vehicleDetail.Model = Vehicle.Model;
            vehicleDetail.Price = Vehicle.Price;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}