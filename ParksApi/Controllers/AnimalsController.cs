using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ParksApi.Models;

namespace ParksApi.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private ParksApiContext _db;

        public AnimalsController(ParksApiContext db)
        {
            _db = db;
        }

        // GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            return _db.Animals.ToList();
        }

        // GET api/animals/5
        [HttpGet("{animalId:int}")]
        public ActionResult<Animal> Get(int animalId)
        {
            Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == animalId);
            return thisAnimal;
        }

        // GET api/animals/5/parks
        [HttpGet("{animalId:int}/parks")]
        public ActionResult<IEnumerable<Park>> GetParks(int animalId)
        {
            List<int> parkIds = _db.LocalWildlife.Where(entry => entry.AnimalId == animalId).Select(entry => entry.ParkId).ToList();
            List<Park> parkList = _db.Parks.Where(park => parkIds.Contains(park.ParkId)).ToList();
            return parkList;
        }

        // POST api/animals
        [HttpPost]
        public void Post([FromBody] Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
        }

        // POST api/animals/5/parks
        [HttpPost("{animalId:int}/parks")]
        public void AddSighting([FromRoute] int animalId, [FromBody] Park park)
        {
            Park dbPark = _db.Parks.FirstOrDefault(parkEntry => parkEntry.ParkId == park.ParkId);
            if (dbPark == null)
            {
                _db.Parks.Add(park);
            }
            _db.LocalWildlife.Add(new LocalWildlife() { ParkId = park.ParkId, AnimalId = animalId });
            _db.SaveChanges();
        }


        // PUT api/animals/5
        [HttpPut("{animalId:int}")]
        public void Put(int animalId, [FromBody] Animal animal)
        {
            animal.AnimalId = animalId;
            _db.Entry(animal).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/animals/5
        [HttpDelete("{animalId:int}")]
        public void Delete(int animalId)
        {
            Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == animalId);
            _db.Animals.Remove(thisAnimal);
            _db.SaveChanges();
        }

        // DELETE api/animals/5/parks/2
        [HttpDelete("{animalId:int}/parks/{parkId:int}")]
        public void RemoveWildlifeReference([FromRoute] int animalId, [FromRoute] int parkId)
        {
            LocalWildlife joinEntry = _db.LocalWildlife.FirstOrDefault(entry => entry.ParkId == parkId && entry.AnimalId == animalId);
            _db.LocalWildlife.Remove(joinEntry);
            _db.SaveChanges();
        }
    }
}
