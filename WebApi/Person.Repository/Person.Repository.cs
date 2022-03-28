using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Repository
{
    public class PersonRepository : IPersonRepository
    {
        public PersonRepository(IPersonContext people)
        {
            this.Person = people;
        }

    }
}
