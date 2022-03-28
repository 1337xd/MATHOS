using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Repository.Common
{
    public interface IPersonRepository
    {
        List<Person> Get();
    }

    public class PersonService : IPersonService
    {
        public PersonService(IPersonRepository repository)
        {
            this.Repository = repository;
        }
        protected IPersonRepository Repository { get; private set; }
        public List<IPerson> Get()
        {
            return Repository.Get();
        }
    }
}