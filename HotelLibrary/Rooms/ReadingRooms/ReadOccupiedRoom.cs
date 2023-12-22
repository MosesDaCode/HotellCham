using HotelLibrary.Build.HotelData;
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
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("| Se  upptagna rum      |");
            Console.WriteLine("| 0. gå tillbaka        |");
            Console.WriteLine("------------------------\n\n");

            using (var dbRoom = new HotelChamDbContext())
            {
                var occupiedRooms = dbRoom.Rooms
                    .Where(room => room.IsOccupied == true)
                    .OrderBy(roomIsOccupied => roomIsOccupied.RoomId)
                    .ToList();
                if (occupiedRooms.Any())
                {
                    Console.WriteLine("Lista av upptagna rum");
                    Console.WriteLine("----------------------------------------");
                    foreach (var room in occupiedRooms)
                    {
                        Console.WriteLine($"RumsID: {room.RoomId}");
                        Console.WriteLine($"Rumsnummer: {room.RoomNumber}");
                        Console.WriteLine($"Rums kapacitet: {room.Capacity}");
                        Console.WriteLine($"Pris per natt: {room.PricePerNight}");
                        Console.WriteLine($"Rums typ: {room.RoomType}");
                        Console.WriteLine($"Rums beskrivning: {room.Description}");
                        Console.WriteLine("----------------------------------------");

                    }
                }
                else
                {
                    Console.WriteLine("Alla rum verkar Lediga.");
                    Console.WriteLine("Tryck på enter för att gå tillbaka...");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
