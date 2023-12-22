using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.ReadingRooms
{
    public class ReadingAvailableRoom
    {
        public static void ReadAvailableRooms()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("| Se Tillgängliga rum    |");
            Console.WriteLine("| 0. gå tillbaka         |");
            Console.WriteLine("-------------------------\n\n");

            using (var dbRoom = new HotelChamDbContext())
            {
                var activeRooms = dbRoom.Rooms
                    .Where(room => room.IsOccupied == true || room.IsRoomActive == true)
                    .OrderBy(roomIsActive => roomIsActive.RoomId)
                    .ToList();
                if (activeRooms.Any())
                {
                    Console.WriteLine("Lista av tillgängliga rum");
                    Console.WriteLine("----------------------------------------");
                    foreach (var room in activeRooms)
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
                    Console.WriteLine("Inga rum är tíllgängliga.");
                    Console.WriteLine("Tryck på enter för att gå tillbaka...");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
       
        
    }
}
