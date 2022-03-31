using Person.Model;
using Person.Service;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;
using nwa.Models;
using Person.Service.Common;

namespace nwa.Controllers
{
    public class PersonController : ApiController
    {
        public async Task<HttpResponseMessage> GetAllAsync(string firstName, string lastName, int age, int? pageNumber, int? numberPerPage, string sortBy, string sortOrder)
        {
            PersonService personService = new PersonService();

            ISorting sorting = new Sorting(sortBy ?? "FirstName", sortOrder);
            IPaging paging = new Paging(pageNumber, numberPerPage);

            List<PersonModel> people;
            List<PersonRest> personRest = new List<PersonRest>();

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
            PersonModel people;
            people = await personService.GetIdAsync(Id);

            if (personService.GetAllAsync() == null)
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


        public async Task<HttpResponseMessage> PutAsync([FromUri] int Id, [FromBody]PersonRest personEdit)
        {
            var personService = new PersonService();
            var people = await personService.GetIdAsync(Id);
            if (people == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Not found");
            }
            else
            {
                people.FirstName = personEdit.FirstName;
                people.LastName = personEdit.LastName;
                await personService.PutAsync(Id, people);
                return Request.CreateResponse(HttpStatusCode.OK, personEdit);
            }
        }


        public async Task<HttpResponseMessage> DeleteIdAsync(int Id)
        {
         PersonService personService = new PersonService();
         await personService.DeleteIdAsync(Id);

         return Request.CreateResponse(HttpStatusCode.OK, $"Person with ID '{Id}'' is deleted");
        }

    }


}
