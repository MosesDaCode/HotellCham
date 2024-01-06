using HotelLibrary.Build.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Bookings.ReadingBookings
{
    public class ReadingPaidBookings
    {
        public static void ReadPaidBookings()
        {
            Console.Clear();
            using (var dbReadPaidBookings = new HotelChamDbContext())
            {
                var allBookings = (
                    from b in dbReadPaidBookings.Bookings
                    join g in dbReadPaidBookings.Guests on b.GuestId equals g.GuestId
                    join r in dbReadPaidBookings.Rooms on b.RoomId equals r.RoomId
                    where r.IsOccupied == true && b.IsPaid == true
                    select new
                    {
                        b.RoomId,
                        r.RoomNumber,
                        r.Capacity,
                        r.RoomType,
                        r.Description,
                        r.PricePerNight,
                        b.TotalPrice,
                        g.LastName,
                        g.FirstName,
                        b.IsCheckedIn,
                        b.ExtraBed,
                        b.IsPaid
                    }).ToList();
                if (allBookings.Any(b => b.IsPaid == true))
                {
                    Console.WriteLine("Lista av alla bokningar");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    foreach (var bookings in allBookings)
                    {
                        Console.WriteLine($"Gäst: {bookings.LastName}, {bookings.FirstName}");
                        Console.WriteLine($"Rumsnummer: {bookings.RoomNumber}");
                        Console.WriteLine($"Antal gäster: {bookings.Capacity}");
                        Console.WriteLine($"Extra säng: {bookings.ExtraBed}");
                        Console.WriteLine($"Rums typ: {bookings.RoomType}");
                        Console.WriteLine($"Rums beskrivning: {bookings.Description}");
                        Console.WriteLine($"Pris per natt: {bookings.PricePerNight}");
                        Console.WriteLine($"TotalPris: {bookings.TotalPrice}");
                        Console.WriteLine($"Checkat in: {bookings.IsCheckedIn}");
                        Console.WriteLine($"Betalad: {bookings.IsPaid}");
                        Console.WriteLine("---------------------------------------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("\nHär finns inga betalda bokningar!!!");
                }


            }
        }
    }
}
