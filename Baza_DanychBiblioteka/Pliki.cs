using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using Decryption;
using Encryption;

namespace Baza_DanychBiblioteka
{
	public class Pliki
	{
		private static string key = "sekret";
		public static void zapiszDoPliku(List<Uzytkownik> bazaUzytkownikow)
		{
			FileStream fs = File.OpenWrite("userdatabase.txt");
			Encrypter e = new Encrypter(key);
			for(int i =0; i < bazaUzytkownikow.Count; i++)
            {
				AddText(fs, e.start(bazaUzytkownikow[i].ToString()));
				AddText(fs, "\n");
			}
			fs.Close();
		}

        public static List<Uzytkownik> odczytajZPliku(List<Uzytkownik> tablica)
		{
			var sr = new StreamReader("userdatabase.txt");
			string line;
			Decrypter d = new Decrypter(key);
			while((line = sr.ReadLine()) != null)
            {
				tablica.Add(new Uzytkownik(d.start(line)));
            }
			sr.Close();
			return tablica;
		}
		private static void AddText(FileStream fs, string value)
		{
			byte[] info = new UTF8Encoding(true).GetBytes(value);
			fs.Write(info, 0, info.Length);
		}
	}
}
