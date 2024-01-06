using HotelLibrary.Build.Service;
using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.UpdateRooms
{
    public class UpdateRoomSize
    {
        public static void RoomSizeUpdating()
        {
            using (var dbRoomSizeUpdate = new HotelChamDbContext())
            {
                ReadingAllRooms.ReadAllRoomFeatures();
                int roomId;

                Console.Write("\nAnge RumsId ifrån ovan:");
                if (int.TryParse(Console.ReadLine(), out roomId) && roomId != 0)
                {
                    var roomSizeToUpdate = dbRoomSizeUpdate.Rooms
                   .Find(roomId);
                    if (roomSizeToUpdate != null)
                    {
                        Console.Clear();
                        var displayOldRoomSize = dbRoomSizeUpdate.Rooms
                            .Where(r => r.RoomId == roomId)
                            .ToList();
                        Console.WriteLine("Nuvarande rums typen");
                        Console.WriteLine("-----------------------------");
                        foreach (var room in displayOldRoomSize)
                        {
                            Console.WriteLine($"Rums nummer: {roomSizeToUpdate.RoomNumber}");
                            Console.WriteLine($"Rums storlek: {roomSizeToUpdate.RoomSize} KVM");

                            Console.WriteLine("-----------------------------");
                        }
                        Console.Write("\nAnge en ny storlek på rummet: ");
                        roomSizeToUpdate.RoomSize = Convert.ToInt32(Console.ReadLine());
                        if (roomSizeToUpdate.RoomSize != 0)
                        {
                            dbRoomSizeUpdate.SaveChanges();
                            Console.WriteLine($"\nRum: {roomSizeToUpdate.RoomNumber} är nu {roomSizeToUpdate.RoomSize} KVM.");
                            Console.WriteLine("Tryck på enter för att fortsätta...");
                        }
                        else if (roomSizeToUpdate.PricePerNight == 0)
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nDu måste ange en giltigt storlek!");
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
