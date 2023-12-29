using HotelLibrary.Bookings;
using HotelLibrary.Bookings.ReadingBookings;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Build.Service
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int GuestId { get; set; }

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
        public bool IsCheckedIn { get; set; }

        public Room Room { get; set; }

        public static void BookingMenu()
        {
            bool isBooking = true;
            while (isBooking)
            {
                Console.Clear();
                switch (Menu.WriteBookingMenu())
                {
                    case "1":
                        BoookingCreation.CreateBooking();
                        Console.WriteLine("\nTryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        break;
                    case "2":
                        DisplayReadingBookings.ReadBookings();
                        Console.WriteLine("\nTryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        break;
                    case "3":
                        //Edit booking
                        Console.WriteLine("\nTryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        break;
                    case "4":
                        //delete booking
                        Console.WriteLine("\nTryck på enter för att gå tillbaka...");
                        Console.ReadKey();
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