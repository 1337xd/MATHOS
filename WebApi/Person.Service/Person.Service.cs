using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Service
{
    public class PersonService : IPersonService
    {
        public PersonService(IPersonRepository repository)
        {
            this.Repository = repository
        }

        protected IPersonRepository Repository { get; set; }

        public bool AddToPerson(int Id)
        {
            IPerson person = Repository.GetAllProducts().FirstOrDefault(p => p.Id.Equals(personId));
            if(person !=null)
            {
                if(!person.Exist)
                {
                    throw new ArgumentOutOfRangeException("Exist");
                }
                if(person.Non)
                {
                    throw new ArgumentNullException("Non-Existant");
                }

                return Repository.AddToPerson(personId)
            
            }
            return false;

        }


    }
}
