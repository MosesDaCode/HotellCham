using HotelLibrary.Build;
using HotelLibrary.Guests.DeleteGuests;
using HotelLibrary.Guests.ReadGuests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Guests
{
     public class DisplayGuestMenu
    {
        public static void GuestMenu()
        {
            bool isGuest = true;
            while (isGuest)
            {
                Console.Clear();
                switch (DisplayMenu.WriteGuestMenu())
                {
                    case "1":
                        GuestCreation.CreateGuest();
                        break;
                    case "2":
                        DisplayReadGuestMenu.ReadGuests();
                        break;
                    case "3":
                        GuestUpdate.UpdateGuest();
                        break;
                    case "4":
                        SoftDeleteGuests.SoftDeleteGuest();
                        break;
                    case "5":
                        ReActiveateGuest.GetGuestBack();
                        break;
                    case "6":
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
