using HotelLibrary.Build;
using HotelLibrary.Build.Service;
using HotelLibrary.Guests.ReadGuests;
using HotelLibrary.Rooms.ReadingRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Bookings
{
    public class BoookingCreation
    {
        public static void CreateBooking()
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("| Boka ett rum     |");
            Console.WriteLine("| 0. gå tillbaka   |");
            Console.WriteLine("-------------------\n\n");
            using (var dbBookingCreate = new HotelChamDbContext())
            {
                Console.WriteLine("\nVälj ett alternativ");
                Console.WriteLine("1. Boka befintlig gäst.");
                Console.WriteLine("2. Boka ny gäst.");
                var newOrOldGuest = Console.ReadLine();
                if (!string.IsNullOrEmpty(newOrOldGuest) && newOrOldGuest == "1" && newOrOldGuest != "0")
                {
                    ReadingActiveGuest.ReadActiveGuests();
                    Console.Write("\nAnge id för gästen som ska boka rummet:");
                    if (int.TryParse(Console.ReadLine(), out int guestId))
                    {
                        var selectedGuest = dbBookingCreate.Guests.Find(guestId);
                        if (selectedGuest != null)
                        {
                            ReadingAvailableRoom.ReadAvailableRooms();
                            Console.Write("\nAnge id för rummet du vill boka ovan: ");
                            if (int.TryParse(Console.ReadLine(), out int roomId))
                            {
                                var selectedRoom = dbBookingCreate.Rooms.Find(roomId);
                                var guestCapacity = 0;
                                string extraBedInput = "";
                                if (selectedRoom != null)
                                {
                                    if (selectedRoom.RoomType == "Dubbelrum")
                                    {
                                        Console.WriteLine($"\nMax ({selectedRoom.Capacity}) gäster i rummet");
                                        Console.WriteLine($"Inklusive {selectedGuest.LastName}, {selectedGuest.LastName} ");
                                        Console.Write("Ange hur många gäster som ska sova i rummet?: ");
                                        guestCapacity = Convert.ToInt32(Console.ReadLine());

                                        Console.WriteLine("\n(Svar med J eller N)");
                                        Console.Write("Önskas även en extra säng till rummet?: ");
                                        extraBedInput = Console.ReadLine();
                                    }
                                    if (selectedRoom.RoomType == "Singelrum" || selectedRoom.RoomType == "Dubbelrum" && !int.IsNegative(guestCapacity) && guestCapacity != 0 && guestCapacity <= selectedRoom.Capacity)
                                    {
                                        Console.WriteLine("\n(yyyy-MM-dd)");
                                        Console.Write("Ange ett datum att checka in: ");
                                        var checkInInput = Console.ReadLine();
                                        if (checkInInput == "0")
                                        {
                                            Console.Clear();
                                            return;
                                        }
                                        else if (string.IsNullOrEmpty(checkInInput))
                                        {
                                            Console.WriteLine("\nAnge ett datum med (yyyy-MM-dd)");
                                        }
                                        if (DateTime.TryParse(checkInInput, out DateTime checkInDate))
                                        {
                                            if (checkInDate >= DateTime.Now)
                                            {
                                                Console.WriteLine("\n(yyyy-MM-dd)");
                                                Console.Write("Ange ett datum att checka ut: ");
                                                var checkOutInput = Console.ReadLine();
                                                if (checkOutInput == "0")
                                                {
                                                    Console.Clear();
                                                    return;
                                                }
                                                else if (string.IsNullOrEmpty(checkOutInput))
                                                {
                                                    Console.WriteLine("\nAnge ett datum med (yyyy-MM-dd)");
                                                }
                                                if (DateTime.TryParse(checkOutInput, out DateTime checkOutDate))
                                                {
                                                    var totalNights = (checkOutDate - checkInDate).TotalDays;


                                                    if (extraBedInput.ToUpper() == "J")
                                                    {
                                                        var newBooking = dbBookingCreate.Bookings
                                                            .Join(dbBookingCreate.Guests, b => b.GuestId, g => g.GuestId, (b, g) => new { b, g })
                                                            .Join(dbBookingCreate.Rooms, bg => bg.b.RoomId, r => r.RoomId, (bg, r) => new { bg, r })
                                                            .Where(data => data.bg.b.RoomId == selectedRoom.RoomId)
                                                            .Select(data => new Booking
                                                            {
                                                                GuestId = selectedGuest.GuestId,
                                                                RoomId = selectedRoom.RoomId,
                                                                CheckInDate = checkInDate,
                                                                CheckOutDate = checkOutDate,
                                                                TotalPrice = (decimal)totalNights * selectedRoom.PricePerNight,
                                                                IsBookingActive = true,
                                                                ExtraBed = 1
                                                            }).ToList();

                                                        selectedRoom.IsOccupied = true;
                                                        dbBookingCreate.AddRange(newBooking);
                                                        dbBookingCreate.SaveChanges();

                                                        Console.WriteLine($"\nGäst: {selectedGuest.LastName}, {selectedGuest.FirstName}");
                                                        Console.WriteLine($"Bokning för rum {selectedRoom.RoomNumber}.");
                                                        Console.WriteLine($"Check in datum: {checkInDate}");
                                                        Console.WriteLine($"Check ut datum: {checkOutDate}");
                                                        Console.WriteLine($"Antal nätter: {totalNights}");
                                                        Console.WriteLine($"Pris per natt: {selectedRoom.PricePerNight}");
                                                        Console.WriteLine($"Total pris: {(decimal)totalNights * selectedRoom.PricePerNight}");
                                                        Console.WriteLine($"Extra säng: JA");

                                                    }
                                                    else if (extraBedInput.ToUpper() == "N")
                                                    {
                                                        var newBooking = dbBookingCreate.Bookings
                                                            .Join(dbBookingCreate.Guests, b => b.GuestId, g => g.GuestId, (b, g) => new { b, g })
                                                            .Join(dbBookingCreate.Rooms, bg => bg.b.RoomId, r => r.RoomId, (bg, r) => new { bg, r })
                                                            .Where(data => data.bg.b.RoomId == selectedRoom.RoomId)
                                                            .Select(data => new Booking
                                                            {
                                                                GuestId = selectedGuest.GuestId,
                                                                RoomId = selectedRoom.RoomId,
                                                                CheckInDate = checkInDate,
                                                                CheckOutDate = checkOutDate,
                                                                TotalPrice = (decimal)totalNights * selectedRoom.PricePerNight,
                                                                IsBookingActive = true,
                                                            }).ToList();

                                                        selectedRoom.IsOccupied = true;
                                                        dbBookingCreate.AddRange(newBooking);
                                                        dbBookingCreate.SaveChanges();

                                                        Console.WriteLine($"\nGäst: {selectedGuest.LastName}, {selectedGuest.FirstName}");
                                                        Console.WriteLine($"Bokning för rum {selectedRoom.RoomNumber}.");
                                                        Console.WriteLine($"Check in datum: {checkInDate}");
                                                        Console.WriteLine($"Check ut datum: {checkOutDate}");
                                                        Console.WriteLine($"Antal nätter: {totalNights}");
                                                        Console.WriteLine($"Pris per natt: {selectedRoom.PricePerNight}");
                                                        Console.WriteLine($"Total pris: {(decimal)totalNights * selectedRoom.PricePerNight}");

                                                    }
                                                    else
                                                    {
                                                        var newBooking = dbBookingCreate.Bookings
                                                                .Join(dbBookingCreate.Guests, b => b.GuestId, g => g.GuestId, (b, g) => new { b, g })
                                                                .Join(dbBookingCreate.Rooms, bg => bg.b.RoomId, r => r.RoomId, (bg, r) => new { bg, r })
                                                                .Where(data => data.bg.b.RoomId == selectedRoom.RoomId)
                                                                .Select(data => new Booking
                                                                {
                                                                    GuestId = selectedGuest.GuestId,
                                                                    RoomId = selectedRoom.RoomId,
                                                                    CheckInDate = checkInDate,
                                                                    CheckOutDate = checkOutDate,
                                                                    TotalPrice = (decimal)totalNights * selectedRoom.PricePerNight,
                                                                    IsBookingActive = true,
                                                                })
                                                                .DefaultIfEmpty()
                                                                .ToList();
                                                        if (newBooking.Any())
                                                        {
                                                            selectedRoom.IsOccupied = true;
                                                            dbBookingCreate.AddRange(newBooking);
                                                            dbBookingCreate.SaveChanges();

                                                            Console.WriteLine($"\nGäst: {selectedGuest.LastName}, {selectedGuest.FirstName}");
                                                            Console.WriteLine($"Bokning för rum {selectedRoom.RoomNumber}.");
                                                            Console.WriteLine($"Check in datum: {checkInDate}");
                                                            Console.WriteLine($"Check ut datum: {checkOutDate}");
                                                            Console.WriteLine($"Antal nätter: {totalNights}");
                                                            Console.WriteLine($"Pris per natt: {selectedRoom.PricePerNight}");
                                                            Console.WriteLine($"Total pris: {(decimal)totalNights * selectedRoom.PricePerNight}");

                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("\nDet gick inte att boka gästen!");
                                                        }
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Du har angett ett ogiltigt datum!");
                                            }
                                        }


                                    }
                                }
                            }
                            else if (roomId == 0)
                            {
                                Console.Clear();
                                return;
                            }
                        }
                        else if (!string.IsNullOrEmpty(newOrOldGuest) && newOrOldGuest == "2")
                        {
                            GuestCreation.CreateGuest();
                        }
                        else if (newOrOldGuest == "0")
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Du måste ange alternativ 1 eller 2!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nID existerar inte!");
                    }
                }
                else if (newOrOldGuest == "0")
                {
                    Console.Clear();
                    return;
                }
            }
        }
    }
}


//--Fixa totalPrice.[V]
//fixa ExtraBed frågan.
