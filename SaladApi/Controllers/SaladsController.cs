using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SaladApi.Controllers
{
    [Route("api/[controller]")]
    public class saladsController : Controller
    {
        // GET api/salads
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/salads/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/salads
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/salads/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/salads/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
