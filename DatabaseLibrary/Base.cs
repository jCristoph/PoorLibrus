using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLibrary
{
    public class Base
    {
        List<User> userDatabase;

        public Base()
        {
            userDatabase = new List<User>();
            try
            {
                Files.readFile(userDatabase);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void addUser(string firstName, string name, string password, string subject, int index, char userType)
        {
            userDatabase.Add(new User(firstName, name, password, subject, index, userType));
            sync();
        }

        public void deleteUser(User user)
        {
            userDatabase.Remove(user);
            sync();
        }

        public void addGrade(int index, int grade, string subject)
        {
            try
            {
                userDatabase.Find(x => x.index.Equals(index) && x.subject.Equals(subject)).addGrade(grade);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
            sync();
        }

        public void readGrades(int index, string subject)
        {
            try
            {
                Console.WriteLine("Oto oceny ucznia o indeksie " + index + " z subjectu " + subject + ": ");
                userDatabase.Find(x => x.index.Equals(index) && x.subject.Equals(subject)).readGrades();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void sync()
        {
            Files.saveFile(userDatabase);
            Console.WriteLine("Zapisano do pliku!");
        }

        public int length()
        {
            return userDatabase.Count;
        }

        public User getUser(int i) {
            return userDatabase[i];
        }
    }
}
