﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.ReadingRooms
{
    public class DisplayReadRoomMenu
    {
        public static void ReadRooms()
        {
            bool isReadingRooms = true;
            while (isReadingRooms)
            {
                Console.Clear();
                switch (DisplayMenu.ReadingRoomsMenu())
                {
                    case "1":
                        ReadingAllRooms.ReadAllRoomFeatures();
                        Console.WriteLine("Tryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        ReadingAvailableRoom.ReadAvailableRooms();
                        Console.WriteLine("Tryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        ReadOccupiedRoom.ReadOccupiedRooms();
                        Console.WriteLine("Tryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        ReadNonActiveRoom.ReadNonActiveRooms();
                        Console.WriteLine("Tryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "0":
                        Console.Clear();
                        isReadingRooms = false;
                        break;
                        default:
                        Console.WriteLine("Fel val av meny tryck på enter och testa igen.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            }
        }
    }
}
