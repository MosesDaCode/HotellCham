using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Build.Service
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }

        [Range(0,2)]
        public int? ExtraBed { get; set; }

        public bool IsPaid { get; set; }

        public bool IsBookingActive { get; set; }

        public Room Room { get; set; }

        public static void BookingMenu()
        {
            bool isBooking = true;
            while (isBooking)
            {
                switch (Menu.WriteBookingMenu())
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
                        isBooking = false;
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



//Console.WriteLine("(Valbart, Annars tryck på enter)");
//Console.Write("Hur många extrasängar behövs?: ");
//int extraBeds;
//do
//{
//    Console.WriteLine("(Valbart, Annars tryck på enter)");
//    Console.Write("Hur många extrasängar behövs?: ");
//    if (!int.TryParse(Console.ReadLine(), out extraBeds))
//    {
//        Console.WriteLine("\nDu måste ange ett för hur många sängar som ska läggas till.");
//        Console.WriteLine("Tryck på enter och försök igen...");
//        Console.ReadKey();
//    }
//} while (true);