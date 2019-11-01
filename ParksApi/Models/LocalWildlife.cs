namespace ParksApi.Models
{
    public class LocalWildlife
    {
        public int LocalWildlifeId { get; set; }
        public int ParkId { get; set; }
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
        public Park Park { get; set; }
    }
}
