using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Bookings.ReadingBookings
{
    public class DisplayReadingBookings
    {
        public static void ReadBookings()
        {
            bool isReadingBookings = true;
            while (isReadingBookings)
            {
                Console.Clear();
                switch (Menu.ReadingBookingsMenu())
                {
                    case "1":
                        ReadingAllBookings.ReadAllBookings();
                        Console.WriteLine("\nTryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        ReadingPaidBookings.ReadPaidBookings();
                        Console.WriteLine("\nTryck på enter för att gå tillbaka...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case "3":
                        ReadingUnPaidBookings.ReadUnPaidBookings();
                        Console.WriteLine("\nTryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "0":
                        Console.Clear();
                        isReadingBookings = false;
                        break;
                    default:
                        Console.WriteLine("\nFel val av meny tryck på enter och testa igen.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            }
        }
    }
}
