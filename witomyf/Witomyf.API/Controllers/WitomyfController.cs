using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Witomyf.API.Controllers
{
    public class WitomyfController : ApiController
    {
        [Route("api")]

        [HttpGet]
        public HttpResponseMessage getW()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new Models.Witomyf {Day = DateTime.Now.Day.ToString(), Eat1 = 50 });
            
        }
    }
}
