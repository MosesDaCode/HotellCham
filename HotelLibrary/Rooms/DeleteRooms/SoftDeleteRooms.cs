using HotelLibrary.Build.Service;
using HotelLibrary.Guests.ReadGuests;
using HotelLibrary.Rooms.ReadingRooms;
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

            ReadingAvailableRoom.ReadAvailableRooms();
            using (var dbSoftDeleteRoom = new HotelChamDbContext())
            {

                Console.Write("Ange id för rummet du vill ta bort: ");
                int roomIdToDeactivate;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out roomIdToDeactivate))
                    {
                        Console.WriteLine("\nOgiltigt ID!!!!");
                        Console.Write("Ange id för rummet du vill ta bort: ");
                    }
                    else if (roomIdToDeactivate == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        var roomToSoftDelete = dbSoftDeleteRoom.Rooms.Find(roomIdToDeactivate);
                        if (roomToSoftDelete == null)
                        {
                            Console.WriteLine("\nRummet existerar inte!!");
                        }
                        else if (roomToSoftDelete.IsRoomActive == false)
                        {
                            Console.WriteLine("\nRummet är redan avaktiverat!!!");
                        }
                        else
                        {
                            roomToSoftDelete.IsRoomActive = false;
                            dbSoftDeleteRoom.SaveChanges();
                            Console.WriteLine($"\nRum: {roomToSoftDelete.RoomNumber} är nu avaktiverad!");
                        }
                        break;
                    }
                } while (true);
            }
            Console.WriteLine("\nTryck på enter för att fortsätta...");
            Console.ReadKey();
        }
    }
}
