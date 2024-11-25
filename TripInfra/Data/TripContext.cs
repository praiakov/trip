using Microsoft.EntityFrameworkCore;
using TripDomain.Entities;

namespace TripInfra
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
          : base(options)
        { }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<StopOvers> StopOvers { get; set; }
    }
}
