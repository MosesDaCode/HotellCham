using HotelLibrary.Guests.ReadGuests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Guests.DeleteGuests
{
    public class GuestDelete
    {
        public static void DeleteGuest()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("| Radera gäst från systemet  |");
            Console.WriteLine("| 0. gå tillbaka             |");
            Console.WriteLine("-----------------------------\n\n");

            ReadingActiveGuest.ReadActiveGuests();

            using (var dbGuestDelete = new HotelChamDbContext())
            {
                Console.Write("Ange id för gästen du vill ta bort: ");
                int guestId;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out guestId))
                    {
                        Console.WriteLine("ID existerar inte!");
                    }
                    else if (guestId == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                var guestToDelete = dbGuestDelete.Guests.Find(guestId);
                dbGuestDelete.Guests.Remove(guestToDelete);
                dbGuestDelete.SaveChanges();
                Console.WriteLine($"{guestToDelete.LastName}, {guestToDelete.FirstName} är raderad ur systemet.");

            }
            Console.WriteLine("Tryck på enter för att fortsätta...");
            Console.ReadKey();
        }
       
    }
}
