using DemoApi.Services;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private readonly PeopleService _peopleServise = new PeopleService();

        

        // GET: api/<PeopleDBController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var peoples = await _peopleServise.GetValuesAsync();
            return Ok(peoples);
        }










        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }

        // POST api/<PeopleController>
        [HttpPost]
        public async void Post([FromBody] string name, int age)
        {
            await _peopleServise.AddPersonAsync(name, age);
        }
        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
