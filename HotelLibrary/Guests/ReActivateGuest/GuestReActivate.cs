using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelLibrary.Build.Service;
using HotelLibrary.Guests.ReadGuests;

namespace HotelLibrary.Guests.ReActivateGuest
{
    public class GuestReActivate
    {
        public static void GetGuestBack()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("| Återaktivera gäst |");
            Console.WriteLine("| 0. gå tillbaka    |");
            Console.WriteLine("--------------------\n\n");

            ReadingNonActiveGuest.ReadNonActiveGuests();
            using (var dbGetBackGuest = new HotelChamDbContext())
            {

                Console.Write("\nAnge id för gästen du vill Återaktivera: ");
                int guestIdToReactivate;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out guestIdToReactivate))
                    {
                        Console.WriteLine("\nID existerar inte!");
                    }
                    else if (guestIdToReactivate == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                var guestToGetBack = dbGetBackGuest.Guests.Find(guestIdToReactivate);
                guestToGetBack.IsGuestActive = true;
                dbGetBackGuest.SaveChanges();
                Console.WriteLine($"\n{guestToGetBack.LastName}, {guestToGetBack.FirstName} är nu aktiverad igen!");
            }
            Console.WriteLine("\nTryck på enter för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
