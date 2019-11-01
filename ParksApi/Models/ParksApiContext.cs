using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
    public class ParksApiContext : DbContext
    {
        public ParksApiContext(DbContextOptions<ParksApiContext> options)
            : base(options){ }

        public DbSet<Park> Parks { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<LocalWildlife> LocalWildlife { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>()
                .HasData(
                    new Animal { AnimalId = 1, CommonName = "American Bison", ScientificName = "Bison bison", Description = "Often mistaken for buffaloes, these animals are the heaviest land animals in North America", Diet = "Herbivore", Type = "Mammal" },
                    new Animal { AnimalId = 2, CommonName = "Red Fox", ScientificName = "Vulpes vulpes", Description = "Legendary for intelligence and cunning, red foxes are known for their red body and white underside and tipped tail; they live in many diverse habitats", Diet = "Omnivore", Type = "Mammal" },
                    new Animal { AnimalId = 3, CommonName = "American Crow", ScientificName = "Corvus brachyrhynchos", Description = "A common bird found across much of North America, it is all black with iridescent feathers", Diet = "Omnivore", Type = "Bird" },
                    new Animal { AnimalId = 4, CommonName = "Mallard", ScientificName = "Anas platyrhynchos", Description = "Males (drakes) have a glossy green head and are grey on their wings and belly, while the females (hens or ducks) have mainly brown-speckled plumage", Diet = "Omnivore", Type = "Bird" },
                    new Animal { AnimalId = 5, CommonName = "Spotted Salamander", ScientificName = "Ambystoma maculatum", Description = "Common in the eastern United States, it is stout in body and mostly black with two uneven rows of yellowish spots", Diet = "Carnivore", Type = "Amphibian" },
                    new Animal { AnimalId = 6, CommonName = "Texas Horned Lizard", ScientificName = "Phrynosoma cornutum", Description = "Similar to other lizards in its species, it is patterned and brown-toned with a spikey body, however it stands out as the largest bodied of its kind", Diet = "Carnivore", Type = "Amphibian" }
                );

            builder.Entity<Park>()
                .HasData(
                    new Park{ ParkId = 1, Name = "Yellowstone", Designation = "National Park", Description = "A large seasonal park with fountains, breath-taking views and open spaces to explore!", OperatingHours = "24-hrs All Days", ParkUrl = "https://www.nps.gov/yell/index.htm"},
                    new Park { ParkId = 2, Name = "Zion National Park", Designation = "National Park", Description = "Known for its massive sandstone cliffs of cream, pink and red contrasting agains a bright blue sky, it is an area full of history about native people and pioneers", OperatingHours = "24-hrs All Days", ParkUrl = "https://www.nps.gov/zion/index.htm" },
                    new Park { ParkId = 3, Name = "Tryon Creek State National Area", Designation = "State Park", Description = "A well wooded park with many trails used for horse-back riding, hiking, running and walking", OperatingHours = "7am-5pm, changes seasonally", ParkUrl = "https://oregonstateparks.org/index.cfm?do=parkPage.dsp_parkPage&parkId=103" }
                );

            builder.Entity<Address>()
            .HasData(
                new Address{AddressId = 1, ParkId = 1, Line1 ="Grand Loop Road", Line2 = "Yellowstone National Park, WY 82190", Line3 = "", City = "Yellowstone National Park", State = "WY", Zipcode = "82190", Type = "Physical Address"},
                new Address { AddressId = 2, ParkId = 1, Line1 = "Chamber of Commerce of West Yellowstone", Line2 = "30 Yellowstone Avenue", Line3 = "West Yellowstone, MT 59758", City = "West Yellowstone", State = "MT", Zipcode = "59758", Type = "Physical Address" },
                new Address { AddressId = 3, ParkId = 1, Line1 = "PO Box 168", Line2 = "Yellowstone National Park, WY 82190", Line3 = "", City = "Yellowstone National Park", State = "WY", Zipcode = "82190", Type = "Mailing Address" },
                new Address { AddressId = 4, ParkId = 2, Line1 = "1 Zion Park Blvd", Line2 = "State Route 9", Line3 = "Springdale, UT 84767", City = "Springdale", State = "UT", Zipcode = "84767", Type = "Physical Address" },
                new Address { AddressId = 5, ParkId = 3, Line1 = "11321 SW Terwilliger Blvd", Line2 = "Portland, OR 97219", Line3 = "", City = "Portland", State = "OR", Zipcode = "97219", Type = "Physical Address" }
            );
            builder.Entity<Fee>()
           .HasData(
               new Fee{FeeId = 1, ParkId = 1, Name ="Yellowstone Private Vehicle, 7-day", Description = "Good for entry of private vehicle and all occupants to Yellowstone for 7 days from date of purchase", Cost = 35.00},
               new Fee { FeeId = 2, ParkId = 2, Name = "Zion Private Vehicle, 7-day", Description = "Admits private, non-commercial vehicles and all occupants", Cost = 35.00 },
               new Fee { FeeId = 3, ParkId = 2, Name = "Zion Per Person, 7-day", Description = "Admits a single individual with no car; includes bicyclists, hikers and pedestrians", Cost = 20.00 },
               new Fee { FeeId = 4, ParkId = 2, Name = "Zion Senior Annual Pass", Description = "Admits one senior to all federal fee areas for one year from date of purchase", Cost = 20.00 },
               new Fee { FeeId = 5, ParkId = 2, Name = "Zion Annual Pass", Description = "Admits a single individual for one year from date of purchase", Cost = 50.00 },
               new Fee { FeeId = 6, ParkId = 1, Name = "Yellowstone Per Person", Description = "Good for single individual entry to Yellowstone for 7 days from date of purchase", Cost = 20.00 },
               new Fee { FeeId = 7, ParkId = 1, Name = "Yellowstone Annual Pass", Description = "Admits entrance to Yellowstone for one year. When travelling by snowcoach or shuttle, it admits the holder and up to 3 additional individuals", Cost = 70.00 },
               new Fee { FeeId = 8, ParkId = 1, Name = "Yellowstone Annual Pass", Description = "Admits entrance to Yellowstone for one year. When travelling by snowcoach or shuttle, it admits the holder and up to 3 additional individuals", Cost = 70.00 }
           );
        }

    }
}