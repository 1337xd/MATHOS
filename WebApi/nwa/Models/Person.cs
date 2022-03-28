using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nwa.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Person(int id, string firstname, string lastname, int age, string gender)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Gender = gender;
        }
    
        public Person()
        {

        }
    }
}