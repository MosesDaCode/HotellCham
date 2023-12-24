using HotelLibrary.Build.Service;
using HotelLibrary.Guests.ReadGuests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.DeleteRooms
{
    public class SoftDeleteRooms
    {
        public static void SoftDeleteRoom()
        {

            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("| Avaktivera rum    |");
            Console.WriteLine("| 0. gå tillbaka    |");
            Console.WriteLine("--------------------\n\n");

            ReadingActiveGuest.ReadActiveGuests();
            using (var dbSoftDeleteRoom = new HotelChamDbContext())
            {

                Console.Write("Ange id för gästen du vill ta bort: ");
                int roomIdToDeactivate;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out roomIdToDeactivate))
                    {
                        Console.WriteLine("ID existerar inte!");
                    }
                    else if (roomIdToDeactivate == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                var roomToSoftDelete = dbSoftDeleteRoom.Rooms.Find(roomIdToDeactivate);
                roomToSoftDelete.IsRoomActive = false;
                dbSoftDeleteRoom.SaveChanges();
                Console.WriteLine("Rummet är nu avaktiverad!");
            }
            Console.WriteLine("Tryck på enter för att fortsätta...");
            Console.ReadKey();
        }
    }
}
