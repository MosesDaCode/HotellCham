using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.ReadingRooms
{
    public class DisplayRoomMenu
    {
        public static void ReadRooms()
        {
            bool isReadingRooms = true;
            while (isReadingRooms)
            {
                switch (Menu.ReadingRoomsMenu())
                {
                    case "1":
                        ReadingAllRooms.ReadAllRooms();
                        break;
                    case "2":
                        ReadingAvailableRoom.ReadAvailableRooms();
                        break;
                    case "3":
                        ReadOccupiedRoom.ReadOccupiedRooms();
                        break;
                    case "4":
                        ReadNonActiveRoom.ReadNonActiveRooms();
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
