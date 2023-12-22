using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelLibrary.Build.HotelData;
using HotelLibrary.Guests.ReadGuests;

namespace HotelLibrary.Guests
{
    public class ReActiveateGuest
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

                Console.Write("Ange id för gästen du vill Återaktivera: ");
                int guestIdToReactivate;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out guestIdToReactivate))
                    {
                        Console.WriteLine("ID existerar inte!");
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
                Console.WriteLine("Gästen är nu aktiverad igen!");
            }
            Console.WriteLine("Tryck på enter för att fortsätta...");
            Console.ReadKey();
        }
    }
}
