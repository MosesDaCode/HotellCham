using HotelLibrary.HotelData;
using HotelLibrary.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms
{
    public class CreateRoom
    {
        public static void CreatingRoom()
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("| Skapa Rum        |");
            Console.WriteLine("| 0. gå tillbaka   |");
            Console.WriteLine("-------------------\n\n");
            
            using (var dbRoom = new HotelChamDbContext())
            {
                int roomNum;
                do
                {
                    Console.Write("Ange ett rumsnummer: ");
                    if (!int.TryParse(Console.ReadLine(), out roomNum))
                    {
                        Console.WriteLine("Du måste ange ett nummer till rummet!!");
                        Console.WriteLine("Tryck på enter och försök igen...");
                        Console.ReadKey();
                    }
                    else if (roomNum == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                int capacityNum;
                do
                {
                    Console.Write("\nHur många får plats i rummet?: "); 
                    if (!int.TryParse(Console.ReadLine(), out capacityNum))
                    {
                        Console.WriteLine("\nDu måste ange ett nummer för rums kapacitet!!");
                        Console.WriteLine("Tryck på enter och försök igen...");
                        Console.ReadKey();
                    }
                    else if (capacityNum == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                int roomPricePerNight;
                do
                {
                    Console.Write("\nAnge ett pris per natt för rummet: ");
                    if (!int.TryParse(Console.ReadLine(), out roomPricePerNight))
                    {
                        Console.WriteLine("\nDu måste ange ett ogiltigt pris!!");
                        Console.WriteLine("Tryck på enter och försök igen...");
                        Console.ReadKey();
                    }
                    else if (roomPricePerNight == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                var roomTypeChoice = RoomTypeSwitch();

                
                Console.WriteLine("Skriv en liten beskrivning på rummet");
                Console.Write("Beskrivning: ");
                var descriptRoom = Console.ReadLine();
                
                if (!string.IsNullOrEmpty(descriptRoom) && descriptRoom != "0" )
                {
                    var newRoom = new Room()
                    {
                        RoomNumber = roomNum,
                        Capacity = capacityNum,
                        PricePerNight = roomPricePerNight,
                        RoomType = roomTypeChoice,
                        Description = descriptRoom,
                        IsRoomActive = true
                    };
                    dbRoom.Add(newRoom);
                    dbRoom.SaveChanges();
                    Console.WriteLine("Rummet finns nu i systemet!!");
                }
                else if (descriptRoom == "0")
                {
                    Console.Clear();
                    return;
                }
                Console.WriteLine("Tryck på enter för att fortsätta...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static string RoomTypeSwitch()
        {
            Console.WriteLine("\nVad är det för typ av rum?");
            Console.WriteLine("1. EnkelRum");
            Console.WriteLine("2. DubbelRum");
            Console.WriteLine("0. Gå Tillbaka");
            string roomTypeChoice = Console.ReadLine();
            bool isRoomType = true;
            while (isRoomType)
            {
                switch (roomTypeChoice)
                {
                    case "1":
                        string singelRoom = "Enkelrum";
                        return singelRoom;
                    case "2":
                        string doubleRoom = "Dubbelrum";
                        return doubleRoom;
                    case "0":
                        Console.Clear();
                        isRoomType = false;
                        break;
                    default:
                        Console.WriteLine("\nFel val av meny tryck på enter och testa igen.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            return roomTypeChoice;
        }
    }
}
