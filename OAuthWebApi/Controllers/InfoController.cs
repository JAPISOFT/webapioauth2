using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace OAuthWebApi.Controllers
{
    public class InfoController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var obj = new 
            {
                User.Identity.AuthenticationType,
                User.Identity.IsAuthenticated,
                User.Identity.Name
            };

            return Request.CreateResponse(obj);
        }
    }
}
