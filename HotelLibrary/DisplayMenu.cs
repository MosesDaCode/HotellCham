using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HotelLibrary
{
    public class DisplayMenu
    {
        public static string MainMenu()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("| Hotell Cham  |");
            Console.WriteLine("----------------\n\n");

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("| 1. Gäst meny                          |");
            Console.WriteLine("| 2. Rums meny                          |");
            Console.WriteLine("| 3. Boknings meny                      |");
            Console.WriteLine("| 4. Faktura meny (Under konstruktion)  |");
            Console.WriteLine("| 0. Avsluta                            |");
            Console.WriteLine("-----------------------------------------");
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
            Console.WriteLine("| 2. Se gäster               |");
            Console.WriteLine("| 3. Ändra gäst info         |");
            Console.WriteLine("| 4. Avaktivera gäst         |");
            Console.WriteLine("| 5. Återaktivera gäst       |");
            Console.WriteLine("| 6. Radera gäst ur systemet |");
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
            Console.WriteLine("| 4. Avaktivera rum           |");
            Console.WriteLine("| 5. Återaktivera rum         |");
            Console.WriteLine("| 6. Radera rum ur systemet   |");
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
            Console.WriteLine("| 1. Boka ett rum            |");
            Console.WriteLine("| 2. Se bokningar            |");
            Console.WriteLine("| 3. Ändra bokning           |");
            Console.WriteLine("| 4. Avboka                  |");
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
        public static string ReadingGuestsMenu()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("| Välj vilka gäster du vill se  |");
            Console.WriteLine("---------------------------------\n\n");

            Console.WriteLine("------------------------------");
            Console.WriteLine("| 1. Se alla gäster          |");
            Console.WriteLine("| 2. Se aktiva gäster        |");
            Console.WriteLine("| 3. Se icke aktiva gäster   |");
            Console.WriteLine("| 0. Gå tillbaka             |");
            Console.WriteLine("------------------------------");
            Console.Write("Val: ");
            string guestMenuChoice = Console.ReadLine();
            return guestMenuChoice;
        }
        public static string RoomUpdateMenu()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("| Välj egenskaper att ändra  |");
            Console.WriteLine("------------------------------\n\n");

            Console.WriteLine("------------------------------");
            Console.WriteLine("| 1. Ändra på hela rummet    |");
            Console.WriteLine("| 2. Ändra antal gäster      |");
            Console.WriteLine("| 3. Ändra pris på rummet    |");
            Console.WriteLine("| 4. Ändra rums typ          |");
            Console.WriteLine("| 5. Ändra rums storlek      |");
            Console.WriteLine("| 6. Ändra rums beskrivning  |");
            Console.WriteLine("| 0. Gå tillbaka             |");
            Console.WriteLine("------------------------------");
            Console.Write("Val: ");
            string roomUpdateMenuChoice = Console.ReadLine();
            return roomUpdateMenuChoice;
        }
        public static string ReadingBookingsMenu()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("| Välj vilka rum du vill se  |");
            Console.WriteLine("------------------------------\n\n");

            Console.WriteLine("------------------------------");
            Console.WriteLine("| 1. Se alla bokningar       |");
            Console.WriteLine("| 2. Se betalda bokningar    |");
            Console.WriteLine("| 3. Se obetalda bokningar   |");
            Console.WriteLine("| 0. Gå tillbaka             |");
            Console.WriteLine("------------------------------");
            Console.Write("Val: ");
            string bookingMenuChoice = Console.ReadLine();
            return bookingMenuChoice;
        }
        public static string BookingUpdateMenu()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("| Välj egenskaper att ändra  |");
            Console.WriteLine("------------------------------\n\n");

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("| 1. Ändra på hela bokningen           |");
            Console.WriteLine("| 2. Ändra på check in datum           |");
            Console.WriteLine("| 3. Ändra på check ut datum           |");
            Console.WriteLine("| 4. Ändra rum för bokning             |");
            Console.WriteLine("| 5. Ändra antal gäster för bokningen  |");
            Console.WriteLine("| 0. Gå tillbaka                       |");
            Console.WriteLine("----------------------------------------");
            Console.Write("Val: ");
            string bookingUpdateMenuChoice = Console.ReadLine();
            return bookingUpdateMenuChoice;
        }
    }
}
