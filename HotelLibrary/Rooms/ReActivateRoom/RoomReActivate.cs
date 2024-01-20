﻿using HotelLibrary.Build.Service;
using HotelLibrary.Guests.ReadGuests;
using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.ReActivateRoom
{
    public class RoomReActivate
    {
        public static void GetBackRoom()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("| Återaktivera rum  |");
            Console.WriteLine("| 0. gå tillbaka    |");
            Console.WriteLine("--------------------\n\n");

            ReadNonActiveRoom.ReadNonActiveRooms();
            using (var dbGetBackRoom = new HotelChamDbContext())
            {

                int roomIdToReactivate;
                do
                {
                    Console.Write("\nAnge id för rummet du vill Återaktivera: ");
                    string roomIdToReactivateString = Console.ReadLine();

                    if (string.IsNullOrEmpty(roomIdToReactivateString))
                    {
                        Console.WriteLine("\nDu kan inte ange ett tomt svar...");
                        continue;
                    }
                    if (!int.TryParse(roomIdToReactivateString, out roomIdToReactivate))
                    {
                        Console.WriteLine("\nID existerar inte!");
                        continue;
                    }
                    else if (roomIdToReactivate == 0)
                    {
                        Console.Clear();
                        return;
                    }

                    var roomToGetBack = dbGetBackRoom.Rooms.Find(roomIdToReactivate);
                    if (roomToGetBack != null)
                    {
                        if (!roomToGetBack.IsRoomActive == true)
                        {
                            roomToGetBack.IsRoomActive = true;
                            dbGetBackRoom.SaveChanges();
                            Console.WriteLine($"\nRum: {roomToGetBack.RoomNumber} är nu aktiverad igen!");
                        }
                        else
                        {
                            Console.WriteLine($"Rum: {roomToGetBack.RoomNumber} är redan aktiv!!!");
                            continue;
                        }

                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\nRums ID: {roomIdToReactivate} existerar inte");
                    }

                } while (true);


            }
            Console.WriteLine("\nTryck på enter för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}