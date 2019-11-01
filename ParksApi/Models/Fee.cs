using Newtonsoft.Json;

namespace ParksApi.Models
{
    public class Fee
    {
        public int FeeId { get; set; }
        public int ParkId { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual Park Park { get; set; }
    }
}