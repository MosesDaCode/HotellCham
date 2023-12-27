using HotelLibrary.Build.Service;
using HotelLibrary.Rooms.ReadingRooms;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.UpdateRooms
{
    public class UpdateRoomPrice
    {
        public static void RoomPriceUpdating()
        {
            using (var dbRoomPriceUpdate = new HotelChamDbContext())
            {
                ReadingAllRooms.ReadAllRooms();
                int roomId;

                Console.Write("\nAnge RumsId ifrån ovan:");
                if (int.TryParse(Console.ReadLine(), out roomId))
                {
                    var roomPriceToUpdate = dbRoomPriceUpdate.Rooms
                   .Find(roomId);
                    if (roomPriceToUpdate != null)
                    {
                        Console.Clear();
                        var displayOldRoomPrice = dbRoomPriceUpdate.Rooms
                            .Where(r => r.RoomId == roomId)
                            .ToList();
                        Console.WriteLine("Nuvarande priset för rummet");
                        Console.WriteLine("-----------------------------");
                        foreach (var room in displayOldRoomPrice)
                        {
                            Console.WriteLine($"Rums nummer: {roomPriceToUpdate.RoomNumber}");
                            Console.WriteLine($"Pris per natt: {roomPriceToUpdate.PricePerNight} kr");

                            Console.WriteLine("-----------------------------");

                        }

                        Console.Write("\nAnge ett nytt pris per natt: ");
                        roomPriceToUpdate.PricePerNight = Convert.ToDecimal(Console.ReadLine());
                        if (roomPriceToUpdate.PricePerNight != 0)
                        {
                            dbRoomPriceUpdate.SaveChanges();
                            Console.WriteLine($"\nRum: {roomPriceToUpdate.RoomNumber} kostar nu {roomPriceToUpdate.PricePerNight}kr per natt.");
                            Console.WriteLine("Tryck på enter för att fortsätta...");
                        }
                        else if (roomPriceToUpdate.PricePerNight == 0)
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nDu måste ange ett giltigt pris!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID existerar inte!");
                    }
                }
                else if (roomId == 0)
                {
                    Console.Clear();
                    return;
                }
            }
        }
    }
}
