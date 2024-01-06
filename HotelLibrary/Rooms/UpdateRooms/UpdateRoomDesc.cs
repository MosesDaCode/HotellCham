﻿using HotelLibrary.Build.Service;
using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.UpdateRooms
{
    public class UpdateRoomDesc
    {
        public static void RoomDescriptionUpdate()
        {
            using (var dbRoomDescUpdate = new HotelChamDbContext())
            {
                ReadingAllRooms.ReadAllRoomFeatures();
                int roomId;

                Console.Write("\nAnge RumsId ifrån ovan:");
                if (int.TryParse(Console.ReadLine(), out roomId))
                {
                    var roomDescToUpdate = dbRoomDescUpdate.Rooms
                   .Find(roomId);
                    if (roomDescToUpdate != null)
                    {
                        Console.Clear();
                        var displayOldRoomDesc = dbRoomDescUpdate.Rooms
                            .Where(r => r.RoomId == roomId)
                            .ToList();
                        Console.WriteLine("Nuvarande rums beskrivning");
                        Console.WriteLine("-----------------------------");
                        foreach (var room in displayOldRoomDesc)
                        {
                            Console.WriteLine($"Rums nummer: {roomDescToUpdate.RoomNumber}");
                            Console.WriteLine($"Rums beskrivning: {roomDescToUpdate.Description}");

                            Console.WriteLine("-----------------------------");
                        }
                        Console.Write("\nSkriv en ny rums beskrivning: ");
                        roomDescToUpdate.Description = Console.ReadLine();
                        if (roomDescToUpdate.Description != "0")
                        {
                            dbRoomDescUpdate.SaveChanges();
                            Console.WriteLine($"\nRum: {roomDescToUpdate.RoomNumber} är nu {roomDescToUpdate.RoomSize} KVM.");
                        }
                        else if (roomDescToUpdate.Description == "0")
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nDu måste ange ett giltigt pris!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID existerar inte!");
                    }
                }
            }
        }
    }
}
