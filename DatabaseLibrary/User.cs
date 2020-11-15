using System;
using System.Text;

namespace DatabaseLibrary
{
	public class User
	{
		private string login;
		private string password;
		private string firstName;
		private string name;
		public string subject;
		private char userType;
		public int index { get; set; }
		private int[] grades;

		public User()
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

		public User(string firstName, string name, string password, string subject, int index, char userType)
        {
			this.firstName = firstName;
			this.name = name;
			this.password = password;
			this.subject = subject;
			this.index = index;
			this.userType = userType;
			login = userType.ToString() + index;
			grades = new int[20];
		}

		public User(string user)
        {
			string[] u = user.Split();
			login = u[0];
			password = u[1];
			index = Int32.Parse(u[2]);
			firstName = u[3];
			name = u[4];
			subject = u[5];
			userType = Convert.ToChar(u[6]);
			grades = new int[20];
			for(int i = 7; i < u.Length; i++)
            {
				grades[i - 7] = Int32.Parse(u[i]);
			}
		}

		public void addGrade(int grade)
		{
			for (int i = 0; i < 20; i++)
			{
				if (grades[i] == 0)
				{
					grades[i] = grade;
					break;
				}
			}
		}

		public void readGrades()
        {
			foreach (var grade in grades)
			{
				if (grade != 0)
				{
					Console.Write(grade);
					Console.Write(" ");
				}
			}
			Console.WriteLine();
        }

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
	}
}
