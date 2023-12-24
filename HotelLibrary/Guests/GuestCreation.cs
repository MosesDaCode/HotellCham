using HotelLibrary.Build.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HotelLibrary.Build;

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
            if (!string.IsNullOrEmpty(firstName) && firstName != "0")
            {
                Console.Write("\nAnge efternamn till gästen: ");
                var lastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(lastName) && lastName != "0")
                {
                    Console.Write("\nAnge ett email till gästen: ");
                    var guestEmail = Console.ReadLine();
                    if (!string.IsNullOrEmpty(guestEmail) && guestEmail != "0")
                    {
                        Console.Write("\nAnge ett Tel-nummer till gästen: ");
                        var guestNum = Console.ReadLine();
                        if (!string.IsNullOrEmpty(guestNum) && guestNum != "0")
                        {
                            Console.WriteLine("\n(Valbart, Annars tryck på enter.)");
                            Console.Write("Ange en hemadress till gästen: ");
                            var guestAdress = Console.ReadLine();
                            if (guestAdress != "0" && !string.IsNullOrEmpty(guestAdress))
                            {
                                Console.Write("\nAnge ett land för gästen: ");
                                var guestCountry = Console.ReadLine();
                                if (guestCountry != "0" && !string.IsNullOrEmpty(guestCountry))
                                {
                                    Console.Write("\nAnge hemstad för gästen: ");
                                    var guestCity = Console.ReadLine();
                                    if (guestCity != "0" && !string.IsNullOrEmpty(guestCity))
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
                                        Console.WriteLine($"\n{newGuest.LastName}, {newGuest.FirstName} har sparats i systemet!");
                                    }
                                    else if (guestCity == "0")
                                    {
                                        Console.Clear();
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nDu måste ange en hemstad till gästen!");
                                    }
                                }
                                else if (guestCountry == "0")
                                {
                                    Console.Clear();
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("\nDu måste ange ett hemland till gästen");
                                }
                            }
                            else if (string.IsNullOrEmpty(guestAdress))
                            {
                                var newGuest = new Guest()
                                {
                                    FirstName = firstName,
                                    LastName = lastName,
                                    Email = guestEmail,
                                    Phone = guestNum,
                                    IsGuestActive = true
                                };
                                dbGuest.Guests.Add(newGuest);
                                dbGuest.SaveChanges();
                                Console.WriteLine("\nUtan Adress, Land, Stad.");
                                Console.Write($"{newGuest.LastName}, {newGuest.FirstName} har sparats i systemet!");
                            }

                            else if (guestAdress == "0")
                            {
                                Console.Clear();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("\nError!!");
                            }
                        }
                        else if (guestNum == "0")
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nError!!!");
                        }
                    }
                    else if (guestEmail == "0")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nError!!");
                    }

                }
                else if (lastName == "0")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("\nError...");
                }
            }
            else if (firstName == "0")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.WriteLine("\nError!!!");
            }
            Console.WriteLine("\nTryck på enter för att gå tillbaka...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
