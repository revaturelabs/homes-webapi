using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HousingAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Remove formating - xml
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Indentify the type of data
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            // Using camel case instead of proper case
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
