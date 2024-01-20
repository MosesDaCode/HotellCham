using HotelLibrary.Bookings;
using HotelLibrary.Bookings.ReadingBookings;
using HotelLibrary.Bookings.UpdateBookings;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Build.Service
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int GuestId { get; set; }

        [Required]
        public DateOnly CheckInDate { get; set; }

        [Required]
        public DateOnly CheckOutDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }

        [Range(0, 2)]
        public int? ExtraBed { get; set; } = 0;

        [Required]
        public bool IsPaid { get; set; }

        [Required]
        public bool IsBookingActive { get; set; }

        [Required]
        public bool IsCheckedIn { get; set; }

        [Required]
        public int NumberOfGuests {  get; set; }

        [Required]
        public Room Room { get; set; }

        
    }
}



