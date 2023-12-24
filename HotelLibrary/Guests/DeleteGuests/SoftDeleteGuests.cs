using HotelLibrary.Build.Service;
using HotelLibrary.Guests.ReadGuests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Guests.DeleteGuests
{
    public class SoftDeleteGuests
    {
        public static void SoftDeleteGuest()
        {

            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("| Avaktivera gäst   |");
            Console.WriteLine("| 0. gå tillbaka    |");
            Console.WriteLine("--------------------\n\n");

            ReadingActiveGuest.ReadActiveGuests();
            using (var dbSoftDeleteGuest = new HotelChamDbContext())
            {

                Console.Write("\nAnge id för gästen du vill ta bort: ");
                int guestIdToDeactivate;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out guestIdToDeactivate))
                    {
                        Console.WriteLine("\nID existerar inte!");
                    }
                    else if (guestIdToDeactivate == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                var guestToSoftDelete = dbSoftDeleteGuest.Guests.Find(guestIdToDeactivate);
                guestToSoftDelete.IsGuestActive = false;
                dbSoftDeleteGuest.SaveChanges();
                Console.WriteLine($"\n{guestToSoftDelete.LastName}, {guestToSoftDelete.FirstName} är nu avaktiverad!");
            }
            Console.WriteLine("\nTryck på enter för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
