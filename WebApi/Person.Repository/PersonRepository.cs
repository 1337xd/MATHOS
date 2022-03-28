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

namespace Person.Repository
{
    public class PersonRepository : IPersonRepository
    {
        static string connectionString = @"Data Source=DESKTOP-V8JBKRE;Initial Catalog=SQLTest;Integrated Security=True";

        List<PersonModel> people = new List<PersonModel>();


        //GET

        public List<PersonModel> GetAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
   

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Person;", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
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


        //POST

        public PersonModel Post(PersonModel people)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();

            using (connection)
            {
                connection.Open();
                string newColumn = $"INSERT INTO Person(Id, FirstName, LastName, Age, Gender) VALUES" +
                    $"('{people.Id}'," +
                    $"'{people.FirstName}'," +
                    $"'{people.LastName}'," +
                    $"'{people.Age}'," +
                    $"'{people.Gender}')";

                adapter.InsertCommand = new SqlCommand(newColumn, connection);
                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();
                return people;

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


    }
}

