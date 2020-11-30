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
            Admin a = new Admin("Jedrzej", "Krysztof", "database123", "administracja", 99999);
            a.addUser(b, "Jan", "Nowak", "now123ak", "matematyka5", 10001, 's');

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
            Admin a = new Admin("Jedrzej", "Krysztof", "database123", "administracja", 99999);
            a.addUser(b, "Jan", "Nowak", "now123ak", "matematyka5", 10001, 's');

            LoginStatus login = new LoginStatus(b, "s10001", "now123ak");

            Assert.AreEqual(expected, login.currentStatus);

            expected = Statuses.logged;
            login.Login();

            Assert.AreEqual(expected, login.currentStatus);

            expected = Statuses.invalid_data;
            login.changeLoginData("s10001", "aaaaa");
            login.Login();
            Assert.AreEqual(expected, login.currentStatus);
        }

        //[TestMethod]
        /// <summary>
        /// Ten test za zadanie ma sprawdzic, czy podajac poprawne i bledne dane 
        /// protokol komunikacyjny odpowiednio pozmienia status
        /// </summary>
        //public void CommProtocolTest()
        //{
        //    Base b = new Base();
        //    Admin a = new Admin("Jedrzej", "Krysztof", "database123", "administracja", 99999);
        //    a.addUser(b, "Jan", "Nowak", "now123ak", "matematyka5", 10001, 's');

        //    LoginStatus login = new LoginStatus(b);
        //    String mess = "LOGIN s10001 now123ak";

        //    CommunicationProtocol protocol = new CommunicationProtocol(mess, login);

        //    Assert.AreEqual(Statuses.not_logged, protocol.state.currentStatus); //konstruktor ustawia bazowo not_logged

        //    Assert.AreEqual(protocol.splitmess[0], "LOGIN");
        //    Assert.AreEqual(protocol.splitmess[1], "s10001");
        //    Assert.AreEqual(protocol.splitmess[2], "now123ak");

        //    mess = "LOGIN    s10001  now123ak   now";
        //    protocol.newMessage(mess);
        //    Assert.AreEqual(protocol.splitmess[0], "LOGIN");
        //    Assert.AreEqual(protocol.splitmess[1], "s10001");
        //    Assert.AreEqual(protocol.splitmess[2], "now123ak");
        //    Assert.AreEqual(protocol.splitmess[3], "now");

        //    protocol.chechMessege();            //ckeckMessege powinien w przypadku dobrych danych logowac uzytkownika
        //    Assert.AreEqual(Statuses.logged, protocol.state.currentStatus); //i ignorowac niepotrzebne slowa (4 wyraz)

        //    mess = "LOGOUT";
        //    protocol.newMessage(mess);
        //    protocol.chechMessege();//ckeckMessege ma wylogowywac uzytkownika
        //    Assert.AreEqual(Statuses.logged_out, protocol.state.currentStatus);

        //    mess = "LOGIN    s10002  now123ak   ";//zle dane logowania
        //    protocol.newMessage(mess);
        //    protocol.chechMessege();//protoko³ umo¿liwia ponowne zalogowanie
        //    Assert.AreEqual(Statuses.invalid_data, protocol.state.currentStatus);

        //    mess = "LOGIN    s10002  ";//brak hasla
        //    protocol.newMessage(mess);
        //    protocol.chechMessege();
        //    Assert.AreEqual(Statuses.not_logged, protocol.state.currentStatus);

        //    mess = "s10002  now123ak";//brak komendy
        //    protocol.newMessage(mess);
        //    protocol.chechMessege();
        //    Assert.AreEqual(Statuses.not_logged, protocol.state.currentStatus);

        //    mess = "LOGOUT s10002  now123ak";//zla komenda
        //    protocol.newMessage(mess);
        //    protocol.chechMessege();
        //    Assert.AreEqual(Statuses.not_logged, protocol.state.currentStatus);
        //}
    }
}
