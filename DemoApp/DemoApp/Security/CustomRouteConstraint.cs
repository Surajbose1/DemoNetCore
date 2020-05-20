using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Globalization;

namespace DemoApp.Security
{
    public class CustomRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //validate input params  
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            if (route == null)
                throw new ArgumentNullException(nameof(route));

            if (routeKey == null)
                throw new ArgumentNullException(nameof(routeKey));

            if (values == null)
                throw new ArgumentNullException(nameof(values));

            object routeValue;

            if (values.TryGetValue(routeKey, out routeValue))
            {
                var parameterValueString = Convert.ToString(routeValue, CultureInfo.InvariantCulture);
                if (parameterValueString == "Suraj") //case sensitive
                    return true;
            }

            return false;
        }
    }
}
