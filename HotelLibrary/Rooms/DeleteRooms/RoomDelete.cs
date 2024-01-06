using HotelLibrary.Build.Service;
using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.DeleteRooms
{
    public class RoomDelete
    {
        public static void DeleteRoom()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("| Radera rum från systemet  |");
            Console.WriteLine("| 0. gå tillbaka             |");
            Console.WriteLine("-----------------------------\n\n");

            ReadingAllRooms.ReadAllRoomFeatures();

            using (var dbRoomDelete = new HotelChamDbContext())
            {
                Console.Write("Ange id för rummet du vill ta bort: ");
                int roomId;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out roomId))
                    {
                        Console.WriteLine("ID existerar inte!");
                    }
                    else if (roomId == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                var roomToDelete = dbRoomDelete.Rooms.Find(roomId);
                dbRoomDelete.Rooms.Remove(roomToDelete);
                dbRoomDelete.SaveChanges();
                Console.WriteLine($"Rum {roomToDelete.RoomNumber}");

            }
            Console.WriteLine("Tryck på enter för att fortsätta...");
            Console.ReadKey();
        }
    }
}
