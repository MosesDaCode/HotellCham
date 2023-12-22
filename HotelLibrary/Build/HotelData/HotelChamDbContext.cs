using Microsoft.EntityFrameworkCore;

namespace HotelLibrary.Build.HotelData
{

    public class HotelChamDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public HotelChamDbContext()
        {
        }
        public HotelChamDbContext(DbContextOptions<HotelChamDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HotellChamDB;Trusted_Connection=True;");
        }
    }
}
