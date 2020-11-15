using System;
using System.Collections.Generic;
using System.Text;

namespace Baza_DanychBiblioteka
{
    public class Baza
    {
        List<Uzytkownik> baza_uzytkownikow;

        public Baza()
        {
            baza_uzytkownikow = new List<Uzytkownik>();
            try
            {
                Pliki.odczytajZPliku(baza_uzytkownikow);
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void dodajUzytkownika(string imie, string nazwisko, string haslo, string przedmiot, int indeks, char typUzytkownika)
        {
            baza_uzytkownikow.Add(new Uzytkownik(imie, nazwisko, haslo, przedmiot, indeks, typUzytkownika));
            synchronizuj();
        }

        public void usunUzytkownika(Uzytkownik uzytkownik)
        {
            baza_uzytkownikow.Remove(uzytkownik);
            synchronizuj();
        }

        public void dodajOcene(int indeks, int ocena, string przedmiot)
        {
            try
            {
                baza_uzytkownikow.Find(x => x.indeks.Equals(indeks) && x.przedmiot.Equals(przedmiot)).dodajOcene(ocena);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
            synchronizuj();
        }

        public void odczytajOceny(int indeks, string przedmiot)
        {
            try
            {
                Console.WriteLine("Oto oceny ucznia o indeksie " + indeks + " z przedmiotu " + przedmiot + ": ");
                baza_uzytkownikow.Find(x => x.indeks.Equals(indeks) && x.przedmiot.Equals(przedmiot)).odczytajOcene();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void synchronizuj()
        {
            Pliki.zapiszDoPliku(baza_uzytkownikow);
            Console.WriteLine("Zapisano do pliku!");
        }
    }
}
