using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorldExtensibleAPI.Controllers
{
    public class HelloController : ApiController
    {
        /// <summary>
        /// Returns the classic "Hello, World!" greeting, often used in introduce one to a new programming language.
        /// </summary>
        /// <returns>"Hello, World!" text</returns>
        // GET api/<controller>
        public string Get()
        {
            // Hello, World!
            var greeting = string.Format("{0}, {1}!", ConfigurationManager.AppSettings["MessageGreeting"],
                ConfigurationManager.AppSettings["MessageAudienceDefault"]);

            // TODO: Add usage to HelloWorldExtensibleDB database via EntityFramework or TSQL using ADO .NET

            return greeting;
        }


        // GET api/<controller>/everybody
        /// <summary>
        /// Takes an audience parameter and says "Hello" specifically to them, rather than the entire world.
        /// </summary>
        /// <param name="audience">Whom to say "Hello" to</param>
        /// <returns>"Hello" to the audience specified</returns>
        public string Get(string audience)
        {
            // Hello, everybody!
            var greeting = string.Format("{0}, {1}!", ConfigurationManager.AppSettings["MessageGreeting"],
                audience);

            // TODO: Add usage to HelloWorldExtensibleDB database via EntityFramework or TSQL using ADO .NET

            return greeting;
        }
    }
}