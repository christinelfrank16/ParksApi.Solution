using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ParksApi.Models;

namespace ParksApi.Controllers
{
    [Route("api/parks/{parkId:int}/addresses")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private ParksApiContext _db;

        public AddressesController(ParksApiContext db)
        {
            _db = db;
        }

        // GET api/parks/5/addresses
        [HttpGet]
        public ActionResult<IEnumerable<Address>> Get([FromRoute] int parkId)
        {
            Park thisPark = _db.Parks.Include(park => park.VisitorCenterAddresses).FirstOrDefault(park => park.ParkId == parkId);
            return thisPark.VisitorCenterAddresses.ToList();
        }

        // GET api/parks/5/addresses/1
        [HttpGet("{addressId}")]
        public ActionResult<Address> Get(int addressId, [FromRoute] int parkId)
        {
            Park thisPark = _db.Parks.Include(park => park.VisitorCenterAddresses).FirstOrDefault(park => park.ParkId == parkId);
            return thisPark.VisitorCenterAddresses.FirstOrDefault(address => address.AddressId == addressId);
        }

        // POST api/parks/5/addresses
        [HttpPost]
        public void Post([FromRoute] int parkId, [FromBody] Address address)
        {
            address.ParkId = parkId;
            _db.Addresses.Add(address);
            _db.SaveChanges();
        }

        // PUT api/parks/5/addresses/1
        [HttpPut("{addressId}")]
        public void Put(int addressId, [FromRoute] int parkId, [FromBody] Address address)
        {
            address.AddressId = addressId;
            address.ParkId = parkId;
            _db.Entry(address).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/parks/5/addresses/1
        [HttpDelete("{addressId}")]
        public void Delete(int addressId)
        {
            Address thisAddress = _db.Addresses.FirstOrDefault(address => address.AddressId == addressId);
            _db.Addresses.Remove(thisAddress);
            _db.SaveChanges();
        }
    }
}
