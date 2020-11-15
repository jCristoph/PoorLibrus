using System;
using System.Text;

namespace Baza_DanychBiblioteka
{
	public class Uzytkownik
	{
		private string login;
		private string haslo;
		private string imie;
		private string nazwisko;
		public string przedmiot;
		private char typUzytkownika;
		public int indeks { get; set; }
		private int[] oceny;

		public Uzytkownik()
		{
			login = "s10000";
			haslo = "";
			imie = "Imie";
			nazwisko = "Nazwisko";
			przedmiot = "Przedmiot";
			typUzytkownika = ' ';
			indeks = 10000;
			oceny = new int[20];
		}

		public Uzytkownik(string imie, string nazwisko, string haslo, string przedmiot, int indeks, char typUzytkownika)
        {
			this.imie = imie;
			this.nazwisko = nazwisko;
			this.haslo = haslo;
			this.przedmiot = przedmiot;
			this.indeks = indeks;
			this.typUzytkownika = typUzytkownika;
			login = typUzytkownika.ToString() + indeks;
			oceny = new int[20];
		}

		public Uzytkownik(string uzytkownik)
        {
			string[] u = uzytkownik.Split();
			login = u[0];
			haslo = u[1];
			indeks = Int32.Parse(u[2]);
			imie = u[3];
			nazwisko = u[4];
			przedmiot = u[5];
			typUzytkownika = Convert.ToChar(u[6]);
			oceny = new int[20];
			for(int i = 7; i < u.Length; i++)
            {
				oceny[i - 7] = Int32.Parse(u[i]);
			}
		}

		public void dodajOcene(int ocena)
		{
			for (int i = 0; i < 20; i++)
			{
				if (oceny[i] == 0)
				{
					oceny[i] = ocena;
					break;
				}
			}
		}

		public void odczytajOcene()
        {
			foreach (var ocena in oceny)
			{
				if (ocena != 0)
				{
					Console.Write(ocena);
					Console.Write(" ");
				}
			}
			Console.WriteLine();
        }

		override public string ToString()
        {
			StringBuilder sb = new StringBuilder(login + " " + haslo + " " + indeks + " " + imie + " " + nazwisko + " " + przedmiot + " " + typUzytkownika);
			for(int i = 0; i < 20; i++)
            {
				sb.Append(" ");
				sb.Append(oceny[i]);
            }
			return sb.ToString();
        }
	}
}
