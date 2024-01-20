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
                switch (DisplayMenu.RoomUpdateMenu())
                {
                    case "1":
                        AllOfRoomUpdate.UpdateWholeRoom();
                        Console.WriteLine("Tryck på enter för att fortsätta...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        UpdateRoomCap.UpdatingRoomCapacity();
                        Console.WriteLine("Tryck på enter för att fortsätta...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        UpdateRoomPrice.RoomPriceUpdating();
                        Console.WriteLine("Tryck på enter för att fortsätta...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        UpdateRoomType.RoomTypeUpdating();
                        Console.WriteLine("Tryck på enter för att fortsätta...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        UpdateRoomSize.RoomSizeUpdating();
                        Console.WriteLine("Tryck på enter för att fortsätta...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        UpdateRoomDesc.RoomDescriptionUpdate();
                        Console.WriteLine("Tryck på enter för att fortsätta...");
                        Console.ReadKey();
                        Console.Clear();
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
