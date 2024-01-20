using HotelLibrary.Bookings.ReadingBookings;
using HotelLibrary.Build.Service;
using HotelLibrary.Rooms.ReadingRooms;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace HotelLibrary.Bookings.UpdateBookings
{
    public class EditBooking
    {
        public static void EditingBooking()
        {
            using (var dbUpdateBooking = new HotelChamDbContext())
            {

                ReadingAllBookings.ReadAllBookings();

                int bookingId;

                Console.WriteLine("Välj en bokning att ändra på" +
                    "\nAnnars ange 0 för att gå tillbaka!!" +
                    "\n.............................................");
                Console.Write("\n\nAnge bokningens id ifrån ovan: ");
                if (int.TryParse(Console.ReadLine(), out bookingId) && bookingId != 0)
                {
                    var guestBooking = dbUpdateBooking.Guests;
                    var bookingToEdit = dbUpdateBooking.Bookings
                        .Find(bookingId);
                    if (bookingToEdit != null)
                    {
                        var chosenBooking =
                            (from b in dbUpdateBooking.Bookings
                             join g in dbUpdateBooking.Guests on b.GuestId equals g.GuestId
                             join r in dbUpdateBooking.Rooms on b.RoomId equals r.RoomId
                             where b.BookingID == bookingId
                             select new
                             {
                                 g.LastName,
                                 g.FirstName,
                                 b.NumberOfGuests,
                                 b.CheckInDate,
                                 b.CheckOutDate,
                                 b.IsBookingActive,
                                 r.Capacity,
                                 r.RoomNumber,
                                 r.IsOccupied

                             })
                             .FirstOrDefault();


                        Console.WriteLine("Redigerar bokning...");
                        Console.WriteLine("---------------------------------------------------------------------------");

                        Console.WriteLine($"Booknings ID: {bookingToEdit.BookingID}");
                        Console.WriteLine($"Gäst: {chosenBooking.LastName}, {chosenBooking.FirstName}");
                        Console.WriteLine($"Rumsnummer: {chosenBooking.RoomNumber}");
                        Console.WriteLine($"Check in datum: {bookingToEdit.CheckInDate}");
                        Console.WriteLine($"Check out: {bookingToEdit.CheckOutDate}");
                        Console.WriteLine($"Antal gäster i bokning: {chosenBooking.NumberOfGuests}");
                        Console.WriteLine("---------------------------------------------------------------------------");

                        DateOnly newCheckOutDate = chosenBooking.CheckOutDate;
                        DateOnly newCheckInDate = chosenBooking.CheckInDate;

                        string newCheckInInput;
                        string newCheckOutInput;


                        do
                        {
                            Console.WriteLine("\n(J/N)");
                            Console.Write("Vill du ändra på incheckningsdatum? " +
                           "\nVal: ");
                            var ifCheckInDatechoice = Console.ReadLine();

                            if (ifCheckInDatechoice.ToUpper() == "J")
                            {
                                Console.WriteLine("\n(yyyy-MM-dd)");
                                Console.Write("Ange ett nytt inchecknings datum: ");
                                newCheckInInput = Console.ReadLine();
                                if (newCheckInInput == "0")
                                {
                                    Console.Clear();
                                    return;
                                }
                                else if (string.IsNullOrEmpty(newCheckInInput))
                                {
                                    Console.WriteLine("\nAnge ett datum med (yyyy-MM-dd)");
                                }

                                if (DateOnly.TryParse(newCheckInInput, out newCheckInDate))
                                {
                                    if (newCheckInDate >= DateOnly.FromDateTime(DateTime.Now))
                                    {
                                        Console.WriteLine("\n(J/N)");
                                        Console.Write("Vill du ändra på utcheckningsdatum? " +
                                            "\nVal: ");
                                        var ifCheckOutDateChoice = Console.ReadLine();
                                        if (ifCheckOutDateChoice.ToUpper() == "J")
                                        {
                                            Console.WriteLine("\n(yyyy-MM-dd)");
                                            Console.Write("Ange ett nytt utchecknings datum: ");
                                            newCheckOutInput = Console.ReadLine();
                                            if (newCheckOutInput == "0")
                                            {
                                                Console.Clear();
                                                return;
                                            }
                                            else if (string.IsNullOrEmpty(newCheckOutInput))
                                            {
                                                Console.WriteLine("\nAnge ett datum med (yyyy-MM-dd)");
                                            }
                                            DateOnly.TryParse(newCheckOutInput, out newCheckOutDate);
                                            break;
                                        }
                                        else if (ifCheckOutDateChoice.ToUpper() == "N")
                                        {
                                            break;
                                        }
                                        else if (string.IsNullOrEmpty(ifCheckOutDateChoice))
                                        {
                                            Console.WriteLine("Du måste ange J eller N  (Ja eller Nej)");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Du måste ange J eller N  (Ja eller Nej)");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("\nAnge ett datum med (yyyy-MM-dd)");
                                    }
                                }
                            }
                            else if (ifCheckInDatechoice.ToUpper() == "N")
                            {
                                Console.WriteLine("\n(J / N)");
                                Console.Write("Vill du ändra på utcheckningsdatum? " +
                                           "\nVal: ");
                                var ifCheckOutDateChoice = Console.ReadLine();
                                if (ifCheckOutDateChoice.ToUpper() == "J")
                                {
                                    Console.WriteLine("\n(yyyy-MM-dd)");
                                    Console.Write("Ange ett nytt utchecknings datum: ");
                                    newCheckOutInput = Console.ReadLine();
                                    if (newCheckOutInput == "0")
                                    {
                                        Console.Clear();
                                        return;
                                    }
                                    else if (string.IsNullOrEmpty(newCheckOutInput))
                                    {
                                        Console.WriteLine("\nAnge ett datum med (yyyy-MM-dd)");
                                    }
                                    DateOnly.TryParse(newCheckOutInput, out newCheckOutDate);
                                    break;
                                }
                                else if (ifCheckOutDateChoice.ToUpper() == "N")
                                {
                                    break;
                                }
                                else if (string.IsNullOrEmpty(ifCheckOutDateChoice))
                                {
                                    Console.WriteLine("Du måste ange J eller N  (Ja eller Nej)");
                                }
                                else
                                {
                                    Console.WriteLine("Du måste ange J eller N  (Ja eller Nej)");
                                }
                            }
                            else if (string.IsNullOrEmpty(ifCheckInDatechoice))
                            {
                                Console.WriteLine("Du måste ange J eller N  (Ja eller Nej)");
                            }
                            else
                            {
                                Console.WriteLine("Du måste ange J eller N  (Ja eller Nej)");
                            }
                        } while (true);

                        Console.WriteLine("\n(J/N)");
                        Console.Write("Vill du byta rum för bokningen? " +
                            "\nVal: ");
                        var ifnewRoomChoice = Console.ReadLine();
                        if (ifnewRoomChoice.ToUpper() == "J")
                        {
                            var availableRooms = dbUpdateBooking.Rooms
                                    .Where(r => r.IsRoomActive && !dbUpdateBooking.Bookings
                                    .Any(b => b.RoomId == r.RoomId && newCheckInDate < b.CheckOutDate && newCheckOutDate > b.CheckInDate
                                    || b.RoomId == r.RoomId && b.CheckInDate < b.CheckOutDate && b.CheckOutDate > b.CheckInDate))
                                    .ToList();
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

                                int roomId;
                                int extraBed = 0;
                                string extraBedString = null;
                                Console.Write("\nAnge id för rummet som ska bytas till: ");
                                if (int.TryParse(Console.ReadLine(), out roomId))
                                {
                                    var newRoomToBook = dbUpdateBooking.Rooms
                                        .Find(roomId);
                                    if (newRoomToBook != null)
                                    {

                                        do
                                        {
                                            if (newRoomToBook.RoomType == "Dubbelrum")
                                            {
                                                Console.WriteLine("\nDet nya rummet är ett dubbelrum!" +
                                                    "\nÖnskar du en extra säng? (J/N)" +
                                                    "\nVal: ");
                                                var extraBedChoice = Console.ReadLine();
                                                if (extraBedChoice.ToUpper() == "J")
                                                {
                                                    extraBed = 1;
                                                    extraBedString = "JA";
                                                    break;
                                                }
                                                else if (extraBedChoice.ToUpper() == "N")
                                                {
                                                    extraBed = 0;
                                                    extraBedString = "NEJ";
                                                    break;
                                                }
                                                else if (string.IsNullOrEmpty(extraBedChoice))
                                                {
                                                    Console.WriteLine("Du måste ange J eller N (Ja eller Nej)");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Du måste ange J eller N (Ja eller Nej)");

                                                }
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        } while (true);

                                        do
                                        {
                                            var oldRoomToRemove = dbUpdateBooking.Rooms.Find(bookingToEdit.RoomId);
                                            int newNumberOfGuests = 0;
                                            Console.WriteLine("\n(J/N)");
                                            Console.Write("Vill du ändra antalet gäster? " +
                                                "\nVal:");
                                            var guestCapacityChoice = Console.ReadLine();
                                            if (guestCapacityChoice.ToUpper() == "J")
                                            {
                                                Console.WriteLine($"\nMax ({chosenBooking.Capacity}) gäster i rummet");
                                                Console.WriteLine($"Inkludera {chosenBooking.LastName}, {chosenBooking.LastName} ");
                                                Console.Write("Ange hur många gäster som ska sova i rummet?: ");
                                                if (int.TryParse(Console.ReadLine(), out newNumberOfGuests))
                                                {
                                                    bookingToEdit.ExtraBed = extraBed;
                                                    bookingToEdit.RoomId = roomId;
                                                    oldRoomToRemove.IsOccupied = false;
                                                    newRoomToBook.IsOccupied = true;
                                                    bookingToEdit.CheckInDate = newCheckInDate;
                                                    bookingToEdit.CheckOutDate = newCheckOutDate;
                                                    bookingToEdit.NumberOfGuests = newNumberOfGuests;
                                                    dbUpdateBooking.SaveChanges();
                                                    Console.WriteLine("\nBoknings info är uppdaterad");
                                                    Console.WriteLine($"Gäst: {chosenBooking.LastName}, {chosenBooking.FirstName}");
                                                    Console.WriteLine($"Rum: {newRoomToBook.RoomNumber}");
                                                    Console.WriteLine($"Checkar in: {newCheckInDate}");
                                                    Console.WriteLine($"Checkar ut: {newCheckOutDate}");
                                                    Console.WriteLine($"Antal gäster: {chosenBooking.NumberOfGuests}");
                                                    Console.WriteLine($"ExtraSäng: {extraBedString}");
                                                    break;
                                                }
                                            }
                                            else if (guestCapacityChoice.ToUpper() == "N")
                                            {
                                                bookingToEdit.ExtraBed = extraBed;
                                                bookingToEdit.RoomId = roomId;
                                                oldRoomToRemove.IsOccupied = false;
                                                newRoomToBook.IsOccupied = true;
                                                bookingToEdit.CheckInDate = newCheckInDate;
                                                bookingToEdit.CheckOutDate = newCheckOutDate;
                                                dbUpdateBooking.SaveChanges();
                                                Console.WriteLine("\nBoknings info är uppdaterad");
                                                Console.WriteLine($"Gäst: {chosenBooking.LastName}, {chosenBooking.FirstName}");
                                                Console.WriteLine($"Rum: {newRoomToBook.RoomNumber}");
                                                Console.WriteLine($"Checkar in: {newCheckInDate}");
                                                Console.WriteLine($"Checkar ut: {newCheckOutDate}");
                                                Console.WriteLine($"Antal gäster: {bookingToEdit.NumberOfGuests}");
                                                Console.WriteLine($"ExtraSäng: {extraBedString}");
                                                break;
                                            }
                                            else if (string.IsNullOrEmpty(guestCapacityChoice))
                                            {
                                                Console.WriteLine("Du måste ange J eller N (Ja eller Nej)");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Du måste ange J eller N (Ja eller Nej)");
                                            }
                                        } while (true);

                                    }
                                }
                                else if (roomId == 0)
                                {
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("\nError!!! du måste ange en siffra (ID)");
                                }
                            }

                        }
                        else if (ifnewRoomChoice.ToUpper() == "N")
                        {

                            int newNumberOfGuests = 0;
                            Console.WriteLine("\n(J/N)");
                            Console.WriteLine("Vill du ändra antalet gäster? ");
                            var guestCapacityChoice = Console.ReadLine();
                            if (guestCapacityChoice.ToUpper() == "J")
                            {
                                Console.WriteLine($"\nMax ({chosenBooking.Capacity}) gäster i rummet");
                                Console.WriteLine($"Inkludera {chosenBooking.LastName}, {chosenBooking.LastName} ");
                                Console.Write("Ange hur många gäster som ska sova i rummet?: ");
                                if (int.TryParse(Console.ReadLine(), out newNumberOfGuests))
                                {
                                    bookingToEdit.CheckInDate = newCheckInDate;
                                    bookingToEdit.CheckOutDate = newCheckOutDate;
                                    bookingToEdit.NumberOfGuests = newNumberOfGuests;
                                    dbUpdateBooking.SaveChanges();
                                    Console.WriteLine("\nBoknings info är uppdaterad");
                                    Console.WriteLine($"Gäst: {chosenBooking.LastName}, {chosenBooking.FirstName}");
                                    Console.WriteLine($"Rum: {chosenBooking.RoomNumber}");
                                    Console.WriteLine($"Checkar in: {newCheckInDate}");
                                    Console.WriteLine($"Checkar ut: {newCheckOutDate}");
                                    Console.WriteLine($"Antal gäster: {chosenBooking.NumberOfGuests}");
                                }
                            }
                            else if (guestCapacityChoice.ToUpper() == "N")
                            {
                                bookingToEdit.CheckInDate = newCheckInDate;
                                bookingToEdit.CheckOutDate = newCheckOutDate;
                                dbUpdateBooking.SaveChanges();
                                Console.WriteLine("\nBoknings info är uppdaterad");
                                Console.WriteLine($"Gäst: {chosenBooking.LastName}, {chosenBooking.FirstName}");
                                Console.WriteLine($"Rum: {chosenBooking.RoomNumber}");
                                Console.WriteLine($"Checkar in: {newCheckInDate}");
                                Console.WriteLine($"Checkar ut: {newCheckOutDate}");
                                Console.WriteLine($"Antal gäster: {bookingToEdit.NumberOfGuests}");
                            }
                            else if (string.IsNullOrEmpty(guestCapacityChoice))
                            {
                                Console.WriteLine("Du måste ange J eller N (Ja eller Nej)");
                            }
                            else
                            {
                                Console.WriteLine("Du måste ange J eller N (Ja eller Nej)");
                            }
                        }
                        else if (string.IsNullOrEmpty(ifnewRoomChoice))
                        {
                            Console.WriteLine("Du måste ange J eller N (Ja eller Nej)");
                        }
                        else
                        {
                            Console.WriteLine("Du måste ange J eller N (Ja eller Nej)");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error!!! Bokningen hittades inte...");
                    }
                }
                else if (bookingId == 0)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Error!!! Du måste ange en siffra (ID)");
                }

            }
        }
    }
}
