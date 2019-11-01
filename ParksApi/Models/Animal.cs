using System.Collections.Generic;
using Newtonsoft.Json;


namespace ParksApi.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<LocalWildlife> Parks { get; set; }

        public Animal()
        {
            this.Parks = new HashSet<LocalWildlife>();
        }
    }
}