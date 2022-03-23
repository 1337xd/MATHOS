using nwa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nwa.Controllers
{
    public class AnimalController : ApiController
    {

        public static List<AnimalModel> listAnimal = new List<AnimalModel>();

        // GET

        [HttpGet]
        [Route("api/animal")]
        public void InsertDataToList()
        {
            listAnimal.Add(new AnimalModel { Id = 1, Name = "Ares", Species = "Dog", Age = 8 });
            listAnimal.Add(new AnimalModel { Id = 2, Name = "Flufy", Species = "Cat", Age = 7});
            listAnimal.Add(new AnimalModel { Id = 3, Name = "Peroslav", Species = "Bird", Age = 12 });
            listAnimal.Add(new AnimalModel { Id = 4, Name = "Stjepan", Species = "Lizard", Age = 15 });
            listAnimal.Add(new AnimalModel { Id = 5, Name = "Miss.LordHaveMercy", Species = "Spider", Age = 3 });
        }

        [HttpGet]
        public HttpResponseMessage GetAllAnimal()
        {
            if (listAnimal.Count == 0)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, "There are no registred animals in list."); }

            return Request.CreateResponse(HttpStatusCode.OK, listAnimal);

        }


        [HttpGet]
        public HttpResponseMessage GetAnimalById(int id)
        {
            var animal = listAnimal.Find(s => s.Id == id);

            if (animal == null)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, $"Animal with ID:{id} is not found"); }

            return Request.CreateResponse(HttpStatusCode.OK, animal);
        }

        // POST

        [HttpPost]
        public void CreateNewAnimal(AnimalModel animal)
        {
            if (animal == null)
            { return; }

            if (listAnimal.Count == 0)
            { animal.Id = 1; }
            else
            { animal.Id = listAnimal.Last().Id + 1; }

            listAnimal.Add(animal);
        }

        // POST nap novi 

        [HttpPost]
        [Route("api/animal")]
        public void CreateNewAnimal(List<AnimalModel> animal)
        {
            if (animal == null)
            { return; }

            foreach (var item in animal)
            {
                if (listAnimal.Count == 0)
                { item.Id = 1; }
                else
                { item.Id = listAnimal.Last().Id + 1; }

                listAnimal.Add(item);
            }
        }

        // PUT edit postojeci

        [HttpPut]
        public HttpResponseMessage EditAnimalById(AnimalModel animal)
        {
            var animalFromList = listAnimal.Find(s => s.Id == animal.Id);

            if (animalFromList == null)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, $"Animal {animal.Id} is not found"); }

            animalFromList.Name = animal.Name;
            animalFromList.Species = animal.Species;
            animalFromList.Age = animal.Age;

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE

        [HttpDelete]
        [Route("api/animal/delete/{id}")]
        public HttpResponseMessage DeleteAnimalById(int id)
        {
            var animalFromList = listAnimal.Find(s => s.Id == id);

            if (animalFromList == null)
            { Request.CreateResponse(HttpStatusCode.BadRequest, $"Animal with ID:{id} is not found"); }

            listAnimal.Remove(animalFromList);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
