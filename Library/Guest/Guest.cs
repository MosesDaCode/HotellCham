using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Guest
{
    public class Guest
    {
        int GuestId { get; set; }
        string Name { get; set; } = string.Empty;
        string Email { get; set; } = string.Empty;
        int Phone { get; set; }
        string? Adress { get; set; }

        public static void GuestMenu()
        {
            bool isGuest = true;
            while (isGuest)
            {
                switch (Menu.WriteGuestMenu())
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
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
