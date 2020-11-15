using System;
using Baza_DanychBiblioteka;

namespace Baza_Danych
{
    class Program
    {
        static void Main(string[] args)
        {
            Baza b = new Baza();
            /*
            b.dodajUzytkownika("Jan", "Nowak", "now123ak", "matematyka5", 10001, 's');
            b.dodajUzytkownika("Anna", "Kowalska", "annkaaa", "matematyka5", 10002, 's');
            b.dodajUzytkownika("Tomasz", "Kruk", "taaaa123", "matematyka5", 10003, 's');
            b.dodajUzytkownika("Oliwia", "Wolna", "oli134", "matematyka5", 10004, 's');
            b.dodajUzytkownika("Adam", "Gruszka", "wojak16", "matematyka5", 10005, 's');
            b.dodajUzytkownika("Aneta", "Miklaszewski", "bsad432", "matematyka5", 10006, 's');
            b.dodajUzytkownika("Martyna", "Grys", "kjbdas125", "matematyka5", 10007, 's');
            b.dodajUzytkownika("Aleksandra", "Cicha", "124jnouh32", "matematyka5", 10008, 's');
            b.dodajUzytkownika("Grzegorz", "Kluska", "dsjfb567", "matematyka5", 10009, 's');
            b.dodajUzytkownika("Krzysztof", "Bombka", "fksb29", "matematyka5", 10010, 's');
            b.dodajUzytkownika("Karol", "Szymczak", "1kjsd3", "matematyka5", 10011, 's');
            b.dodajUzytkownika("Karolina", "Kacperska", "asdiy", "matematyka5", 10012, 's');
            b.dodajUzytkownika("Szymon", "Kowal", "198gsa", "matematyka5", 10013, 's');
            b.dodajUzytkownika("Lidia", "Kalisiak", "jbjdsf04", "matematyka5", 10014, 's');
            b.dodajUzytkownika("Arkadiusz", "Wojtkowiak", "osadb983", "matematyka5", 10015, 's');
            b.dodajUzytkownika("Anna", "Bartkowiak", "iusdfg92", "matematyka5", 10016, 's');

            b.dodajUzytkownika("Jan", "Nowak", "now123ak", "chemia5", 10001, 's');
            b.dodajUzytkownika("Anna", "Kowalska", "annkaaa", "chemia5", 10002, 's');
            b.dodajUzytkownika("Tomasz", "Kruk", "taaaa123", "chemia5", 10003, 's');
            b.dodajUzytkownika("Oliwia", "Wolna", "oli134", "chemia5", 10004, 's');
            b.dodajUzytkownika("Adam", "Gruszka", "wojak16", "chemia5", 10005, 's');
            b.dodajUzytkownika("Aneta", "Miklaszewski", "bsad432", "chemia5", 10006, 's');
            b.dodajUzytkownika("Martyna", "Grys", "kjbdas125", "chemia5", 10007, 's');
            b.dodajUzytkownika("Aleksandra", "Cicha", "124jnouh32", "chemia5", 10008, 's');
            b.dodajUzytkownika("Grzegorz", "Kluska", "dsjfb567", "chemia5", 10009, 's');
            b.dodajUzytkownika("Krzysztof", "Bombka", "fksb29", "chemia5", 10010, 's');
            b.dodajUzytkownika("Karol", "Szymczak", "1kjsd3", "chemia5", 10011, 's');
            b.dodajUzytkownika("Karolina", "Kacperska", "asdiy", "chemia5", 10012, 's');
            b.dodajUzytkownika("Szymon", "Kowal", "198gsa", "chemia5", 10013, 's');
            b.dodajUzytkownika("Lidia", "Kalisiak", "jbjdsf04", "chemia5", 10014, 's');
            b.dodajUzytkownika("Arkadiusz", "Wojtkowiak", "osadb983", "chemia5", 10015, 's');
            b.dodajUzytkownika("Anna", "Bartkowiak", "iusdfg92", "chemia5", 10016, 's');

            b.dodajUzytkownika("Czeslaw", "Kaminski", "Nauczyciel1", "matematyka5", 90001, 'n');
            b.dodajUzytkownika("Anna", "Dziedzic", "kjsdCV24", "chemia5", 90002, 'n');
            */

            //b.dodajOcene(10002, 5, "matematyka5");
           // b.dodajOcene(10002, 2, "chemia5");

            b.odczytajOceny(10002, "matematyka5");
            b.odczytajOceny(10002, "chemia5");

        }
    }
}
