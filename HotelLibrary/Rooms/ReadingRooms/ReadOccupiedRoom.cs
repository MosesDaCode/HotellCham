using HotelLibrary.Build.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.ReadingRooms
{
    public class ReadOccupiedRoom
    {
        public static void ReadOccupiedRooms()
        {
            using (var dbRoom = new HotelChamDbContext())
            {
                var occupiedRooms = dbRoom.Rooms
                    .Where(room => room.IsOccupied == true)
                    .OrderBy(roomIsOccupied => roomIsOccupied.RoomId)
                    .ToList();
                if (occupiedRooms.Any())
                {
                    Console.WriteLine("Lista av upptagna rum");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    foreach (var room in occupiedRooms)
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
                    Console.WriteLine("\nAlla rum verkar Lediga.");
                }
            }
        }
    }
}
