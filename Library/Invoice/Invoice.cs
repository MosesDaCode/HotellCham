using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Invoice
{
    public class Invoice
    {   
        public int InvoiceID { get; set; }
        public int BookingID {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public static void InvoiceMenu()
        {
            bool isInvoice = true;
            while (isInvoice)
            {
                switch (Menu.WriteInvoiceMenu())
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
