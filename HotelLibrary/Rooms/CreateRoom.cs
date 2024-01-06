using HotelLibrary.Build.Service;
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
                bool roomNumExist;
                do
                {
                    Console.Write("Ange ett rumsnummer: ");
                    if (!int.TryParse(Console.ReadLine(), out roomNum))
                    {
                        Console.WriteLine("\nDu måste ange ett nummer till rummet!!");
                        roomNumExist = true;
                    }
                    else if (roomNum == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        roomNumExist = RoomNumberExist(roomNum, dbRoom);
                        if (roomNumExist)
                        {
                            Console.WriteLine("Rumsnummret existerar redan!!!");
                            Console.WriteLine("Tryck på enter för att fortsätta...");
                            Console.ReadKey();
                        }
                    }

                } while (roomNumExist);

                int roomSize;
                do
                {
                    Console.WriteLine("\n(Ange i Kvm)");
                    Console.Write("Rumsstorlek:  ");
                    if (!int.TryParse(Console.ReadLine(), out roomSize))
                    {
                        Console.WriteLine("Du måste ange storlek i siffror");
                        Console.WriteLine("Tryck på enter och försök igen...");
                        Console.ReadKey();
                    }
                    else if (roomSize == 0)
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
                    Console.Write("\nAnge antal gäster som får plats i rummet?: ");
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
                        Console.WriteLine("\nDu måste ange ett giltigt pris!!");
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


                Console.WriteLine("\nSkriv en liten beskrivning på rummet");
                Console.Write("Beskrivning: ");
                var descriptRoom = Console.ReadLine();

                if (!string.IsNullOrEmpty(descriptRoom) && descriptRoom != "0")
                {
                    var newRoom = new Room()
                    {
                        RoomNumber = roomNum,
                        Capacity = capacityNum,
                        RoomSize = roomSize,
                        PricePerNight = roomPricePerNight,
                        RoomType = roomTypeChoice,
                        Description = descriptRoom,
                        IsRoomActive = true,
                        IsOccupied = false,

                    };
                    dbRoom.Add(newRoom);
                    dbRoom.SaveChanges();
                    Console.WriteLine($"\nRum {newRoom.RoomNumber} finns nu i systemet!!");
                }
                else if (descriptRoom == "0")
                {
                    Console.Clear();
                    return;
                }
                Console.WriteLine("\nTryck på enter för att fortsätta...");
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
        private static bool RoomNumberExist(int roomNum, HotelChamDbContext dbContext)
        {
            return dbContext.Rooms.Any(r => r.RoomNumber == roomNum);
        }
    }
}
