using DatabaseLib;
using LoginLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        /// <summary>
        /// Ten test za zadanie ma sprawdzic, czy podajac poprawne i bledne dane 
        /// system weryfikacji zachowa sie odpowiednio (zwroci prawde lub falsz)
        /// </summary>
        public void VeryficationTest() 
        {
            bool expected = true;
            
            Base b = new Base();

            Veryfication ver = new Veryfication(b, "s10001", "now123ak");
            
            Assert.AreEqual(expected, ver.veryficate());    //poprawne dane
            ver.Pass = "annkaaa";
            Assert.AreNotEqual(expected, ver.veryficate()); //zle haslo, dobry login
            ver.Login = "s10002";
            ver.Pass = "now123ak";
            Assert.AreNotEqual(expected, ver.veryficate()); //zly login, dobre haslo
        }
        [TestMethod]
        /// <summary>
        /// Ten test za zadanie ma sprawdzic, czy podajac poprawne i bledne dane 
        /// system logowania zwroci odpowiednie statusy
        /// </summary>
        public void LoginTest()
        {
            Statuses expected = Statuses.not_logged;

            Base b = new Base();

            LoginStatus login = new LoginStatus(b, "s10001", "now123ak");//podstawowo konstruktor ustawia status na not_logged

            Assert.AreEqual(expected, login.currentStatus);

            expected = Statuses.logged;
            login.Login();

            Assert.AreEqual(expected, login.currentStatus);//po zalogowaniu dobrymi danymi, status powinien zmienic sie na logged

            expected = Statuses.invalid_data;
            login.changeLoginData("s10001", "aaaaa");
            login.Login();
            Assert.AreEqual(expected, login.currentStatus);//po zalogowaniu zlymi danymi, status powinien zmienic sie na invalid_data
        }
    }
}
