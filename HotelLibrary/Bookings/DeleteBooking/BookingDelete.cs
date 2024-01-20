using HotelLibrary.Bookings.ReadingBookings;
using HotelLibrary.Build.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Bookings.DeleteBooking
{
    public class BookingDelete
    {
        public static void DeleteBooking()
        {
            using (var dbBookingDelete = new HotelChamDbContext())
            {
                int bookingId;
                ReadingAllBookings.ReadAllBookings();
                {
                    Console.Write("\nAnge ID för bokningen som du vill ta bort:");
                    if (int.TryParse(Console.ReadLine(), out bookingId) && bookingId != 0)
                    {
                        var bookingToDelete =
                            (from b in dbBookingDelete.Bookings
                             join g in dbBookingDelete.Guests on b.GuestId equals g.GuestId
                             join r in dbBookingDelete.Rooms on b.RoomId equals r.RoomId
                             where b.BookingID == bookingId
                             select new
                             {
                                 Booking = b,
                                 Guest = g,
                                 Room = r
                             })
                             .FirstOrDefault();

                        if (bookingToDelete != null)
                        {
                            bookingToDelete.Room.IsOccupied = false;
                            dbBookingDelete.Bookings.Remove(bookingToDelete.Booking);
                            dbBookingDelete.SaveChanges();
                            Console.WriteLine($"\nGäst: {bookingToDelete.Guest.LastName}, {bookingToDelete.Guest.FirstName}");
                            Console.WriteLine($"Boknings nummer: {bookingId} är nu avbokad!");

                            Console.WriteLine("\nTryck på enter för att gå tillbaka...");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine($"\nBoknings ID {bookingId} existerar inte...");
                        }
                    }
                    else if (bookingId == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nError!!! Du måste ange en siffra (ID)");
                    }
                }
            }

        }
    }
}
