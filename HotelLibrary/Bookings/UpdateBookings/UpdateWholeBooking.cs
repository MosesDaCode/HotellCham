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
    public class UpdateWholeBooking
    {
        public static void UpdateAllBookingFeatures()
        {
            using (var dbUpdateBooking = new HotelChamDbContext())
            {
                ReadingAllBookings.ReadAllBookings();
                Console.WriteLine("\nDu ska nu ändra på:");
                Console.WriteLine("Check in datum");
                Console.WriteLine("Check out datum");
                Console.WriteLine("Byta rum för bokingen");
                Console.WriteLine("Ändra antal gäster för bokningen");
                Console.WriteLine("Ange 0 för att gå tillbaka\n\n");

                int bookingId;

                Console.Write("Ange bokningens id ifrån ovan: ");
                if (int.TryParse(Console.ReadLine(), out bookingId))
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

                        DateTime newCheckOutDate = DateTime.MinValue;
                        Console.WriteLine("\n(yyyy-MM-dd)");
                        Console.Write("Ange ett nytt check in datum: ");
                        var newCheckInInput = Console.ReadLine();
                        if (newCheckInInput == "0")
                        {
                            Console.Clear();
                            return;
                        }
                        else if (string.IsNullOrEmpty(newCheckInInput))
                        {
                            Console.WriteLine("\nAnge ett datum med (yyyy-MM-dd)");
                        }
                        if (DateTime.TryParse(newCheckInInput, out DateTime newCheckInDate))
                        {
                            newCheckInDate = bookingToEdit.CheckInDate;
                            if (newCheckInDate >= DateTime.Now)
                            {
                                Console.WriteLine("\n(yyyy-MM-dd)");
                                Console.Write("Ange ett nytt datum att checka ut: ");
                                var newCheckOutInput = Console.ReadLine();
                                if (newCheckOutInput == "0")
                                {
                                    Console.Clear();
                                    return;
                                }
                                else if (string.IsNullOrEmpty(newCheckOutInput))
                                {
                                    Console.WriteLine("\nAnge ett datum med (yyyy-MM-dd)");
                                }
                                DateTime.TryParse(newCheckOutInput, out  newCheckOutDate);
                                newCheckOutDate = bookingToEdit.CheckOutDate;
                            }
                        }
                        int roomId;
                        ReadingAvailableRoom.ReadAvailableRooms();
                        Console.Write("Ange id för rummet som ska bytas till: ");
                        if (int.TryParse(Console.ReadLine(), out roomId)) //lägg till fråga om säng If (dubbelrum)
                        {
                            var newRoomToBook = dbUpdateBooking.Rooms
                                .Find(roomId);
                            bookingToEdit.RoomId = roomId;
                            if (newRoomToBook != null)
                            {

                                //KRAAAAASSHHHH
                                int newNumberOfGuests = 0; 
                                Console.WriteLine("Vill du ändra antalet gäster? (J/N)");
                                var guestCapacityChoice = Console.ReadLine();
                                if (guestCapacityChoice.ToUpper() == "J")
                                {
                                    Console.WriteLine($"\nMax ({chosenBooking.Capacity}) gäster i rummet");
                                    Console.WriteLine($"Exclusive {chosenBooking.LastName}, {chosenBooking.LastName} ");
                                    Console.Write("Ange hur många gäster som ska sova i rummet?: ");
                                    if(int.TryParse(Console.ReadLine(), out  newNumberOfGuests))
                                    {
                                        bookingToEdit.CheckInDate = newCheckInDate;
                                        bookingToEdit.CheckOutDate = newCheckOutDate;
                                        bookingToEdit.NumberOfGuests = newNumberOfGuests;
                                        dbUpdateBooking.SaveChanges();
                                        Console.WriteLine("\nBoknings info är uppdaterad");
                                        Console.WriteLine($"Gäst: {chosenBooking.LastName}, {chosenBooking.FirstName}");
                                        Console.WriteLine($"Rum: {newRoomToBook.RoomNumber}");
                                        Console.WriteLine($"Checkar in: {bookingToEdit.CheckInDate}");
                                        Console.WriteLine($"Checkar ut: {bookingToEdit.CheckOutDate}");
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
                                    Console.WriteLine($"Rum: {newRoomToBook.RoomNumber}");
                                    Console.WriteLine($"Checkar in: {newCheckInDate}");
                                    Console.WriteLine($"Checkar ut: {bookingToEdit.CheckOutDate}");
                                    Console.WriteLine($"Antal gäster: {bookingToEdit.NumberOfGuests}");
                                }
                            }
                        }
                        else if (roomId == 0)
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Error!!! du måste ange en siffra (ID)");
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
