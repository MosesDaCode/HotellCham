using HotelLibrary.Rooms.UpdateRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Bookings.UpdateBookings
{
    public class DisplayBookingUpdateMenu
    {
        public static void BookingEditor()
        {
            bool isUpdatingBooking = true;
            while (isUpdatingBooking)
            {
                Console.Clear();
                switch (DisplayMenu.BookingUpdateMenu())
                {
                    case "1":
                        UpdateWholeBooking.UpdateAllBookingFeatures();
                        Console.WriteLine("Tryck på enter och försök igen...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        //Edit checkin date
                        Console.WriteLine("Tryck på enter och försök igen...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        //edit Checkout date
                        Console.WriteLine("Tryck på enter och försök igen...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        //edit room for booking
                        UpdateRoomType.RoomTypeUpdating();
                        Console.WriteLine("Tryck på enter och försök igen...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        //edit guest capacity
                        Console.WriteLine("Tryck på enter och försök igen...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "0":
                        Console.Clear();
                        isUpdatingBooking = false;
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
