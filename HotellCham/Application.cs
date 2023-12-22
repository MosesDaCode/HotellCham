using HotelLibrary;
using HotelLibrary.Build;
using HotelLibrary.Build.HotelData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellCham
{
    public class Application
    {
        public void Run()
        {
            var configDb = new ConfigBuilder();
            configDb.BuildDb();

            bool mainMenuIsRunning = true;
            while (mainMenuIsRunning)
            {
                switch (Menu.MainMenu())
                {
                    case "1":
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Guest.GuestMenu();
                        break;
                    case "4":
                        Console.Clear();
                        Room.RoomMenu();
                        break;
                    case "5":
                        Console.Clear();
                        Booking.BookingMenu();
                        break;
                    case "6":
                        Console.Clear();
                        Invoice.InvoiceMenu();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("-----------");
                        Console.WriteLine("|  Hejdå  |");
                        Console.WriteLine("-----------");
                        Environment.Exit(0);

                        break;
                    default:
                        Console.WriteLine("Fel val av meny tryck på enter och testa igen.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
