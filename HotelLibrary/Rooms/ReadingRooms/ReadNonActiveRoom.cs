using HotelLibrary.Build.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.ReadingRooms
{
    public class ReadNonActiveRoom
    {
        public static void ReadNonActiveRooms()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("| Se icke aktiva rum    |");
            Console.WriteLine("| 0. gå tillbaka        |");
            Console.WriteLine("------------------------\n\n");

            using (var dbRoom = new HotelChamDbContext())
            {
                var nonActiveRooms = dbRoom.Rooms
                    .Where(room => room.IsRoomActive == false)
                    .OrderBy(roomIsNonActive => roomIsNonActive.RoomId)
                    .ToList();
                if (nonActiveRooms.Any())
                {
                    Console.WriteLine("Lista av icke aktiva rum");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    foreach (var room in nonActiveRooms)
                    {
                        Console.WriteLine($"RumsID: {room.RoomId}");
                        Console.WriteLine($"Rumsnummer: {room.RoomNumber}");
                        Console.WriteLine($"Rums kapacitet: {room.Capacity}");
                        Console.WriteLine($"Pris per natt: {room.PricePerNight}");
                        Console.WriteLine($"Rums typ: {room.RoomType}");
                        Console.WriteLine($"Rums beskrivning: {room.Description}");
                        Console.WriteLine("---------------------------------------------------------------------------");

                    }
                }
                else
                {
                    Console.WriteLine("Alla rum verkar vara aktiva.");
                    Console.WriteLine("Tryck på enter för att gå tillbaka...");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
