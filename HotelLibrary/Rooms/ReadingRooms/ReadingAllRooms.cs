using HotelLibrary.Build.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.ReadingRooms
{
    public class ReadingAllRooms
    {
        public static void ReadAllRooms()
        {
            using (var dbRoom = new HotelChamDbContext())
            {

                var activeRooms = dbRoom.Rooms
                    .ToList();
                if (activeRooms.Any())
                {
                    Console.WriteLine("Lista av alla rum");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    foreach (var room in activeRooms)
                    {
                        Console.WriteLine($"RumsID: {room.RoomId}");
                        Console.WriteLine($"Rumsnummer: {room.RoomNumber}");
                        Console.WriteLine($"Antal gäster: {room.Capacity}");
                        Console.WriteLine($"Pris per natt: {room.PricePerNight}");
                        Console.WriteLine($"Rums typ: {room.RoomType}");
                        Console.WriteLine($"Rums beskrivning: {room.Description}");
                        Console.WriteLine("---------------------------------------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("\nInga rum är tíllgängliga.");
                }
            }
        }
    }
}
