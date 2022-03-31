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
    public class PersonService : IPersonServiceCommon
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


        

        
        public async Task PostAsync(PersonModel people)
        {
            PersonRepository personRepository = new PersonRepository();

            await personRepository.PostAsync(people);
        }


        public async Task PutAsync(int Id, PersonModel personEdit)
        {
            PersonRepository personRepository = new PersonRepository();
            await personRepository.PutAsync(Id, personEdit);
        }


        
         public async Task DeleteIdAsync(int Id)
        {
            PersonRepository personRepository = new PersonRepository();
            await personRepository.DeleteIdAsync(Id);
        }


    }
}
    
