using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using nwa.Models;

namespace nwa.Controllers
{
    public class PeopleController : ApiController
    {
        public static List<People> listPeople = new List<People>();

        [HttpGet]
        [Route("api/people")]
        public void InsertDataToList()
        {
            listPeople.Add(new People { Id = 1, FirstName = "Ivan", LastName = "Pandžić", Age = 24, Gender = "male" });
            listPeople.Add(new People { Id = 2, FirstName = "Marin", LastName = "Bertić", Age = 24, Gender = "male" });
            listPeople.Add(new People { Id = 3, FirstName = "Mislav", LastName = "Horvat", Age = 22, Gender = "male" });
            listPeople.Add(new People { Id = 4, FirstName = "Lorena", LastName = "Šutalo", Age = 21, Gender = "female" });
            listPeople.Add(new People { Id = 5, FirstName = "Filip", LastName = "Gerić", Age = 27, Gender = "male" });
        }

        [HttpGet]
        public HttpResponseMessage GetAllPeople()
        {
            if (listPeople.Count == 0)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, "There are no registred people in list."); }

            return Request.CreateResponse(HttpStatusCode.OK, listPeople);

        }

        [HttpGet]
        public HttpResponseMessage GetPeopleById(int id)
        {
            var person = listPeople.Find(s => s.Id == id);

            if (person == null)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, $"Person with ID:{id} is not found"); }

            return Request.CreateResponse(HttpStatusCode.OK, person);
        }

        [HttpPost]
        public void CreateNewPeople(People person)
        {
            if (person == null)
            { return; }

            if (listPeople.Count == 0)
            { person.Id = 1; }
            else
            { person.Id = listPeople.Last().Id + 1; }

            listPeople.Add(person);
        }

        [HttpPost]
        [Route("api/people")]
        public void CreateNewPeople(List<People> person)
        {
            if (person == null)
            { return; }

            foreach (var item in person)
            {
                if (listPeople.Count == 0)
                { item.Id = 1; }
                else
                { item.Id = listPeople.Last().Id + 1; }

                listPeople.Add(item);
            }
        }

        [HttpPut]
        public HttpResponseMessage EditPeopleById(People person)
        {
            var personFromList = listPeople.Find(s => s.Id == person.Id);

            if (personFromList == null)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, $"Person {person.Id} is not found"); }

            personFromList.FirstName = person.FirstName;
            personFromList.LastName = person.LastName;
            personFromList.Age = person.Age;
            personFromList.Gender = person.Gender;

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/people/delete/{id}")]
        public HttpResponseMessage DeletePeopleById(int id)
        {
            var personFromList = listPeople.Find(s => s.Id == id);

            if (personFromList == null)
            { Request.CreateResponse(HttpStatusCode.BadRequest, $"Person with ID:{id} is not found"); }

            listPeople.Remove(personFromList);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
