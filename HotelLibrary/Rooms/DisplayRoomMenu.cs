using HotelLibrary.Rooms.CreateRoom;
using HotelLibrary.Rooms.DeleteRooms;
using HotelLibrary.Rooms.ReadingRooms;
using HotelLibrary.Rooms.UpdateRooms;
using HotelLibrary.Rooms.ReActivateRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms
{
    public class DisplayRoomMenu
    {
        public static void RoomMenu()
        {
            bool isRoom = true;
            while (isRoom)
            {
                Console.Clear();
                switch (DisplayMenu.WriteRoomMenu())
                {
                    case "1":
                        RoomCreate.CreatingRoom();
                        break;
                    case "2":
                        DisplayReadRoomMenu.ReadRooms();
                        break;
                    case "3":
                        DisplayRoomUpdateMenu.RoomEditor();
                        break;
                    case "4":
                        SoftDeleteRooms.SoftDeleteRoom();
                        break;
                    case "5":
                        RoomReActivate.GetBackRoom();
                        break;
                    case "6":
                        RoomDelete.DeleteRoom();
                        break;

                    case "0":
                        Console.Clear();
                        isRoom = false;
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
