using HotelLibrary;
using HotelLibrary.Build.HotelData;

namespace HotellCham
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            app.Run();
        }
    }
}



// lägg till country och city på en guest.
//lägg till foreign keys
//Gör ett ERD
//Skapa ett admin alternativ med password.
//lägg in PUT (ge användaren alternativ på vad som ska uppdateras) (inkludera avaktivera)
//Fixa så att den skippar counrty och city om man skippar hem adress