using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApp.Controllers
{
    public class LoggingController : Controller
    {
        //Default logging provider
        private ILogger _logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }
         
        //steps to configure Nlog
        //1. Install Nlog.Web.AspNetCore nuget package
        //2.Create nlog.config file, change copy settings by looking up the properties
        //3.Add Nlog as one of the Logging provider in Program.cs
        public IActionResult Index()
        {
            throw new Exception("Testing Nlog Logging");
        }


        public IActionResult TestLog()
        {
            _logger.LogInformation("Test1");
            _logger.LogDebug("Test2");
            _logger.LogError("Test3");
            _logger.LogCritical("Test4");
            _logger.LogWarning("Test5");

            return Content("Logging Done");
        }

    }
}