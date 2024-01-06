using HotelLibrary.Rooms;
using HotelLibrary.Rooms.DeleteRooms;
using HotelLibrary.Rooms.ReadingRooms;
using HotelLibrary.Rooms.UpdateRooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Build.Service
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        [Range(101, 520)]
        public int RoomNumber { get; set; }

        [Required]
        [Range(1, 4)]
        public int Capacity { get; set; }

        public bool IsOccupied { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerNight { get; set; }

        [Required]
        public string RoomType { get; set; } = string.Empty;

        [Required]
        public int RoomSize { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;

        public bool IsRoomActive { get; set; }

        
    }
}



//--lägg till foreign keys[V]