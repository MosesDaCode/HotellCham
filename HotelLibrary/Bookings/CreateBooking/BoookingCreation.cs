using HotelLibrary.Build;
using HotelLibrary.Build.Service;
using HotelLibrary.Guests.ReadGuests;
using HotelLibrary.Rooms.ReadingRooms;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Bookings.CreateBooking
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
                do
                {
                    string guestIdString = null;
                    ReadingActiveGuest.ReadActiveGuests();
                    Console.WriteLine("\nOm gästen är inte är befintlig (skapa gäst i gästmenyn)");
                    Console.Write("Ange id för gästen som ska boka rummet:");
                    guestIdString = Console.ReadLine();
                    int.TryParse(guestIdString, out int guestId);
                    if (guestId != 0 && guestId != null)
                    {
                        var selectedGuest = dbBookingCreate.Guests.Find(guestId);

                        if (selectedGuest != null)
                        {
                            DateOnly checkInDate = DateOnly.MinValue;
                            DateOnly checkOutDate = DateOnly.MinValue;
                            while (true)
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
                                    Console.WriteLine("\nDu kan inte ange ett tomt utcheckningsdatum" +
                                        "\nAnge ett datum med (yyyy-MM-dd)");
                                    continue;
                                }
                                else if (!DateOnly.TryParse(checkInInput, out checkInDate))
                                {
                                    Console.WriteLine("\nFel inmatning av incheckningsdatum" +
                                        "\nförsök igen...");
                                    continue;
                                }
                                else if (checkInDate < DateOnly.FromDateTime(DateTime.Now))
                                {
                                    Console.WriteLine("Du kan inte ange passerat datum" +
                                        "\nförsök igen...");
                                    continue;
                                }
                                break;
                            }

                            while (true)
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
                                    Console.WriteLine("\nDu kan inte ange ett tomt utcheckningsdatum" +
                                        "\nAnge ett datum med (yyyy-MM-dd)");
                                    continue;
                                }
                                else if (!DateOnly.TryParse(checkOutInput, out checkOutDate))
                                {
                                    Console.WriteLine("\nFel inmatning av utcheckningsdatum" +
                                        "\nförsök igen...");
                                    continue;
                                }
                                else if (checkOutDate < checkInDate)
                                {
                                    Console.WriteLine("Du kan inte ange ett datum tidigare än Inchecknings datum!!" +
                                        "\nförsök igen...");
                                    continue;
                                }
                                break;
                            }

                            do
                            {
                                var availableRooms = dbBookingCreate.Rooms
                                    .Where(r => r.IsRoomActive && !dbBookingCreate.Bookings
                                    .Any(b => b.RoomId == r.RoomId && checkInDate < b.CheckOutDate &&
                                    checkOutDate > b.CheckInDate))
                                    .ToList();

                                var totalNights = checkOutDate.DayNumber - checkInDate.DayNumber;

                                if (availableRooms.Any())
                                {
                                    Console.WriteLine("\nTillgängliga rum under angivet datum!");
                                    Console.WriteLine("..................................................");
                                    foreach (var room in availableRooms)
                                    {
                                        Console.WriteLine($"RumsId: {room.RoomId}");
                                        Console.WriteLine($"Rumsnummer: {room.RoomNumber}");
                                        Console.WriteLine($"Antal tillåtna gäster: {room.Capacity}");
                                        Console.WriteLine($"Rumstyp: {room.RoomType}");
                                        Console.WriteLine($"Pris per natt: {room.PricePerNight}");
                                        Console.WriteLine($"Beskrivning: {room.Description}");
                                        Console.WriteLine("--------------------------------------------------\n");
                                    }
                                    Console.Write("\nAnge id för rummet du vill boka ovan: ");
                                    if (int.TryParse(Console.ReadLine(), out int roomId))
                                    {
                                        var selectedRoom = availableRooms.FirstOrDefault(r => r.RoomId == roomId);
                                        string guestCapacityString = null;
                                        int guestCapacityInt = 1;
                                        string extraBedInput = "0";
                                        if (selectedRoom != null)
                                        {
                                            do
                                            {
                                                if (selectedRoom.RoomType == "Dubbelrum")
                                                {
                                                    Console.WriteLine($"\nMax ({selectedRoom.Capacity}) gäster i rummet");
                                                    Console.WriteLine($"Inkludera {selectedGuest.LastName}, {selectedGuest.FirstName} ");
                                                    Console.Write("Ange hur många gäster som ska sova i rummet?: ");
                                                    guestCapacityString = Console.ReadLine();
                                                    int.TryParse(guestCapacityString, out guestCapacityInt);
                                                    if (string.IsNullOrEmpty(guestCapacityString))
                                                    {
                                                        Console.WriteLine("\nDu kan inte ange ett tomt svar...");
                                                        continue;
                                                    }
                                                    if (guestCapacityInt > selectedRoom.Capacity)
                                                    {
                                                        Console.WriteLine("\nDu kan inte ange fler gäster än tillåtet!!" +
                                                            $"\nMAX {selectedRoom.Capacity} gäster är tillåtna...");
                                                        continue;
                                                    }
                                                    else if (guestCapacityString == "0")
                                                    {
                                                        Console.Clear();
                                                        return;
                                                    }
                                                    else if (guestCapacityInt < 1)
                                                    {
                                                        Console.WriteLine("\nDu kan inte ange ett antal mindre än 1 gäst!!" +
                                                            $"\nMinst (1) gäst och Max ({selectedRoom.Capacity}) gäster är tillåtna");
                                                        continue;
                                                    }

                                                    else
                                                    {
                                                        do
                                                        {
                                                            Console.WriteLine("\n(Svar med J eller N)");
                                                            Console.Write("Önskas även en extra säng till rummet?: ");
                                                            extraBedInput = Console.ReadLine();

                                                            if (string.IsNullOrEmpty(extraBedInput))
                                                            {
                                                                Console.WriteLine("\nDu kan inte ange ett tomt svar...");
                                                                continue;
                                                            }
                                                            else if (extraBedInput.ToUpper() == "J")
                                                            {
                                                                break;
                                                            }
                                                            else if (extraBedInput.ToUpper() == "N")
                                                            {
                                                                break;
                                                            }
                                                            else if (extraBedInput == "0")
                                                            {
                                                                Console.Clear();
                                                                return;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Du måste svara med J eller N (Ja eller Nej)");
                                                                continue;
                                                            }

                                                        } while (true);
                                                        break;
                                                    }

                                                }
                                                else if (selectedRoom.RoomType == "Enkelrum")
                                                {
                                                    break;
                                                }
                                            } while (true);

                                            if (selectedRoom.RoomType == "Enkelrum" || selectedRoom.RoomType == "Dubbelrum" && !int.IsNegative(guestCapacityInt) && guestCapacityInt != 0 && guestCapacityInt <= selectedRoom.Capacity)
                                            {

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
                                                            NumberOfGuests = guestCapacityInt,
                                                            CheckInDate = checkInDate,
                                                            CheckOutDate = checkOutDate,
                                                            TotalPrice = totalNights * selectedRoom.PricePerNight,
                                                            IsBookingActive = true,
                                                            ExtraBed = 1
                                                        })
                                                        .DefaultIfEmpty()
                                                        .ToList();

                                                    selectedRoom.IsOccupied = true;
                                                    dbBookingCreate.AddRange(newBooking);
                                                    dbBookingCreate.SaveChanges();

                                                    Console.WriteLine($"\nGäst: {selectedGuest.LastName}, {selectedGuest.FirstName}");
                                                    Console.WriteLine($"Bokning för rum {selectedRoom.RoomNumber}.");
                                                    Console.WriteLine($"Check in datum: {checkInDate}");
                                                    Console.WriteLine($"Check ut datum: {checkOutDate}");
                                                    Console.WriteLine($"Antal gäster: {guestCapacityInt}");
                                                    Console.WriteLine($"Antal nätter: {totalNights}");
                                                    Console.WriteLine($"Pris per natt: {selectedRoom.PricePerNight}");
                                                    Console.WriteLine($"Total pris: {totalNights * selectedRoom.PricePerNight}");
                                                    Console.WriteLine($"Extra säng: JA");
                                                    break;

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
                                                            NumberOfGuests = guestCapacityInt,
                                                            CheckInDate = checkInDate,
                                                            CheckOutDate = checkOutDate,
                                                            TotalPrice = totalNights * selectedRoom.PricePerNight,
                                                            IsBookingActive = true,
                                                        })
                                                        .DefaultIfEmpty()
                                                        .ToList();

                                                    selectedRoom.IsOccupied = true;
                                                    dbBookingCreate.AddRange(newBooking);
                                                    dbBookingCreate.SaveChanges();

                                                    Console.WriteLine($"\nGäst: {selectedGuest.LastName}, {selectedGuest.FirstName}");
                                                    Console.WriteLine($"Bokning för rum {selectedRoom.RoomNumber}.");
                                                    Console.WriteLine($"Check in datum: {checkInDate}");
                                                    Console.WriteLine($"Check ut datum: {checkOutDate}");
                                                    Console.WriteLine($"Antal gäster: {guestCapacityInt}");
                                                    Console.WriteLine($"Antal nätter: {totalNights}");
                                                    Console.WriteLine($"Pris per natt: {selectedRoom.PricePerNight}");
                                                    Console.WriteLine($"Total pris: {totalNights * selectedRoom.PricePerNight}");
                                                    Console.WriteLine($"Extra säng: NEJ");
                                                    break;
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
                                                                NumberOfGuests = 1,
                                                                CheckInDate = checkInDate,
                                                                CheckOutDate = checkOutDate,
                                                                TotalPrice = totalNights * selectedRoom.PricePerNight,
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
                                                        Console.WriteLine($"Antal gäster: {guestCapacityInt}");
                                                        Console.WriteLine($"Antal nätter: {totalNights}");
                                                        Console.WriteLine($"Pris per natt: {selectedRoom.PricePerNight}");
                                                        Console.WriteLine($"Total pris: {totalNights * selectedRoom.PricePerNight}");
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nDet gick inte att boka gästen!");
                                                    }
                                                }
                                                break;

                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nOgiltigt rum!!, Välj ett rum som finns i listan..." +
                                                "\nTryck på enter och försök igen");
                                            Console.ReadKey();
                                        }
                                    }
                                    else if (roomId == 0)

                                    {
                                        Console.Clear();
                                        return;
                                    }
                                }
                            } while (true);

                        }

                    }
                    else if (!int.TryParse(guestIdString, out guestId))
                    {
                        Console.WriteLine("ID existerar inte!!" +
                            "\nTryck på enter och försök igen...");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    else if (string.IsNullOrEmpty(guestIdString))
                    {
                        Console.WriteLine("\nDu kan inte ange ett tomt svar!!" +
                            "\nTryck på enter och försök igen..."!);
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    else if (guestId == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("ID existerar inte!!" +
                            "\nTryck på enter och försök igen...");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    break;
                } while (true);

            }

        }


    }

}
