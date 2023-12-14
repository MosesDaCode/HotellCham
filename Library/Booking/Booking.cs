using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Booking
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int GuestID { get; set; }
        public int RoomID {  get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice {  get; set; }
        public bool IsPaid {  get; set; }

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
