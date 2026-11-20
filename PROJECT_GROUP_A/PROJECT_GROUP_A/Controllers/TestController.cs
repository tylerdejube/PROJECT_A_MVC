using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PROJECT_GROUP_A.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return "Skills Database API is working!";
        }
    }
}
