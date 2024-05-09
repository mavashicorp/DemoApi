using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {


        private static readonly List<string> values = new List<string>
        {
            "value1", "value2"
        };
        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return values;
        }

        // GET api/<TestController>/5

        [HttpGet("{id}")]
        public string GetInt(int id)
        {
            if (id < 0 || id >= values.Count)
            {
                return "Not found";
            }
            return values[id];
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            values.Add(value);
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            values[id] = value; 
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            values.RemoveAt(id);
        }
    }
}
