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
                        //Pay Invoice
                        break;
                    case "2":
                        //Create Invoice
                        break;
                    case "3":
                        //Read Invoice
                        break;
                    case "4":
                        //Edit Invoice
                        break;
                    case "5":
                        //Delete Invoice
                        break;
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
