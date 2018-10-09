using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/getinfo")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/getinfo
        [HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        public ActionResult<string> Get()
        {
            //return new string[] { "value1", "value2" };
            Console.WriteLine("No param get");
            return "A parameter needs to be given";
        }

        // GET api/getinfo/module/{moduleNum}
        [HttpGet("module/{id}/{info}")]
        public ActionResult<string> Get(int id)
        {
            Console.WriteLine("module/{0}/{1}", id, "[info missing]");
            return "module " + id + " info " + "[info missing]";
        }

        // GET api/getinfo/module/{moduleNum}/{infoNum}
        [HttpGet("module/{id}/{info}")]
        public ActionResult<string> Get(int id, int info)
        {
            Console.WriteLine("module/{0}/{1}", id, info);
            return "module " + id  + " info " + info;
        }

        // POST api/getinfo
        [HttpPost("newmodule/{name}")]
        public void Post([FromBody] string value)
        {
            Console.WriteLine("New module {0}", value);
        }

        // PUT api/getinfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/getinfo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
