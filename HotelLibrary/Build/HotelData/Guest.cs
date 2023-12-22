using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelLibrary.Guests;
using HotelLibrary.Guests.DeleteGuests;
using HotelLibrary.Guests.ReadGuests;

namespace HotelLibrary.Build.HotelData
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Adress { get; set; }

        [Required]
        [MaxLength(35)]
        public string Country { get; set; } = string.Empty;

        [Required]
        [MaxLength (60)] // Hittade en stad/by i wales som heter "Llanfair­pwllgwyngyll­gogery­chwyrn­drobwll­llan­tysilio­gogo­goch" Det ska nog inte uttalas.
        public string City { get; set; } = string.Empty;

        public bool IsGuestActive { get; set; }

        public List<Booking> Booking { get; set; }

        public List<Invoice> InvoiceId { get; set; }

        public static void GuestMenu()
        {
            bool isGuest = true;
            while (isGuest)
            {
                switch (Menu.WriteGuestMenu())
                {
                    case "1":
                        GuestCreation.CreateGuest();
                        break;
                    case "2":
                        ReadingActiveGuest.ReadActiveGuests();
                        break;
                    case "3":
                        ReadingNonActiveGuest.ReadNonActiveGuests();
                        break;
                    case "4":
                        GuestUpdate.UpdateGuest();
                        break;
                    case "5":
                        SoftDeleteGuests.SoftDeleteGuest();
                        break;
                    case "6":
                        ReActiveateGuest.GetGuestBack();
                        break;
                    case "7":
                        Console.Clear();
                        GuestDelete.DeleteGuest();
                        break;
                    case "0":
                        Console.Clear();
                        isGuest = false;
                        break;
                    default:
                        Console.WriteLine("Fel val av meny tryck på enter och testa igen.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            }
        }

    }
}
