using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ResourceServer.Attributes;

namespace ResourceServer.Controllers
{
    [EnableCors("*", "*", "GET,OPTIONS")]
    public class MeController : ApiController
    {
        [Authorize]
        [Scope("bio2")]
        public string Get()
        {
            return this.User.Identity.Name;
        }
    }
}
