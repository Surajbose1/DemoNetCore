using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    /// <summary>
    /// In order to implement the NotFound controller locally, do the following
    /// 1. Change the environment to production in launchsettings.json
    /// 2.Change the startup.cs file to use UseStatusCodePagesWithReExecute
    /// 3.Implement the NotfoundController
    /// </summary>
    public class NotFoundController : Controller
    {
        [Route("NotFound/{statusCode}")]
        public IActionResult NotFoundAction(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Resource not found";
                    ViewBag.Path = statusCodeResult.OriginalPath;
                    ViewBag.QS = statusCodeResult.OriginalQueryString;
                    break;
            }
            return View();
        }
    }
}
