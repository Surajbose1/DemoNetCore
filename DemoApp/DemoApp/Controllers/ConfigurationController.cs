using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DemoApp.Controllers
{
    /// <summary>
    /// Deals with configs/app settings, how the settings override
    /// </summary>
    public class ConfigurationController : Controller
    {
        private IConfiguration _config;

        public ConfigurationController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            var model = new List<string>();
            
            //Read from App settings file
            model.Add(_config["MyKey"]);

            //Read from App settings Development file(override)
            model.Add(_config["MyKey1"]);


            return View("Index",model);
        }

        public IActionResult HostProcessName()
        {
            return Content(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
        }
    }
}