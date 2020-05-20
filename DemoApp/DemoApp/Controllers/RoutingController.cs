using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DemoApp.Controllers
{
    /// <summary>
    /// Play with Routing, parameters and route constraints
    /// </summary>
    public class RoutingController : Controller
    {
        [Route("TestRoute/{name:alpha}")]
        public IActionResult Index(string name)
        {
            return Content("Route Found with name(string) " + name);
        }

        [Route("TestRoute/{name:int}")]
        public IActionResult Index(int name)
        {
            return Content("Route Found with name(int) " + name);
        }

        [Route("TestRoute/{name:guid}")]
        public IActionResult Index(Guid name)
        {
            return Content("Route Found with name(GUID) " + name);
        }

        [Route("TestRoute/{name:datetime}")]
        public IActionResult Index(DateTime name)
        {
            return Content("Route Found with name(Datetime) " + name);
        }

        [Route("TestCustomRoute/{name:customroute}")]
        public IActionResult TestCustomRoute(string name)
        {
            return Content("Route Found with name(Custom Constraint) " + name);
        }
    }
}