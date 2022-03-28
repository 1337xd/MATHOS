using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Person.Service;
using Person.Model;

namespace nwa.Controllers
{
    public class PersonController : ApiController
    {
        public HttpResponseMessage GetAll()
        {
            PersonService personService = new PersonService();
            List<PersonModel> people = new List<PersonModel>();
            people = personService.GetAll();

            if (people == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, people);
            }

        }

        public HttpResponseMessage Post([FromBody] PersonModel people)
            {
             PersonService personService = new PersonService();
             personService.Post(people);

             return Request.CreateResponse(HttpStatusCode.OK, "entry is posted");
            }


        public HttpResponseMessage DeleteId(int Id)
        {
         PersonService personService = new PersonService();
         personService.DeleteId(Id);
         return Request.CreateResponse(HttpStatusCode.OK, $"Person with ID '{Id}'' is deleted");
        }

    }


}
