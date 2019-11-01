using Newtonsoft.Json;

namespace ParksApi.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int ParkId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Type { get; set; }
        [JsonIgnore]
        public virtual Park Park { get; set; }
    }
}