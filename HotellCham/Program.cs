using HotelLibrary;
using HotelLibrary.HotelData;

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



// lägg till country och city på en guest.
//lägg till foreign keys
//Gör ett ERD
//Skapa ett admin alternativ med password.
//lägg in PUT (ge användaren alternativ på vad som ska uppdateras) (inkludera avaktivera)