using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HotelLibrary
{
    public class Menu
    {
        public static string MainMenu()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("| Hotell Cham  |");
            Console.WriteLine("----------------\n\n");

            Console.WriteLine("-------------------------");
            Console.WriteLine("| 1. Checka in          |");
            Console.WriteLine("| 2. Checka ut          |");
            Console.WriteLine("| 3. Gäst meny          |");
            Console.WriteLine("| 4. Rums meny          |");
            Console.WriteLine("| 5. Boknings meny      |");
            Console.WriteLine("| 6. Faktura meny       |");
            Console.WriteLine("| 0. Avsluta            |");
            Console.WriteLine("-------------------------");
            Console.Write("Val: ");
            string mainChoice = Console.ReadLine();
            return mainChoice;
        }
        public static string WriteGuestMenu()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("| Gäst meny   |");
            Console.WriteLine("--------------\n\n");

            Console.WriteLine("------------------------------");
            Console.WriteLine("| 1. Skapa ny gäst           |");
            Console.WriteLine("| 2. Se aktiva gäster        |");
            Console.WriteLine("| 3. Se icke aktiva gäster   |");
            Console.WriteLine("| 4. Ändra gäst info         |");
            Console.WriteLine("| 5. Avaktivera gäst         |");
            Console.WriteLine("| 6. Återaktivera gäst       |");
            Console.WriteLine("| 7. Radera gäst ur systemet |");
            Console.WriteLine("| 0. Gå tillbaka             |");
            Console.WriteLine("------------------------------");
            Console.Write("Val: ");
            string guestChoice = Console.ReadLine();
            return guestChoice;
        }

        public static string WriteRoomMenu()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("| Rums meny  |");
            Console.WriteLine("--------------\n\n");

            Console.WriteLine("-------------------------------");
            Console.WriteLine("| 1. Skapa ett rum            |");
            Console.WriteLine("| 2. Se rum                   |");
            Console.WriteLine("| 3. Ändra rums info          |");
            Console.WriteLine("| 5. Avaktivera rum           |");
            Console.WriteLine("| 4. Radera rum ur systemet   |");
            Console.WriteLine("| 0. Gå tillbaka              |");
            Console.WriteLine("-------------------------------");
            Console.Write("Val: ");
            string roomChoice = Console.ReadLine();
            return roomChoice;
        }
        public static string WriteBookingMenu()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("| Bokings meny  |");
            Console.WriteLine("-----------------\n\n");

            Console.WriteLine("------------------------------");
            Console.WriteLine("| 1. Skapa en bokning        |");
            Console.WriteLine("| 2. Se bokningar            |");
            Console.WriteLine("| 3. Uppdatera bokning       |");
            Console.WriteLine("| 4. Radera bokning          |");
            Console.WriteLine("| 0. Gå tillbaka             |");
            Console.WriteLine("------------------------------");
            Console.Write("Val: ");
            string bookingChoice = Console.ReadLine();
            return bookingChoice;
        }

        public static string WriteInvoiceMenu()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("| Faktura meny  |");
            Console.WriteLine("-----------------\n\n");

            Console.WriteLine("------------------------------");
            Console.WriteLine("| 1. Skapa en faktura        |");
            Console.WriteLine("| 2. Se fakturor             |");
            Console.WriteLine("| 3. Uppdatera faktura       |");
            Console.WriteLine("| 4. Radera faktura          |");
            Console.WriteLine("| 0. Gå tillbaka             |");
            Console.WriteLine("------------------------------");
            Console.Write("Val: ");
            string invoiceChoice = Console.ReadLine();
            return invoiceChoice;
        }
        public static string ReadingRoomsMenu()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("| Välj vilka rum du vill se  |");
            Console.WriteLine("------------------------------\n\n");

            Console.WriteLine("------------------------------");
            Console.WriteLine("| 1. Se alla rum             |");
            Console.WriteLine("| 2. Se tillgängliga rum     |");
            Console.WriteLine("| 3. Se upptagna rum         |");
            Console.WriteLine("| 4. Se icke aktiva rum      |");
            Console.WriteLine("| 0. Gå tillbaka             |");
            Console.WriteLine("------------------------------");
            Console.Write("Val: ");
            string roomMenuChoice = Console.ReadLine();
            return roomMenuChoice;
        }
    }
}
