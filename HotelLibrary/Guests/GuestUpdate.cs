using HotelLibrary.Build.HotelData;
using HotelLibrary.Guests.ReadGuests;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Guests
{
    public class GuestUpdate
    {
        public static void UpdateGuest()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("| Ändra gäst info       |");
            Console.WriteLine("| 0. gå tillbaka        |");
            Console.WriteLine("------------------------\n\n");

            ReadingAllGuest.ReadAllGuests();
            using (var dbGuestUpdate = new HotelChamDbContext())
            {

                Console.Write("\nAnge ID för gästen du vill ändra på: ");
                int.TryParse(Console.ReadLine(), out int guestId);
                var guestToUpdate = dbGuestUpdate.Guests
                    .Find(guestId);
                if (guestToUpdate != null && guestId != 0)
                {
                    Console.Write("\nAnge ett nytt förnamn: ");
                    guestToUpdate.FirstName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(guestToUpdate.FirstName) && guestToUpdate.FirstName != "0")
                    {
                        Console.Write("\nAnge ett nytt efternamn: ");
                        guestToUpdate.LastName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(guestToUpdate.LastName) && guestToUpdate.LastName != "0")
                        {
                            Console.Write("\nAnge nytt email tll gästen: ");
                            guestToUpdate.Email = Console.ReadLine();
                            if (!string.IsNullOrEmpty(guestToUpdate.Email) && guestToUpdate.Email != "0")
                            {

                                Console.Write("\nAnge ett nytt tel-nummer: ");
                                guestToUpdate.Phone = Console.ReadLine();
                                if (!string.IsNullOrEmpty(guestToUpdate.Phone) && guestToUpdate.Phone != "0" && !string.IsNullOrEmpty(guestToUpdate.Adress))
                                {
                                    Console.WriteLine("Inklusive husnummer ");
                                    Console.Write("Ange en ny hemadress: ");
                                    guestToUpdate.Adress = Console.ReadLine();
                                    if (guestToUpdate.Adress != "0")
                                    {
                                        Console.Write("Ange ett land för gästen: ");
                                        guestToUpdate.Country = Console.ReadLine();
                                        if (guestToUpdate.Country != "0" && !string.IsNullOrEmpty(guestToUpdate.Country))
                                        {
                                            Console.Write("\nAnge hemstad för gästen: ");
                                            guestToUpdate.City = Console.ReadLine();
                                            if (guestToUpdate.Country != "0" && !string.IsNullOrEmpty(guestToUpdate.Country))
                                            {
                                                dbGuestUpdate.SaveChanges();
                                                Console.WriteLine($"Info om {guestToUpdate.LastName}, {guestToUpdate.FirstName} är ändrad.");
                                            }
                                            else if (guestToUpdate.City == "0")
                                            {
                                                Console.Clear();
                                                return;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Du måste ange en hemstad till gästen!");
                                            }
                                        }
                                        else if (guestToUpdate.Country == "0")
                                        {
                                            Console.Clear();
                                            return;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Du måste ange ett hemland till gästen");
                                        }
                                        
                                    }
                                    else if (guestToUpdate.Adress == "0")
                                    {
                                        Console.Clear();
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Fel inmatning av adress.");
                                    }
                                }
                                else if (string.IsNullOrEmpty(guestToUpdate.Adress))
                                {
                                    Console.WriteLine($"Info om {guestToUpdate.LastName}, {guestToUpdate.FirstName} är ändrad.");
                                    dbGuestUpdate.SaveChanges();
                                }
                                else if (guestToUpdate.Phone == "0")
                                {
                                    Console.Clear();
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Du måste ange ett telefon nummer!");
                                }
                            }
                            else if (guestToUpdate.Email == "0")
                            {
                                Console.Clear();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Du måste ange en email...");
                            }
                        }
                        else if (guestToUpdate.LastName == "0")
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Du måste ange ett efternamn...");
                        }
                    }
                    else if (guestToUpdate.FirstName == "0")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Du måste ange ett förnamn...");
                    }
                }
                else if (guestId == 0)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Id-nummret du slagit in existerar inte.");
                }

            }

            Console.WriteLine("Tryck på enter för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
