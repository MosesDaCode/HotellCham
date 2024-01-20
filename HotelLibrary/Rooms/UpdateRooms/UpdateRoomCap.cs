using HotelLibrary.Build.Service;
using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.UpdateRooms
{
    public class UpdateRoomCap
    {
        public static void UpdatingRoomCapacity()
        {
            using (var dbRoomCapUpdate = new HotelChamDbContext())
            {
                ReadingAllRooms.ReadAllRoomFeatures();
                int roomId;

                Console.Write("\nAnge RumsId ifrån ovan:");
                if (int.TryParse(Console.ReadLine(), out roomId))
                {
                    var roomCapToUpdate = dbRoomCapUpdate.Rooms
                   .Find(roomId);
                    if (roomCapToUpdate != null)
                    {
                        Console.Clear();
                        var displayOldRoomCap = dbRoomCapUpdate.Rooms
                            .Where(r => r.RoomId == roomId)
                            .ToList();
                        Console.WriteLine("Nuvarande antal gäster tillåts bo i rummet");
                        Console.WriteLine("-----------------------------");
                        foreach (var room in displayOldRoomCap)
                        {
                            Console.WriteLine($"Rumsnummer: {roomCapToUpdate.RoomNumber}");
                            Console.WriteLine($"Antal gäster: {roomCapToUpdate.Capacity}");

                            Console.WriteLine("-----------------------------");

                        }

                        Console.WriteLine("\n(1-4 gäster)");
                        Console.Write("Ange antalet gäster: ");
                        roomCapToUpdate.Capacity = Convert.ToInt32(Console.ReadLine());
                        if (roomCapToUpdate.Capacity != 0 && roomCapToUpdate.Capacity >= 1 && roomCapToUpdate.Capacity < 5)
                        {
                            dbRoomCapUpdate.SaveChanges();
                            Console.WriteLine($"\nRum: {roomCapToUpdate.RoomNumber}, kan nu ha {roomCapToUpdate.Capacity} gäster!");
                        }
                        else if (roomCapToUpdate.Capacity == 0)
                        {
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nDu måste ange ett antal emellan (1-4 gäster)");
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
 

