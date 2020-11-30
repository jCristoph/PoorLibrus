using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using Decryption;
using Encryption;

namespace DatabaseLib
{
	public class Files
	{
		private static string key = "sekret";
		public static void saveFile(List<User> userDatabase)
		{
			try
            {
				FileStream fs = File.OpenWrite("userdatabase.txt");
				Encrypter e = new Encrypter(key);
				for (int i = 0; i < userDatabase.Count; i++)
				{
					AddText(fs, e.start(userDatabase[i].ToString()));
					AddText(fs, "\n");
				}
				fs.Close();
			}
			catch (Exception e)
            {
				Console.Out.WriteLine(e);
            }

		}

        public static void readFile(List<User> array)
		{
			try
			{
				var sr = new StreamReader("userdatabase.txt");
				string line;
				Decrypter d = new Decrypter(key);
				while ((line = sr.ReadLine()) != null)
				{
					line = d.start(line);
					string[] temp = line.Split();
					if (temp[6] == "s")
						array.Add(new Student(temp));
					else if (temp[6] == "t")
						array.Add(new Teacher(temp));
				}
				sr.Close();
			}
			catch (Exception e)
			{
				Console.Out.WriteLine(e);
			}
		}
		private static void AddText(FileStream fs, string value)
		{
			byte[] info = new UTF8Encoding(true).GetBytes(value);
			fs.Write(info, 0, info.Length);
		}
	}
}
