using HotelLibrary.Build.Service;
using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.UpdateRooms
{
    public class UpdateRoomType
    {
        public static void RoomTypeUpdating()
        {
            using (var dbRoomTypeUpdate = new HotelChamDbContext())
            {
                ReadingAllRooms.ReadAllRoomFeatures();
                int roomId;

                Console.Write("\nAnge RumsId ifrån ovan:");
                if (int.TryParse(Console.ReadLine(), out roomId))
                {
                    var roomTypeToUpdate = dbRoomTypeUpdate.Rooms
                   .Find(roomId);
                    if (roomTypeToUpdate != null)
                    {
                        Console.Clear();
                        var displayOldRoomType = dbRoomTypeUpdate.Rooms
                            .Where(r => r.RoomId == roomId)
                            .ToList();
                        Console.WriteLine("Nuvarande rums typen");
                        Console.WriteLine("-----------------------------");
                        foreach (var room in displayOldRoomType)
                        {
                            Console.WriteLine($"Rums nummer: {roomTypeToUpdate.RoomNumber}");
                            Console.WriteLine($"Rums typ: {roomTypeToUpdate.RoomType}");

                            Console.WriteLine("-----------------------------");

                        }

                        roomTypeToUpdate.RoomType = CreateRoom.RoomTypeSwitch();
                        if (roomTypeToUpdate.RoomType != null && roomTypeToUpdate.RoomType != "0")
                        {
                            dbRoomTypeUpdate.SaveChanges();
                            Console.WriteLine($"Rums typen har ändrats till {roomTypeToUpdate.RoomType}");
                            Console.WriteLine("Tryck på enter för att forstätta...");
                        }
                    }
                }
                else if (roomId == 0)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("ID existerar inte!");
                }
            }
        }
    }
}
