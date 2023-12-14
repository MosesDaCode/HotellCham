using Library;
using Library.Booking;
using Library.Guest;
using Library.Invoice;
using Library.Room;

namespace HotellCham
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool mainMenuIsRunning = true;
            while (mainMenuIsRunning)
            {
                switch (Menu.MainMenu())
                {
                    case "1":
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Guest.GuestMenu();
                        break;
                    case "4":
                        Console.Clear();
                        Room.RoomMenu();
                        break;
                    case "5":
                        Console.Clear();
                        Booking.BookingMenu();
                        break;
                    case "6":
                        Console.Clear();
                        Invoice.InvoiceMenu();
                        break;
                    case "0":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Fel val av meny tryck på enter och testa igen.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                Console.Clear();
            }

        }
    }
}