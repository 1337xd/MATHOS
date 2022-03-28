using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Person.Models
{
    public class RestPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public RestPerson(int id, string firstname, string lastname, int age, string gender)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Gender = gender;
        }
    
        public RestPerson()
        {

        }
    }
}