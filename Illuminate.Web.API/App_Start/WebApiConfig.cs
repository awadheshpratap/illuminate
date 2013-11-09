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
                name: "ConsumeApi",
                routeTemplate: "consume/{controller}/{contentId}", defaults: new { contentId = RouteParameter.Optional }
            );

            //POST collaborate/contentcomment/3 -- new comment on content with id=3
            //POST collaborate/contentlike/3 -- new like on content with id=3
            //GET collboarate/contentcomment/3 -- all comments written about content with id=3
            //GET collboarate/contentlike/3 -- all likes on content with id=3
            config.Routes.MapHttpRoute(
                name: "CollaborateApi",
                routeTemplate: "collaborate/{controller}/{contentId}", defaults: new { }
            );

            
            //Ignoring the XML serialization, to allow the Chrome to use the JSON format by default
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
