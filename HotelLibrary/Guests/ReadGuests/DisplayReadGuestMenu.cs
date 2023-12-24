using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Guests.ReadGuests
{
    public class DisplayReadGuestMenu
    {
        public static void ReadGuests()
        {
            bool isReadingGuests = true;
            while (isReadingGuests)
            {
                Console.Clear();
                switch (Menu.ReadingGuestsMenu())
                {
                    case "1":
                        ReadingAllGuest.ReadAllGuests();
                        Console.WriteLine("Tryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        ReadingActiveGuest.ReadActiveGuests();
                        Console.WriteLine("Tryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        ReadingNonActiveGuest.ReadNonActiveGuests();
                        Console.WriteLine("Tryck på enter för att gå tillbaka...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "0":
                        Console.Clear();
                        isReadingGuests = false;
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
