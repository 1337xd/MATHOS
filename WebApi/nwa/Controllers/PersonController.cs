using Person.Model;
using Person.Service;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;
using nwa.Models;

namespace nwa.Controllers
{
    public class PersonController : ApiController
    {
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            PersonService personService = new PersonService();
            List<PersonModel> people = new List<PersonModel>();
            people = await personService.GetAllAsync();

            if (people == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, people);
            }

        }


        public async Task<HttpResponseMessage> GetIdAsync(int Id)
        {
            PersonService personService = new PersonService();
            PersonModel people = await personService.GetIdAsync(Id);

            if (people != null)
            {
                PersonRest personRest = new PersonRest();

                personRest.FirstName = people.FirstName;
                personRest.LastName = people.LastName;
                personRest.Age = people.Age;
                personRest.Gender = people.Gender;

                return Request.CreateResponse(HttpStatusCode.OK, personRest);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }



        public async Task<HttpResponseMessage> PostAsync([FromBody] PersonModel people)
            {
             PersonService personService = new PersonService();
             await personService.PostAsync(people);

             return Request.CreateResponse(HttpStatusCode.OK, "entry is posted");
            }


        public async Task<HttpResponseMessage> DeleteIdAsync(int Id)
        {
         PersonService personService = new PersonService();
         await personService.DeleteIdAsync(Id);

         return Request.CreateResponse(HttpStatusCode.OK, $"Person with ID '{Id}'' is deleted");
        }

    }


}
