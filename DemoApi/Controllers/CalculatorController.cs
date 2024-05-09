using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET: api/calculator/add?x=5&y=3
        [HttpGet("add")]
        public IActionResult Add(double x, double y)
        {
            return Ok(x + y);
        }

        [HttpGet("minus")]

        public IActionResult minus(double x, double y) 
        {
            return Ok(x - y);
        }


        [HttpGet("mnogit")]
        public IActionResult mnogit(double x, double y)
        {
            return Ok(x * y);
        }


        [HttpGet("delit")]
        public IActionResult delit(double x, double y)
        {
            if (y == 0)
            {
                return BadRequest("Devide by zero");
            }

            return Ok(x / y);
        }
    }
}
