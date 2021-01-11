using System;
using System.Collections.Generic;

/*
 * Prymitywna baza danych oparta na rekordach:
 * login password index firstName name subject userType grades[20]
 * Plik tekstowy w ktorym znajduje sie baza danych jest zaszyfrowany szyfrem Vigenera
 * w przypadku nauczycieli istnieje tabela z ocenami lecz jest ona pusta - wypelniona zerami - dla latwiejszej konwersji pliku tekstowego w liste obiektow
 * Moze pojawiac sie wiele obiektow o tych samych indeksach imionach itp ale rozniacymi sie przedmiotami i ocenami.
 * Baza danych moze byc zarzadzana tylko poprzez Admina
 * 
 * Logujac sie do bazy danych tak naprawde bedziemy logowac tylu uzytkownikow ile dany ma przydzielonych przedmiotow - po zalogowaniu bedzie mogl wybrac ktory przedmiot wybiera
 */

namespace DatabaseLib
{
    public class Base
    {
        public List<User> userDatabase;

        public Base()
        {
            userDatabase = new List<User>();
            userDatabase.Add(new Admin("Jedrzej", "Krysztof", "database123", "administracja", 99999));
            try
            {
                Files.readFile(userDatabase);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void sync()
        {
            Files.saveFile(userDatabase);
        }

        public int length()
        {
            return userDatabase.Count;
        }

        public User getUser(int i) {
            return userDatabase[i];
        }
    }
}
