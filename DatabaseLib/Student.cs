using System;
using System.Text;

/*
 * Klasa user to podstawowa klasa z ktorej tworzeni sa uczniowie
 * Obiekt klasy moze odczytac oceny lub zmienic haslo
 * Moze byc dowolna ilosc obiektow o tym samym indeksie o ile zmienia sie przedmiot.
 */

namespace DatabaseLib
{
	public class Student : User
	{
		/*
		 * konstruktor domyslny
		 */
		public Student()
		{
			login = "s10000";
			password = "";
			firstName = "firstName";
			name = "name";
			subject = "subject";
			userType = ' ';
			index = 10000;
			grades = new int[20];
		}

		/*
		 * konstruktor tworzący nowego ucznia
		 */
		public Student(string firstName, string name, string password, string subject, int index)
		{
			this.firstName = firstName;
			this.name = name;
			this.password = password;
			this.subject = subject;
			this.index = index;
			this.userType = 's';
			login = userType.ToString() + index;
			grades = new int[20];
		}

		/*
		 * tego konstruktora uzywamy w przypadku czytania z pliku 
		 */
		public Student(string[] u)
		{
			login = u[0];
			password = u[1];
			index = Int32.Parse(u[2]);
			firstName = u[3];
			name = u[4];
			subject = u[5];
			userType = Convert.ToChar(u[6]);
			grades = new int[20];
			for (int i = 7; i < u.Length; i++)
			{
				grades[i - 7] = Int32.Parse(u[i]);
			}
		}

		/*
		 * Student moze odczytac swoje oceny.
		 */
		public override string readGrades()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Subject + ": ");
			foreach (var grade in grades)
			{
				if (grade != 0)
				{
					sb.Append(grade);
					sb.Append(" ");
				}
			}
			return sb.ToString();
		}

		/*
		 * student moze zmienic swoje haslo
		 */
		public override void changePassword(Base b, string pass)
		{
			this.password = pass;
			foreach (var a in b.userDatabase.FindAll(x => x.Index.Equals(index)))
			{
				a.Pass = pass;
			}
			b.sync();
		}
	}
}
