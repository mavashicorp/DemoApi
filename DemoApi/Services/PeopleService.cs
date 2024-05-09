using MySql.Data.MySqlClient;
using System.Data;

namespace DemoApi.Services
{
    
    public class PeopleService
    {
        private readonly string _connectionString = "server=localhost;user=root;password=1488;database=exampleDB;"; //сохранить правильную строку подключения

        public PeopleService() { }

        public async Task<List<string>> GetValuesAsync()
        {
            var people = new List<string>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, Name, Age FROM People";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var id = reader.GetInt32("Id");
                        var name = reader.GetString("Name");
                        var age = reader.GetInt32("Age");
                        people.Add($"ID: {id}, Name: {name}, Age: {age}");
                    }
                }
            }

            return people;
        }

        public async Task AddPersonAsync(string name, int age)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO People (Name, Age) VALUES (@name, @age)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
