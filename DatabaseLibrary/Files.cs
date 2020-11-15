using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using Decryption;
using Encryption;

namespace DatabaseLibrary
{
	public class Files
	{
		private static string key = "sekret";
		public static void saveFile(List<User> userDatabase)
		{
			FileStream fs = File.OpenWrite("userdatabase.txt");
			Encrypter e = new Encrypter(key);
			for(int i =0; i < userDatabase.Count; i++)
            {
				AddText(fs, e.start(userDatabase[i].ToString()));
				AddText(fs, "\n");
			}
			fs.Close();
		}

        public static List<User> readFile(List<User> array)
		{
			var sr = new StreamReader("userdatabase.txt");
			string line;
			Decrypter d = new Decrypter(key);
			while((line = sr.ReadLine()) != null)
            {
				array.Add(new User(d.start(line)));
            }
			sr.Close();
			return array;
		}
		private static void AddText(FileStream fs, string value)
		{
			byte[] info = new UTF8Encoding(true).GetBytes(value);
			fs.Write(info, 0, info.Length);
		}
	}
}
