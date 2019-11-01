using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ParksApi.Models;

namespace ParksApi.Controllers
{
    [Route("api/parks")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private ParksApiContext _db;

        public ParksController(ParksApiContext db)
        {
            _db = db;
        }

        // GET api/parks
        [HttpGet]
        public ActionResult<IEnumerable<Park>> Get()
        {
            return _db.Parks.ToList();
        }

        // GET api/parks/5
        [HttpGet("{parkId:int}")]
        public ActionResult<Park> Get(int parkId)
        {
            return _db.Parks.Include(park => park.Fees).Include(park => park.VisitorCenterAddresses).Include(park => park.Animals).ThenInclude(wildlife => wildlife.Animal).FirstOrDefault(park => park.ParkId == parkId);
        }

        //GET api/parks/5/animals
        [HttpGet("{parkId:int}/animals")]
        public ActionResult<IEnumerable<Animal>> GetWildlife([FromRoute] int parkId)
        {
            Park thisPark = _db.Parks.Include(park => park.Animals).ThenInclude(wildlife => wildlife.Animal).FirstOrDefault(park => park.ParkId == parkId);
            return thisPark.Animals.Select(wl => wl.Animal).ToList();
        }

        // POST api/parks
        [HttpPost]
        public void Post([FromBody] Park park)
        {
            _db.Parks.Add(park);
            _db.SaveChanges();
        }

        // POST api/parks/5/animals
        [HttpPost("{parkId:int}/animals")]
        public void AddSighting([FromRoute] int parkId, [FromBody] Animal animal)
        {
            Animal dbAnimal = _db.Animals.FirstOrDefault(animalEntry => animalEntry.AnimalId == animal.AnimalId);
            if(dbAnimal == null)
            {
                _db.Animals.Add(animal);
            }
            _db.LocalWildlife.Add(new LocalWildlife(){ ParkId = parkId, AnimalId = animal.AnimalId });
            _db.SaveChanges();
        }


        // PUT api/parks/5
        [HttpPut("{parkId:int}")]
        public void Put(int parkId, [FromBody] Park park)
        {
            park.ParkId = parkId;
            _db.Entry(park).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/parks/5
        [HttpDelete("{parkId:int}")]
        public void Delete(int parkId)
        {
            Park thisPark = _db.Parks.FirstOrDefault(park => park.ParkId == parkId);
            _db.Parks.Remove(thisPark);
            _db.SaveChanges();
        }

        // DELETE api/parks/5/animals/2
        [HttpDelete("{parkId:int}/animals/{animalId:int}")]
        public void RemoveWildlifeReference([FromRoute] int parkId, [FromRoute] int animalId)
        {
            LocalWildlife joinEntry = _db.LocalWildlife.FirstOrDefault(entry => entry.ParkId == parkId && entry.AnimalId == animalId);
            _db.LocalWildlife.Remove(joinEntry);
            _db.SaveChanges();
        }
    }
}
