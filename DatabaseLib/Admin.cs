using System;
using System.Text;

/*
 * Admin to klasa ktora ma najwieksze prawa w calym programie
 * Obiekt klasy admin moze byc tylko jeden i jest na stale wpisany w kodzie programu(patrz na tworzenie bazy danych)
 * 
 * 
 */
namespace DatabaseLib
{
	public class Admin : Teacher
	{
		public Admin() {}

		public Admin(string firstName, string name, string password, string subject, int index)
		{
			this.firstName = firstName;
			this.name = name;
			this.password = password;
			this.subject = subject;
			this.index = index;
			this.userType = 'A';
			login = userType.ToString() + index;
			grades = new int[20];
		}

		public string listAllUsers(Base b)
        {
			StringBuilder sb = new StringBuilder();
			foreach(var user in b.userDatabase)
            {
				sb.Append(user.ToString()+"\n");
            }
			return sb.ToString();
        }

		public void editGrades(Base b, int index, string subject, int gradeIndex, int newGrade)
        {
            try
            {
				int[] grades = b.userDatabase.Find(x => x.Index.Equals(index) && x.Subject.Equals(subject)).Grades;
				grades[gradeIndex] = newGrade;
				b.userDatabase.Find(x => x.Index.Equals(index) && x.Subject.Equals(subject)).Grades = grades;
				b.sync();
			} 
			catch (Exception e){
				Console.WriteLine(e);
            }
		}

		public void addUser(Base b, string firstName, string name, string password, string subject, int index, char userType)
		{
			if (userType == 's')
				b.userDatabase.Add(new Student(firstName, name, password, subject, index));
			else if (userType == 't')
				b.userDatabase.Add(new Teacher(firstName, name, password, subject, index));
			else
				throw new Exception("Invalid user type");
			b.sync();
		}
		public void deleteUser(Base b, int index)
		{
			try
			{
				b.userDatabase.Remove(b.userDatabase.Find(x => x.Index.Equals(index)));
				b.sync();
			}
			catch (Exception e)
			{
				e.ToString();
			}
		}
	}
}
