using HotelLibrary.Bookings.ReadingBookings;
using HotelLibrary.Bookings.UpdateBookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Bookings
{
    public class DisplayBookingMenu
    {
        public static void BookingMenu()
        {
            bool isBooking = true;
            while (isBooking)
            {
                Console.Clear();
                switch (DisplayMenu.WriteBookingMenu())
                {
                    case "1":
                        BoookingCreation.CreateBooking();
                        Console.WriteLine("\nTryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        DisplayReadingBookings.ReadBookings();
                        break;
                    case "3":
                        DisplayBookingUpdateMenu.BookingEditor();
                        Console.WriteLine("\nTryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        BookingDelete.DeleteBooking();
                        
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
