using HotelLibrary.HotelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HotelLibrary.Guests
{
    public class GuestCreation
    {
        public static void CreateGuest()
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("| Skapa Gäst       |");
            Console.WriteLine("| 0. gå tillbaka   |");
            Console.WriteLine("-------------------\n\n");
            using (var dbGuest = new HotelChamDbContext())
            {
                Console.Write("\nAnge förnamn till gästen: ");
                var firstName = Console.ReadLine();
                if (firstName != null && firstName != "0")
                {
                    Console.Write("\nAnge efternamn till gästen: ");
                    var lastName = Console.ReadLine();
                    if (lastName != null && lastName != "0")
                    {
                        Console.Write("\nAnge ett email till gästen: ");
                        var guestEmail = Console.ReadLine();
                        if (guestEmail != null && guestEmail != "0")
                        {
                            int guestNum;
                            do
                            {
                                Console.Write("\nAnge ett Tel-nummer till gästen: ");
                                if (!int.TryParse(Console.ReadLine(), out guestNum))
                                {
                                    Console.WriteLine("Du måste ange ett nummer!!!");
                                    Console.WriteLine("Försök igen...");
                                }
                                else if (guestNum == 0)
                                {
                                    Console.Clear();
                                    return;
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            Console.WriteLine("\nValbart, Annars tryck på enter.");
                            Console.Write("Ange en hemadress till gästen: ");
                            var guestAdress = Console.ReadLine();
                            if (guestAdress != "0")
                            {
                                Console.WriteLine("\n(Om du lagt till adress)");
                                Console.Write("Ange ett land för gästen: ");
                                var guestCountry = Console.ReadLine();
                                if (guestCountry != "0")
                                {
                                    Console.Write("\nAnge hemstad för gästen: ");
                                    var guestCity = Console.ReadLine();
                                    if (guestCity != "0")
                                    {
                                        var newGuest = new Guest()
                                        {
                                            FirstName = firstName,
                                            LastName = lastName,
                                            Email = guestEmail,
                                            Phone = guestNum,
                                            Adress = guestAdress,
                                            Country = guestCountry,
                                            City = guestCity,
                                            IsGuestActive = true
                                        };
                                        dbGuest.Guests.Add(newGuest);
                                        dbGuest.SaveChanges();
                                        Console.WriteLine("Gästen har sparats i systemet!");
                                    }
                                    else if (guestCity == "0")
                                    {
                                        Console.Clear();
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error!!!");
                                    }
                                }
                                else if (guestCountry == "0")
                                {
                                    Console.Clear();
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Error!!");
                                }


                            }
                            else if (guestAdress == "0")
                            {
                                Console.Clear();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Error!!");
                                Console.WriteLine("Tryck på enter för att gå tillbaka...");
                            }
                        }
                        else if (guestEmail == "0")
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Error!!");
                            Console.WriteLine("Tryck på enter för att gå tillbaka...");
                        }
                    }
                    else if (lastName == "0")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Error...");
                        Console.WriteLine("Tryck på enter för att gå tillbaka...");
                    }
                }
                else if (firstName == "0")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Error!!!");
                    Console.WriteLine("Tryck på enter för att gå tillbaka...");
                }
                Console.WriteLine("Tryck på enter för att fortsätta...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
