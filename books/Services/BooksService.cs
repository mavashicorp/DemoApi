using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace books.Services
{
    public class BooksService
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string Author { get; set; }

        public string Name { get; set; }

        public string Jenre { get; set; }

        private readonly string connectionString = "server=localhost;user=root;password=1488;database=booksDB;";

        public BooksService() { }

        public async Task<List<string>> GetValuesAsync()
        {
            var books = new List<string>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, BookId, Author, Name, Jenre FROM books";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var Id = reader.GetInt32("Id");
                        var BookId = reader.GetInt32("BookId");
                        var Author = reader.GetString("Author");
                        var Name = reader.GetString("Name");
                        var Jenre = reader.GetString("Jenre");
                        books.Add($"ID: {Id}, BookId: {BookId}, Author: {Author}, Name: {Name}, Jenre: {Jenre}");
                    }
                }
            }

            return books;
        }

        public async Task AddBookAsync()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO books (Id, BookId, Author, Name, Jenre) VALUES (@Id, @BookId, @Author, @Name, @Jenre)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@BookId", BookId);
                    command.Parameters.AddWithValue("@Author", Author);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Jenre", Jenre);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        
    }
}
