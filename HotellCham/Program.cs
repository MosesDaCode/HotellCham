using HotelLibrary;
using HotelLibrary.Build.Service;

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



//--lägg till country och city på en guest. [V]
//--lägg till foreign keys[V]
//--Gör ett ERD[V]
//Skapa ett admin alternativ med password.
//--lägg in PUT (ge användaren alternativ på vad som ska uppdateras) (inkludera avaktivera) [V]
//--Fixa så att den skippar counrty och city om man skippar hem adress[V]