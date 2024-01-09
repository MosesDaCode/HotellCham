using HotelLibrary.Build.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Build.Service
{
    public class HotelDataInitializer
    {
        public void MigrateAndSeed(HotelChamDbContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedGuests(dbContext);
            SeedRoom(dbContext);
            dbContext.SaveChanges();
        }
        private void SeedGuests(HotelChamDbContext dbContext)
        {
            if (!dbContext.Guests.Any(g => g.GuestId == 1))
            {
                dbContext.Guests.Add(new Guest
                {
                    FirstName = "Mousa",
                    LastName = "Chammas",
                    Email = "cham.mos@hotmail.com",
                    Phone = "123456789",
                    IsGuestActive = true
                });
            }
            if (!dbContext.Guests.Any(g => g.GuestId == 2))
            {
                dbContext.Guests.Add(new Guest
                {
                    FirstName = "Snel",
                    LastName = "Hest",
                    Email = "snelhest@gmail.com",
                    Phone = "123456789",
                    Adress = "Svea vägen 23",
                    Country = "Sweden",
                    City = "Stockholm",
                    IsGuestActive = true
                });
            }
            if (!dbContext.Guests.Any(g => g.GuestId == 3))
            {
                dbContext.Guests.Add(new Guest
                {
                    FirstName = "Örjan",
                    LastName = "Öppnar",
                    Email = "öppnar.örjan@gmail.com",
                    Phone = "123456789",
                    Adress = "Sten Vägen 124",
                    Country = "Sweden",
                    City = "Norrland",
                    IsGuestActive = true
                });
            }
            if (!dbContext.Guests.Any(g => g.GuestId == 4))
            {
                dbContext.Guests.Add(new Guest
                {
                    FirstName = "Joakim",
                    LastName = "Nilsson",
                    Email = "jocke.nisse@hotmail.com",
                    Phone = "123456789",
                    Adress = "S:t görans gatan 2",
                    Country = "Sweden",
                    City = "Stockholm",
                    IsGuestActive = true
                });
            }
        }
        private void SeedRoom(HotelChamDbContext dbContext)
        {
            if (!dbContext.Rooms.Any(r => r.RoomId == 1))
            {
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 101,
                    Capacity = 1,
                    IsOccupied = false,
                    PricePerNight = 780,
                    RoomType = "Enkelrum",
                    Description = "Ett Trevligt singelrum med utsikt över Mälarsjön",
                    IsRoomActive = true,
                    RoomSize = 13
                });
            }
            if (!dbContext.Rooms.Any(r => r.RoomId  == 2))
            {
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 102,
                    Capacity = 1,
                    IsOccupied = false,
                    PricePerNight = 780,
                    RoomType = "Enkelrum",
                    Description = "Ett Trevligt singelrum med utsikt över Mälarsjön",
                    IsRoomActive = true,
                    RoomSize = 15
                });
            }
            if (!dbContext.Rooms.Any(r => r.RoomId == 3))
            {
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 103,
                    Capacity = 3,
                    IsOccupied = false,
                    PricePerNight = 1090,
                    RoomType = "Dubbelrum",
                    Description = "Ett Trevligt dubbelrum med utsikt över Mälarsjön, inkluderar en dubbelsäng med en större dusch.",
                    IsRoomActive = true,
                    RoomSize = 24
                });
            }
            if (!dbContext.Rooms.Any(r => r.RoomId == 4))
            {
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 104,
                    Capacity = 4,
                    IsOccupied = false,
                    PricePerNight = 1090,
                    RoomType = "Dubbelrum",
                    Description = "Ett Trevligt dubbelrum med utsikt över Mälarsjön, inkluderar en dubbelsäng med en större dusch.",
                    IsRoomActive = true, 
                    RoomSize= 27
                });
            }
        }
    }
}
