using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Invoices
{
    public class DisplayInvoiceMenu
    {
        public static void InvoiceMenu()
        {
            bool isInvoice = true;
            while (isInvoice)
            {
                switch (DisplayMenu.WriteInvoiceMenu())
                {
                    case "1":
                        Console.WriteLine("Under Konstruktion,Tryck på enter för att gå tillbaka till huvudmenyn!!");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    case "2":
                        Console.WriteLine("Under Konstruktion,Tryck på enter för att gå tillbaka till huvudmenyn!!");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    case "3":
                        Console.WriteLine("Under Konstruktion,Tryck på enter för att gå tillbaka till huvudmenyn!!");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    case "4":
                        Console.WriteLine("Under Konstruktion,Tryck på enter för att gå tillbaka till huvudmenyn!!");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    case "5":
                        Console.WriteLine("Under Konstruktion,Tryck på enter för att gå tillbaka till huvudmenyn!!");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    case "0":
                        Console.Clear();
                        isInvoice = false;
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
