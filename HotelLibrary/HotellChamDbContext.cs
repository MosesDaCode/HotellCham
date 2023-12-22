using Microsoft.EntityFrameworkCore;
using HotelLibrary.Rooms;
using HotelLibrary.Guests;
using HotelLibrary.Bookings;
using HotelLibrary.Invoices;

namespace HotelLibrary
{
    public class HotellChamDbContext : DbContext
    {
        public HotellChamDbContext()
        {
        }
        public HotellChamDbContext(DbContextOptions<HotellChamDbContext> options) : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HotellChamDB;Trusted_Connection=True;");
        }
    }
}
