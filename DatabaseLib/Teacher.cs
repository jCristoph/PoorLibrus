using System;
using System.Collections.Generic;
using System.Text;


/*Nauczyciel ma wieksze prawa od Ucznia
 * Moze dodawac oceny uczniom ze swojego przedmiotu oraz wyswietlac cala liste uczniow wraz z ocenami z przedmiotu tego nauczyciela
 * na ten moment przyjmujemy ze jeden nauczyciel moze miec tylko jeden przedmiot
 */
namespace DatabaseLib
{
	public class Teacher : Student
	{
		public Teacher() {}
		public Teacher(string[] t)
		{
			login = t[0];
			password = t[1];
			index = Int32.Parse(t[2]);
			firstName = t[3];
			name = t[4];
			subject = t[5];
			userType = Convert.ToChar(t[6]);
			grades = new int[20];
		}
		public Teacher(string firstName, string name, string password, string subject, int index)
		{
			this.firstName = firstName;
			this.name = name;
			this.password = password;
			this.subject = subject;
			this.index = index;
			this.userType = 't';
			login = userType.ToString() + index;
			grades = new int[20];
		}

		public string readGradesAllGroupBySubject(Base b)
		{
			StringBuilder sb = new StringBuilder();
			List<User> studentList = b.userDatabase.FindAll(x => x.UserType.Equals('s') && x.Subject.Equals(this.subject));
			try
			{
				int i = 0;
				foreach (var student in studentList)
                {
					sb.Append(i+" " + student.FirstName + " " + student.Name + " ");
					sb.Append(student.readGrades());
					i++;
				}
				return sb.ToString();
			}
			catch (Exception e)
			{
				return e.ToString();
			}
		}


		public void addGrade(Base b, int index, int grade)
        {
            try
            {
                int[] grades = b.userDatabase.Find(x => x.Index.Equals(index) && x.Subject.Equals(this.subject)).Grades;
				for (int i = 0; i < 20; i++)
				{
					if (grades[i] == 0)
					{
						grades[i] = grade;
						break;
					}
				}
				b.userDatabase.Find(x => x.Index.Equals(index) && x.Subject.Equals(this.subject)).Grades = grades;
			}
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            b.sync();
        }
    }
}