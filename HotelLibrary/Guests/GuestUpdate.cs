using HotelLibrary.Guests.ReadGuests;
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
                    if (guestToUpdate.FirstName != String.Empty && guestToUpdate.FirstName != "0")
                    {
                        Console.Write("\nAnge ett nytt efternamn: ");
                        guestToUpdate.LastName = Console.ReadLine();
                        if (guestToUpdate.LastName != String.Empty && guestToUpdate.LastName != "0")
                        {
                            Console.Write("\nAnge nytt email tll gästen: ");
                            guestToUpdate.Email = Console.ReadLine();
                            if (guestToUpdate.Email != String.Empty && guestToUpdate.Email != "0")
                            {
                                var newPhone = guestToUpdate.Phone;
                                do
                                {
                                    Console.Write("\nAnge ett nytt tel-nummer: ");
                                    if (!int.TryParse(Console.ReadLine(), out newPhone))
                                    {
                                        Console.WriteLine("\nFel nummerInmatning!");
                                        Console.WriteLine("Försök igen...\n");
                                    }
                                    else if (newPhone == 0)
                                    {
                                        Console.Clear();
                                        return;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (true);

                                Console.WriteLine("\n(valbart, tryck på enter om ingen adress)");
                                Console.WriteLine("Inklusive husnummer "); 
                                Console.Write("Ange en ny hemadress: ");
                                guestToUpdate.Adress = Console.ReadLine();
                                if (guestToUpdate.Adress != "0")
                                {
                                    Console.WriteLine($"Info om {guestToUpdate.LastName}, {guestToUpdate.FirstName} är ändrad.");
                                    dbGuestUpdate.SaveChanges();
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
