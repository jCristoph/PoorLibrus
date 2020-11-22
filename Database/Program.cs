using System;
using DatabaseLibrary;

namespace Baza_Danych
{
    class Program
    {
        static void Main(string[] args)
        {
            Base b = new Base();
            /*
            b.addUser("Jan", "Nowak", "now123ak", "matematyka5", 10001, 's');
            b.addUser("Anna", "Kowalska", "annkaaa", "matematyka5", 10002, 's');
            b.addUser("Tomasz", "Kruk", "taaaa123", "matematyka5", 10003, 's');
            b.addUser("Oliwia", "Wolna", "oli134", "matematyka5", 10004, 's');
            b.addUser("Adam", "Gruszka", "wojak16", "matematyka5", 10005, 's');
            b.addUser("Aneta", "Miklaszewski", "bsad432", "matematyka5", 10006, 's');
            b.addUser("Martyna", "Grys", "kjbdas125", "matematyka5", 10007, 's');
            b.addUser("Aleksandra", "Cicha", "124jnouh32", "matematyka5", 10008, 's');
            b.addUser("Grzegorz", "Kluska", "dsjfb567", "matematyka5", 10009, 's');
            b.addUser("Krzysztof", "Bombka", "fksb29", "matematyka5", 10010, 's');
            b.addUser("Karol", "Szymczak", "1kjsd3", "matematyka5", 10011, 's');
            b.addUser("Karolina", "Kacperska", "asdiy", "matematyka5", 10012, 's');
            b.addUser("Szymon", "Kowal", "198gsa", "matematyka5", 10013, 's');
            b.addUser("Lidia", "Kalisiak", "jbjdsf04", "matematyka5", 10014, 's');
            b.addUser("Arkadiusz", "Wojtkowiak", "osadb983", "matematyka5", 10015, 's');
            b.addUser("Anna", "Bartkowiak", "iusdfg92", "matematyka5", 10016, 's');

            b.addUser("Jan", "Nowak", "now123ak", "chemia5", 10001, 's');
            b.addUser("Anna", "Kowalska", "annkaaa", "chemia5", 10002, 's');
            b.addUser("Tomasz", "Kruk", "taaaa123", "chemia5", 10003, 's');
            b.addUser("Oliwia", "Wolna", "oli134", "chemia5", 10004, 's');
            b.addUser("Adam", "Gruszka", "wojak16", "chemia5", 10005, 's');
            b.addUser("Aneta", "Miklaszewski", "bsad432", "chemia5", 10006, 's');
            b.addUser("Martyna", "Grys", "kjbdas125", "chemia5", 10007, 's');
            b.addUser("Aleksandra", "Cicha", "124jnouh32", "chemia5", 10008, 's');
            b.addUser("Grzegorz", "Kluska", "dsjfb567", "chemia5", 10009, 's');
            b.addUser("Krzysztof", "Bombka", "fksb29", "chemia5", 10010, 's');
            b.addUser("Karol", "Szymczak", "1kjsd3", "chemia5", 10011, 's');
            b.addUser("Karolina", "Kacperska", "asdiy", "chemia5", 10012, 's');
            b.addUser("Szymon", "Kowal", "198gsa", "chemia5", 10013, 's');
            b.addUser("Lidia", "Kalisiak", "jbjdsf04", "chemia5", 10014, 's');
            b.addUser("Arkadiusz", "Wojtkowiak", "osadb983", "chemia5", 10015, 's');
            b.addUser("Anna", "Bartkowiak", "iusdfg92", "chemia5", 10016, 's');

            b.addUser("Czeslaw", "Kaminski", "Nauczyciel1", "matematyka5", 90001, 'n');
            b.addUser("Anna", "Dziedzic", "kjsdCV24", "chemia5", 90002, 'n');
            */

            //b.addGrade(10002, 5, "matematyka5");
            // b.addGrade(10002, 2, "chemia5");

            b.readGrades(10002, "matematyka5");
            b.readGrades(10002, "chemia5");

        }
    }
}
