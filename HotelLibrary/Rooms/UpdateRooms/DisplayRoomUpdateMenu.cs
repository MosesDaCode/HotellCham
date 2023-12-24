using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.UpdateRooms
{
    public class DisplayRoomUpdateMenu
    {
        public static void RoomEditor()
        {
            bool isUpdatingRoom = true;
            while (isUpdatingRoom)
            {
                Console.Clear();
                switch (Menu.RoomUpdateMenu())
                {
                    case "1":
                        AllOfRoomUpdate.UpdateWholeRoom();
                        break;
                    case "2":
                        UpdateRoomCap.UpdatingRoomCapacity();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "0":
                        Console.Clear();
                        isUpdatingRoom = false;
                        break;
                    default:
                        Console.WriteLine("Du har angett fel val!");
                        Console.WriteLine("Tryck på enter och försök igen...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
