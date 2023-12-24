using HotelLibrary.Build.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Guests.ReadGuests
{
    public class ReadingAllGuest
    {
        public static void ReadAllGuests()
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("| Se alla gäster   |");
            Console.WriteLine("-------------------\n\n");
            using (var dbGuest = new HotelChamDbContext())
            {
                var guests = dbGuest.Guests.ToList();
                if (guests.Any())
                {
                    Console.WriteLine("Lista över aktiva gäster.");
                    Console.WriteLine("------------------------------");

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
                        Console.WriteLine("------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Inga gäster hittades.");
                }
            }
        }
    }
}
