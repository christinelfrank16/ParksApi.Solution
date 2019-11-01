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

    }
}