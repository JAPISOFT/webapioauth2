using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json.Serialization;

namespace OAuthWebApi
{
    public static class WebApiConfig
    {
        /// <summary>
        /// Global settings for whole api
        /// </summary>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.EnsureInitialized();

            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            RegisterFormatters(config.Formatters);
        }

        /// <summary>
        /// Media formatter settings
        /// </summary>
        private static void RegisterFormatters(MediaTypeFormatterCollection formatters)
        {
            formatters.Add(new JQueryMvcFormUrlEncodedFormatter());
            formatters.Add(new XmlMediaTypeFormatter());

            formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/javascript"));
            formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x-www-form-urlencoded"));

            formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.XmlFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
            formatters.XmlFormatter.UseXmlSerializer = true;
            formatters.XmlFormatter.Indent = true;
        }
    }
}
