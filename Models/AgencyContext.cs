using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace webapp_travel_agency.Models
{
    public class AgencyContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<AgeRange>? AgeRanges { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Destination>? Destinations { get; set; }
        public DbSet<Traveler>? Travelers { get; set; }
        public DbSet<TravelStage>? TravelStages { get; set; }
        public DbSet<Trip>? Trips { get; set; }
        public DbSet<Buyer>? Buyers { get; set; }


        public AgencyContext()
        {
        }

        public AgencyContext(DbContextOptions<AgencyContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(
       DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=localhost;" +
                "Initial Catalog=db_travel_agency;" +
                "Integrated Security=True";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
