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
        [HttpGet("{id}")]
        public ActionResult<Park> Get(int id)
        {
            return _db.Parks.Include(park => park.Fees).Include(park => park.VisitorCenterAddresses).Include(park => park.Animals).ThenInclude(wildlife => wildlife.Animal).FirstOrDefault(park => park.ParkId == id);
        }

        //GET api/parks/5/animals
        [HttpGet("{id}/animals")]
        public ActionResult<IEnumerable<Animal>> GetWildlife(int id)
        {
            Park thisPark = _db.Parks.Include(park => park.Animals).ThenInclude(wildlife => wildlife.Animal).FirstOrDefault(park => park.ParkId == id);
            return thisPark.Animals.Select(wl => wl.Animal).ToList();
        }

        // POST api/parks
        [HttpPost]
        public void Post([FromBody] Park park)
        {
            _db.Parks.Add(park);
            _db.SaveChanges();
        }


        // PUT api/parks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Park park)
        {
            park.ParkId = id;
            _db.Entry(park).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/parks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Park thisPark = _db.Parks.FirstOrDefault(park => park.ParkId == id);
            _db.Parks.Remove(thisPark);
            _db.SaveChanges();
        }
    }
}
