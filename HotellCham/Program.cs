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
 *      -Ändra från Gäst till Rum mm? under menyn när du ska avvaktivera rum
 *      -Ta bort sista raden "Tryck på enter och försök igen" under menyn ändra pris på rum 
 *      -Ändra bekräftelsebeskrivning "Rum: 192 är nu 509 KVM." till relevant text för ändringen av Rumsbeskrivning
 *      -Vid återaktivera rum så behöver du ändra på felmeddelande när du bara trycker på enter. Just nu får du två felmeddelanden.
 *      -Ser út som att du kan boka ett avvaktiverat rum i "skapa bokning"
 *      -Det går att boka Checkut-datum tidigare än checkin-datum.
 *      -Fixa så det inte går att boka samma datum för checkin och checkout
 *      -Ange vettig felmeddelande vid fel inmatning av data checkin (säkert checkout?)
 *      -får ej fortsätta om input är högre än maxkapacitet i rumsbokningen.
 *      -skriver inte ut bokningsbekräftelse när bokningen är klar.
 *      -sparar inte bokningen i databasen - kan ha med föregående punkt att göra.
 */