using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person.Model;
using Person.Repository;
using Person.Service.Common;

namespace Person.Service
{
    public class PersonService : IPersonService
    {
        List<PersonModel> personModel = new List<PersonModel>();
        public List<PersonModel> GetAll()
        {
            PersonRepository personRepository = new PersonRepository();

            return personRepository.GetAll();
        }


        public void Post(PersonModel people)
        {
            PersonRepository personRepository = new PersonRepository();
            personRepository.Post(people);
        }


        public void Put(PersonModel people)
        {
            PersonRepository personRepository = new PersonRepository();
            personRepository.Put(people);
        }
    }
}
    
