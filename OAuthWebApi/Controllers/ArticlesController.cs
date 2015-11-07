using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using OAuthWebApi.Models;

namespace OAuthWebApi.Controllers
{
    [Authorize(Roles = "admin")]
    public class ArticlesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(new List<Article>());
        }

        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(new Article { ArticleId = 1, Title = "My Article" });
        }
    }
}
