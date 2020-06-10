using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Security
{
    public class LoginFilter : Attribute, IActionFilter
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ILogger<LoginFilter> _loginFilter;

        public LoginFilter(IHttpContextAccessor accessor, ILogger<LoginFilter> loginFilter)
        {
            _accessor = accessor;
            _loginFilter = loginFilter;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = _accessor.HttpContext.Request.HttpContext.User.Identity.Name;
            _loginFilter.LogInformation(user);
        }
    }
}
