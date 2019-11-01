using System.Collections.Generic;
using Newtonsoft.Json;

namespace ParksApi.Models
{
    public class Park
    {
        public int ParkId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public string OperatingHours { get; set; }
        public string ParkUrl { get; set; }

        public virtual ICollection<Address> VisitorCenterAddresses { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<LocalWildlife> Animals { get; set; }

        public Park()
        {
            this.VisitorCenterAddresses = new HashSet<Address>();
            this.Fees = new HashSet<Fee>();
            this.Animals = new HashSet<LocalWildlife>();
        }
    }
}