using System;
using System.Text;

/*
 * Klasa user to podstawowa klasa z ktorej tworzeni sa uczniowie
 * Obiekt klasy moze odczytac oceny lub zmienic haslo
 * Moze byc dowolna ilosc obiektow o tym samym indeksie o ile zmienia sie przedmiot.
 */

namespace DatabaseLib
{
	public abstract class User
	{
		protected string login;
		protected string password;
		protected string firstName;
		protected string name;
		protected string subject;
		protected char userType;
		protected int index;
		protected int[] grades;

		public abstract void changePassword(Base b, string pass);
		public abstract string readGrades();
		override public string ToString()
        {
			StringBuilder sb = new StringBuilder(login + " " + password + " " + index + " " + firstName + " " + name + " " + subject + " " + userType);
			for(int i = 0; i < 20; i++)
            {
				sb.Append(" ");
				sb.Append(grades[i]);
            }
			return sb.ToString();
        }
		/*
		 * Gettery i setter potrzebne dla funkcji szukających po bazie danych ale również dla dodawania ocen
		 */
		public string Login {
			get { return login; }
			set { login = value; }
		}
		public string Pass{
			get { return password; }
			set { password = value; }
		}
		public string Name {
			get { return name; }
			set { name = value; }
		}
		public string FirstName {
			get { return firstName; }
			set { firstName = value; }
		}
		public char UserType {
			get { return userType; }
			set { userType = value; }
		}
		public string Subject {
			get { return subject; }
			set { subject = value; }
		}
		public int Index {
			get { return index; }
			set { index = value; }
		}
		public int[] Grades {
			get { return grades; }
			set { grades = value; }
		}
	}
}
