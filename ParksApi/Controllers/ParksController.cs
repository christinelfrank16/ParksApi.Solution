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

        // GET api/parks/search
        [HttpGet("search")]
        public ActionResult<IEnumerable<Park>> SearchParks(string name, string distinction, string state)
        {
            var query = _db.Parks.Include(park => park.VisitorCenterAddresses).AsQueryable();
            if(name != null)
            {
                query = query.Where(entry => entry.Name.ToLower().Contains(name.ToLower()));
            }
            if (distinction != null)
            {
                query = query.Where(entry => entry.Designation.ToLower().Contains(distinction.ToLower()));
            }
            if(state != null)
            {
                query = query.Where(entry => entry.VisitorCenterAddresses.Any(address => address.State == state));
            }
            return query.ToList();
        }

        // GET api/parks/5
        [HttpGet("{parkId:int}")]
        public ActionResult<Park> Get(int parkId)
        {
            return _db.Parks.Include(park => park.Fees).Include(park => park.VisitorCenterAddresses).Include(park => park.Animals).ThenInclude(wildlife => wildlife.Animal).FirstOrDefault(park => park.ParkId == parkId);
        }

        // GET api/parks/5/animals/search
        [HttpGet("{parkId:int}/animals/search")]
        public ActionResult<IEnumerable<Animal>> SearchParkAnimals([FromRoute] int parkId, string commonname, string type, string diet)
        {
            var query = _db.LocalWildlife.Include(wildlife => wildlife.Animal).Where(wildlife => wildlife.ParkId == parkId).Select(wildlife => wildlife.Animal).AsQueryable();
            if (commonname != null)
            {
                if(commonname.Contains(" "))
                {
                    List<string> searchterms = commonname.ToLower().Split(" ").ToList();
                    query = query.Where(animal => animal.CommonName.ToLower().Split(" ", default).ToList().Any(namevalue => searchterms.Contains(namevalue)));
                }
                else
                {
                    query = query.Where(animal => animal.CommonName.ToLower().Contains(commonname.ToLower()));
                }
            }
            if (type != null)
            {
                query = query.Where(animal => animal.Type.ToLower().Contains(type.ToLower()));
            }
            if (diet != null)
            {
                query = query.Where(animal => animal.Diet.ToLower().Contains(diet.ToLower()));
            }
            return query.ToList();
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
