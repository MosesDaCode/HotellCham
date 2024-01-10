using HotelLibrary;
using HotelLibrary.Bookings;
using HotelLibrary.Build.Service;
using HotelLibrary.Guests;
using HotelLibrary.Invoices;
using HotelLibrary.Rooms;

namespace HotellCham
{
    public class Application
    {
        public void Run()
        {
            var configDb = new ConfigBuilder();
            configDb.BuildDb();

            bool mainMenuIsRunning = true;
            while (mainMenuIsRunning)
            {
                switch (DisplayMenu.MainMenu())
                {
                    
                    case "1":
                        Console.Clear();
                        DisplayGuestMenu.GuestMenu();
                        break;
                    case "2":
                        Console.Clear();
                        DisplayRoomMenu.RoomMenu();
                        break;
                    case "3":
                        Console.Clear();
                        DisplayBookingMenu.BookingMenu();
                        break;
                    case "4":
                        Console.Clear();
                        DisplayInvoiceMenu.InvoiceMenu();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("-----------");
                        Console.WriteLine("|  Hejdå  |");
                        Console.WriteLine("-----------");
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
