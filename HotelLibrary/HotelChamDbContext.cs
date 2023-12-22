using Microsoft.EntityFrameworkCore;
using HotelLibrary.HotelData;

namespace HotelLibrary
{
    public class HotelChamDbContext : DbContext
    {
        public HotelChamDbContext()
        {
        }
        public HotelChamDbContext(DbContextOptions<HotelChamDbContext> options) : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=HotellChamDB;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }
    }
}
