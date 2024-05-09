using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
    public class Book
    {
        public int Id { get; }
        public int BookId { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Jenre { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult Get()
        {
            // Возвращает список всех книг
            return Ok("GET method placeholder");
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Возвращает книгу по id
            return Ok($"GET method placeholder for book with id {id}");
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            // Создаёт новую книгу
            return Ok("POST method placeholder");
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            // Обновляет существующую книгу по id
            return Ok($"PUT method placeholder for book with id {id}");
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Удаляет книгу по id
            return Ok($"DELETE method placeholder for book with id {id}");
        }
    }
}
