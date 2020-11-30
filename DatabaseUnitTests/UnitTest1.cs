using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseLib;

namespace DatabaseUnitTests
{
    [TestClass]
    public class DatabaseUnitTests
    {
        [TestMethod]
        public void createDatabaseUnitTest()
        {
            Base b = new Base();
            User expected = new Admin("Jedrzej", "Krysztof", "database123", "administracja", 99999);
            User actual = b.userDatabase[0];

            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Subject, actual.Subject);
            Assert.AreEqual(expected.Index, actual.Index);

        }
        [TestMethod]
        public void addUserUnitTest()
        {
            Base b = new Base();
            b.userDatabase.Clear();
            Admin a = new Admin("Jedrzej", "Krysztof", "database123", "administracja", 99999);
            Student expected = new Student("Jan", "Nowak", "eloelo", "matematyka", 10001);
            a.addUser(b, "Jan", "Nowak", "eloelo", "matematyka", 10001, 's');
            
            Student actual = (Student)b.userDatabase.Find(x => x.Index.Equals(10001));
            int expectedSize = 1;
            int actualSize = b.userDatabase.Count;

            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Subject, actual.Subject);
            Assert.AreEqual(expected.Index, actual.Index);
            Assert.AreEqual(expectedSize, actualSize);
        }
        [TestMethod]
        public void removeUserUnitTest()
        {
            Base b = new Base();
            b.userDatabase.Clear();
            int expectedSize = 0;
            Admin a = new Admin("Jedrzej", "Krysztof", "database123", "administracja", 99999);
            a.addUser(b, "Jan", "Nowak", "eloelo", "matematyka", 10001, 's');

            a.deleteUser(b, 10001);

            int actualSize = b.userDatabase.Count;
            Assert.AreEqual(expectedSize, actualSize);

        }
        [TestMethod]
        public void editGradeUnitTest()
        {
            Base b = new Base(); 
            b.userDatabase.Clear();
            Admin a = new Admin("Jedrzej", "Krysztof", "database123", "administracja", 99999);
            a.addUser(b, "Jan", "Nowak", "eloelo", "matematyka", 10001, 's');
            a.editGrades(b, 10001, "matematyka", 5, 4);
            int expected = 4;
            int actual = b.userDatabase[b.userDatabase.Count - 1].Grades[5];
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void addGradeUnitTest()
        {
            Base b = new Base();
            Admin a = (Admin)b.userDatabase[0];
            b.userDatabase.Clear();
            Teacher t = new Teacher("Andrzej", "Czajka", "siemasiema123", "matematyka", 90001);
            a.addUser(b, "Jan", "Nowak", "eloelo", "matematyka", 10001, 's');
            a.addUser(b, "Andrzej", "Czajka", "siemasiema123", "matematyka", 90001, 't');
            t.addGrade(b, 10001, 3);
            int expected = 3;
            int actual = b.userDatabase.Find(x => x.Index.Equals(10001)).Grades[0];
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void changePasswordUnitTest()
        {
            Base b = new Base();
            b.userDatabase.Clear();
            Admin a = new Admin("Jedrzej", "Krysztof", "database123", "administracja", 99999);
            a.addUser(b, "Jan", "Nowak", "eloelo", "matematyka", 10001, 's');
            b.userDatabase.Find(x => x.Index.Equals(10001)).changePassword(b, "nowehaslo");
            string expected = "nowehaslo";
            string actual = b.userDatabase.Find(x => x.Index.Equals(10001)).Pass;
            Assert.AreEqual(expected, actual);
        }
    }
}
