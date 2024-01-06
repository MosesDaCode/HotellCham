using HotelLibrary.Build.Service;
using HotelLibrary.Build.Service;
using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HotelLibrary.Rooms.UpdateRooms
{
    public class AllOfRoomUpdate : CreateRoom
    {
        public static void UpdateWholeRoom()
        {
            using (var dbRoomUpdate = new HotelChamDbContext())
            {
                ReadingAllRooms.ReadAllRoomFeatures();
                Console.WriteLine("\nDu ska nu ändra på:");
                Console.WriteLine("Antalet gäster som kan sova i rummet");
                Console.WriteLine("Priset per natt");
                Console.WriteLine("Rums typ (singel eller dubbel rum)");
                Console.WriteLine("Storleken i KVM");
                Console.WriteLine("Beskrivning av rummet\n\n");




                int roomId;
                
                Console.Write("Ange RumsId ifrån ovan:");
                if (int.TryParse(Console.ReadLine(), out roomId))
                {
                    var roomToUpdate = dbRoomUpdate.Rooms
                   .Find(roomId);
                    if (roomToUpdate != null)
                    {
                        Console.Clear();
                        var displayChosenRoom = dbRoomUpdate.Rooms
                            .Where(r => r.RoomId == roomId)
                            .ToList();
                        Console.WriteLine("Redigerar...");
                        Console.WriteLine("---------------------------------------------------------------------------");
                        foreach (var room in displayChosenRoom)
                        {
                            Console.WriteLine($"RumsID: {roomToUpdate.RoomId}");
                            Console.WriteLine($"Rumsnummer: {roomToUpdate.RoomNumber}");
                            Console.WriteLine($"Rums kapacitet: {roomToUpdate.Capacity}");
                            Console.WriteLine($"Pris per natt: {roomToUpdate.PricePerNight}");
                            Console.WriteLine($"Rums typ: {roomToUpdate.RoomType}");
                            Console.WriteLine($"Rums beskrivning: {roomToUpdate.Description}");
                            Console.WriteLine("---------------------------------------------------------------------------");

                        }

                        Console.WriteLine("\n(1-4 gäster)");
                        Console.Write("Ange antalet gäster: ");
                        roomToUpdate.Capacity = Convert.ToInt32(Console.ReadLine());
                        if (roomToUpdate.Capacity != 0 && roomToUpdate.Capacity >= 1 && roomToUpdate.Capacity < 5)
                        {
                            Console.Write("\nAnge ett nytt pris per natt: ");
                            roomToUpdate.PricePerNight = Convert.ToDecimal(Console.ReadLine());
                            if (roomToUpdate.PricePerNight != 0)
                            {
                                
                                roomToUpdate.RoomType = CreateRoom.RoomTypeSwitch();
                                if (roomToUpdate.RoomType != "0")
                                {
                                    Console.WriteLine("\n(Ange i Kvadratmeter)");
                                    Console.Write("En ny storlek på rummet:");
                                    roomToUpdate.RoomSize = Convert.ToInt32(Console.ReadLine());
                                    if (roomToUpdate.RoomSize != 0)
                                    {
                                        Console.WriteLine("\n(MAX 250 tecken)");
                                        Console.WriteLine("Ange ny beskrivning: ");
                                        roomToUpdate.Description = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(roomToUpdate.Description))
                                        {
                                            dbRoomUpdate.SaveChanges();
                                            Console.WriteLine($"\nRum: {roomToUpdate.RoomNumber}, har uppdaterats!");

                                        }
                                    }
                                    else if (roomToUpdate.RoomSize == 0)
                                    {
                                        Console.Clear();
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nDu har angett i fel format!");
                                    }

                                }
                            }
                            else if (roomToUpdate.PricePerNight == 0)
                            {
                                Console.Clear();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("\nDu har angett ett giltigt pris!");
                            }
                        }
                        else if (roomToUpdate.Capacity == 0)
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nDu måste ange antalet i siffror mella 1-4!");
                        }
                    }
                    else if (roomId == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nID du söker existerar inte!");
                    }

                }
                else if (roomId == 0)
                {
                    Console.Clear();
                    return;
                }

                

            }

        }
    }
}
