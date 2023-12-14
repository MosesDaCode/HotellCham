using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Room
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity {  get; set; }
        public bool IsOccupied {  get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerNight { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public static void RoomMenu()
        {
            bool isRoom = true;
            while (isRoom)
            {
                switch (Menu.WriteRoomMenu())
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
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
