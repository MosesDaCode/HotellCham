using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Guests.ReadGuests
{
    public class ReadingNonActiveGuest
    {
        public static void ReadNonActiveGuests()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("| Se icke aktiva gäster |");
            Console.WriteLine("| 0. gå tillbaka        |");
            Console.WriteLine("------------------------\n\n");
            using (var dbGuest = new HotelChamDbContext())
            {
                Console.WriteLine("Lista över icke aktiva gäster.");
                Console.WriteLine("------------------------------");

                var guests = dbGuest.Guests
                    .Where(guest => guest.IsGuestActive == false)
                    .OrderBy(exsistGuest => exsistGuest.GuestId)
                    .ToList();
                if (guests.Any())
                {


                    foreach (var guest in guests)
                    {
                        Console.WriteLine($"GästID: {guest.GuestId}");
                        Console.WriteLine($"Namn: {guest.LastName}, {guest.FirstName}");
                        Console.WriteLine($"Email: {guest.Email}");
                        Console.WriteLine($"Phone: {guest.Phone}");
                        if (!string.IsNullOrEmpty(guest.Adress))
                        {
                            Console.WriteLine($"Adress: {guest.Adress}");
                            Console.WriteLine($"City: {guest.City}");
                            Console.WriteLine($"Country: {guest.Country}");
                        }
                        Console.WriteLine($"Active: {guest.IsGuestActive}");
                        Console.WriteLine("------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Inga gäster hittades.");
                    Console.WriteLine("Tryck på enter för att gå tillbaka...");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
