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



/*
·       Ett rum kan vara enkelrum eller dubbelrum. 
·       För dubbelrum kan gälla att det finns möjlighet till att sätta in extrasängar (1 eller 2 beroende på rummets storlek).
·       Ett rum kan bokas av en kund för en eller flera nätter.
*/

//--lägg till country och city på en guest. [V]
//--lägg till foreign keys[V]
//--Gör ett ERD[V]
//Skapa ett admin alternativ med password.
//--lägg in PUT (ge användaren alternativ på vad som ska uppdateras) (inkludera avaktivera) [V]
//--Fixa så att den skippar counrty och city om man skippar hem adress[V]
//--Skilj seedningen med ID:t (kolla alla tabeller) [V]
//OBS Se alla gäster läggs till i menyn
//--Vid raderingsfunktion av gäster så får inte användaren valet samt se inaktiva gäster. Tur nog är det bara menyn, du kan radera inaktiva gäster ändå. [V]
//--ta bort boka ny gäst [V]
//ange felmeddelande när man inte väljer bindestreck för bokningsdatum
//--FIXA från Singleroom till enkelrum i seedningen



// G kriterier
// --Lösningen måste göras objektorienterat. Koden skall fungera och applikationen skall gå att köra utan fel.
// --Det skall gå att registrera ett rum och rummets uppgifter skall kunna ändras.
// --Applikationen skall hantera ett antal rum.
// --Ett rum kan vara enkelrum eller dubbelrum.
// --För dubbelrum kan gälla att det finns möjlighet till att sätta in extrasängar (1 eller 2 beroende på rummets storlek).
// --Det skall gå att registrera en kund och kundens uppgifter skall kunna ändras.
// --Seed minst 4 rum
// --Seed minst 4 gäster
// --Ett rum kan bokas av en kund för en eller flera nätter.

// VG kriterier
// En kund kan tas bort endast om det inte finns några bokningar kopplade till kunden.
// Applikationen måste kontrollera om det finns bokningar innan den tar bort en kund.
// Applikationen skall hantera bokningar och visa vilka rum som är lediga under en viss period.
// Den skall också se till att det inte går att boka ett rum på ett datum där det redan finns en bokning.
// Det skall gå att avboka ett rum eller ändra en bokning. Det skall gå att söka på ett datum eller datumintervall och antal personer och få fram alla lediga rum som motsvarar sökningen.
// Till varje bokning skall det kopplas en betalning dvs en faktura.
// Applikationen skall kunna registrera en inkommen betalning på en faktura.
// Om inte en betalning registrerats inom 10 dagar efter att bokningen är gjord annulleras bokningen dvs den upphör att gälla.