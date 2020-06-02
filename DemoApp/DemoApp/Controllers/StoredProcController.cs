using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DempApp.Data;
using DempApp.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class StoredProcController : Controller
    {
        private ApplicationDbConnection _context;

        public StoredProcController(ApplicationDbConnection context)
        {
            _context = context;
        }


        //fetch data using Stored Proc, no parameters
        public IActionResult Index()
        {
            var data = new SP_Call(_context).ReturnList<Vehicle>("GetAllVehicles");
            return View("~/Views/Crud/Index.cshtml", data);
        }
    }
}