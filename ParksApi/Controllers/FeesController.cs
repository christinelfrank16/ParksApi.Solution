using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ParksApi.Models;

namespace ParksApi.Controllers
{
    [Route("api/parks/{parkId:int}/fees")]
    [ApiController]
    public class FeesController : ControllerBase
    {
        private ParksApiContext _db;

        public FeesController(ParksApiContext db)
        {
            _db = db;
        }

        // GET api/parks/5/fees
        [HttpGet]
        public ActionResult<IEnumerable<Fee>> Get([FromRoute] int parkId)
        {
            Park thisPark = _db.Parks.Include(park => park.Fees).FirstOrDefault(park => park.ParkId == parkId);
            return thisPark.Fees.ToList();
        }

        // GET api/parks/5/fees/1
        [HttpGet("{feeId}")]
        public ActionResult<Fee> Get(int feeId, [FromRoute] int parkId)
        {
            Park thisPark = _db.Parks.Include(park => park.Fees).FirstOrDefault(park => park.ParkId == parkId);
            return thisPark.Fees.FirstOrDefault(fee => fee.FeeId == feeId);
        }

        // POST api/parks/5/fees
        [HttpPost]
        public void Post([FromRoute] int parkId, [FromBody] Fee fee)
        {
            fee.ParkId = parkId;
            _db.Fees.Add(fee);
            _db.SaveChanges();
        }

        // PUT api/parks/5/fees/1
        [HttpPut("{feeId}")]
        public void Put(int feeId, [FromRoute] int parkId, [FromBody] Fee fee)
        {
            fee.FeeId = feeId;
            fee.ParkId = parkId;
            _db.Entry(fee).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/parks/5/fees/1
        [HttpDelete("{feeId}")]
        public void Delete(int feeId)
        {
            Fee thisFee = _db.Fees.FirstOrDefault(fee => fee.FeeId == feeId);
            _db.Fees.Remove(thisFee);
            _db.SaveChanges();
        }
    }
}
