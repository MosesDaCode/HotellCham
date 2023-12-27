using HotelLibrary.Build.Service;
using HotelLibrary.Guests.ReadGuests;
using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms
{
    public class ReActivateRoom
    {
        public static void GetBackRoom()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("| Återaktivera rim  |");
            Console.WriteLine("| 0. gå tillbaka    |");
            Console.WriteLine("--------------------\n\n");

            ReadNonActiveRoom.ReadNonActiveRooms();
            using (var dbGetBackRoom = new HotelChamDbContext())
            {

                Console.Write("\nAnge id för rummet du vill Återaktivera: ");
                int roomIdToReactivate;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out roomIdToReactivate))
                    {
                        Console.WriteLine("\nID existerar inte!");
                    }
                    else if (roomIdToReactivate == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                var roomToGetBack = dbGetBackRoom.Rooms.Find(roomIdToReactivate);
                roomToGetBack.IsRoomActive = true;
                dbGetBackRoom.SaveChanges();
                Console.WriteLine($"\nRum: {roomToGetBack.RoomNumber} är nu aktiverad igen!");
            }
            Console.WriteLine("\nTryck på enter för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
