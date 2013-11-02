using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Illuminate.Web.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //POST contribute/content/3 -- Update the Content with Id = 3
            //POST contribute/content -- Create a new content
            config.Routes.MapHttpRoute(
                name: "ContributeApi",
                routeTemplate: "contribute/{controller}/{contentId}", defaults: new { contentId = RouteParameter.Optional }
            );

            //consume/content -- List all content
            //consume/content/3 -- details of content with id = 3
            config.Routes.MapHttpRoute(
                name: "ConsumeListContent",
                routeTemplate: "consume/{controller}/{contentId}", defaults: new { contentId = RouteParameter.Optional }
            );

            //Ignoring the XML serialization, to allow the Chrome to use the JSON format by default
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
