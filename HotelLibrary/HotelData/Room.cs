using HotelLibrary.Rooms;
using HotelLibrary.Rooms.DeleteRooms;
using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.HotelData
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsOccupied { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerNight { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsRoomActive { get; set; }

        public static void RoomMenu()
        {
            bool isRoom = true;
            while (isRoom)
            {
                switch (Menu.WriteRoomMenu())
                {
                    case "1":
                        CreateRoom.CreatingRoom();
                        break;
                    case "2":
                        DisplayRoomMenu.ReadRooms();
                        break;
                    case "3":
                        //Update Room
                        break;
                    case "4":
                        SoftDeleteRooms.SoftDeleteRoom();
                        break;
                    case "5":
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



//lägg till foreign keys