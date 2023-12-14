using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Booking;
using Library.Guest;
using Library.Invoice;
using Library.Room;
using Microsoft.EntityFrameworkCore;
namespace HotellCham
{
    public class HotellChamDbContext : DbContext
    {
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
