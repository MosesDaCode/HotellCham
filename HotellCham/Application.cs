using HotelLibrary;
using HotelLibrary.HotelData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellCham
{
    public class Application
    {
        public void Go()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<HotelChamDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new HotelChamDbContext(options.Options))
            {
                var dataInitiaizer = new HotelDataInitializer();
                dataInitiaizer.MigrateAndSeed(dbContext);
            }
        }
    }
}
