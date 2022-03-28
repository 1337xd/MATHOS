using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using Person.Model;
using System.Data;
using System.Data.SqlClient;
using Person.Repository.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Repository
{
    public class PersonRepository : IPersonRepository
    {
        static string connectionString = @"Data Source=DESKTOP-V8JBKRE;Initial Catalog=SQLTest;Integrated Security=True";

        List<PersonModel> people = new List<PersonModel>();


        //GET

        public async Task<List<PersonModel>> GetAllAsync()
        {
            SqlConnection connection = new SqlConnection(connectionString);
   

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Person;", connection);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        var person = new PersonModel();

                        person.Id = reader.GetInt32(0);
                        person.FirstName = reader.GetString(1);
                        person.LastName = reader.GetString(2);
                        person.Age = reader.GetInt32(3);
                        person.Gender = reader.GetString(4);

                        people.Add(person);
                    }

                    connection.Close();
                    reader.Close();
                }   

            }

            return people;

        }


        //GET by ID

        public async Task<PersonModel> GetIdAsync(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            PersonModel personModel = new PersonModel();

            using (connection)
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE Id = '{Id}';", connection);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    personModel.Id = reader.GetInt32(0);
                    personModel.FirstName = reader.GetString(1);
                    personModel.LastName = reader.GetString(2);
                    personModel.Age = reader.GetInt32(3);
                    personModel.Gender = reader.GetString(4);


                    connection.Close();
                    reader.Close();                    
                }
            }
            return personModel;
        }


        //POST

        public async Task PostAsync(PersonModel people)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();

            using (connection)
            {
                await connection.OpenAsync();
                string editColumn = $"INSERT INTO Person(Id, FirstName, LastName, Age, Gender) VALUES" +
                    $"('{people.Id}'," +
                    $"'{people.FirstName}'," +
                    $"'{people.LastName}'," +
                    $"'{people.Age}'," +
                    $"'{people.Gender}')";

                adapter.InsertCommand = new SqlCommand(editColumn, connection);
                
                await adapter.InsertCommand.ExecuteNonQueryAsync();

                connection.Close();
            }

        }


        //UPDATE

        public void Put(PersonModel people)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            var connection = new SqlConnection(connectionString);

            using (connection)
            {
                string editColumn = $"UPDATE Person SET" + 
                    $"('{people.Id}'," +
                    $"'{people.FirstName}'," +
                    $"'{people.LastName}'," +
                    $"'{people.Age}'," +
                    $"'{people.Gender}')";

                connection.Open();

                adapter.UpdateCommand = connection.CreateCommand();
                adapter.UpdateCommand.CommandText = editColumn;
                adapter.UpdateCommand.ExecuteNonQuery();

                connection.Close();
            }
        }


        //DELETE

        public async Task DeleteIdAsync(int Id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                await connection.OpenAsync();

                string deleteId = $"SELECT * FROM Person WHERE Id = '{Id}';";
                SqlCommand command = new SqlCommand(deleteId, connection);
                SqlDataReader reader = command.ExecuteReader();
                
                if(await reader.ReadAsync())
                {
                    connection.Close();

                    await connection.OpenAsync();

                    deleteId = $"DELETE FROM Person WHERE Id = '{Id}';";
                    adapter.InsertCommand = new SqlCommand(deleteId, connection);
                    await adapter.InsertCommand.ExecuteNonQueryAsync();

                    connection.Close();
                }
            }
        }
    }
}

