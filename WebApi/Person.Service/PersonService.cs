using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person.Model;
using Person.Repository;
using Person.Service.Common;
using System.Threading;

namespace Person.Service
{
    public class PersonService : IPersonService
    {
        public async Task<List<PersonModel>> GetAllAsync()
        {
            PersonRepository personRepository = new PersonRepository();
            List<PersonModel> personModel = await personRepository.GetAllAsync();

            return personModel;
        }


        public async Task<PersonModel> GetIdAsync(int Id)
        {
            PersonRepository personRepository = new PersonRepository();
            PersonModel personModel = await personRepository.GetIdAsync(Id);

            return personModel;
        }


        public async void PostAsync(PersonModel people)
        {
            PersonRepository personRepository = new PersonRepository();

            await personRepository.PostAsync(people);
        }


        public async void PutAsync(PersonModel people)
        {
            PersonRepository personRepository = new PersonRepository();
            await personRepository.PutAsync(people);
        }


        public async void DeleteIdAsync(int Id)
        {
            PersonRepository personRepository = new PersonRepository();
            await personRepository.DeleteIdAsync(Id);
        }


    }
}
    
