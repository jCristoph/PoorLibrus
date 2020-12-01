using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DatabaseLib;
using LoginLib;

namespace Server
{
    class Menu
    {
        Base base_;
        User loggedUser;
        LoginStatus login;
        NetworkStream stream;

        public Menu(Base base_, NetworkStream stream)
        {
            this.base_ = base_;
            this.stream = stream;
        }

        public void start()
        {
            write("Witaj na serwerze PoorLibrus!\r\nZaloguj sie podajac LOGIN <login> <haslo>: ");
            while(true)
            {
                string[] command = checkMessage(read());
                if (command[0] == "\r\n" || command.Length < 3)
                {
                    write("Zaloguj sie ponownie podajac LOGIN <login> <haslo>: ");
                }
                else
                {
                    login = new LoginStatus(base_, command[1], command[2]);
                    login.Login();
                    char[] charsToTrim = { 's', 't', 'A' };
                    char userType = command[1][0];
                    int index = Int32.Parse(command[1].Trim(charsToTrim));
                    if (login.currentStatus.Equals(Statuses.logged))
                    {
                        loggedUser = base_.userDatabase.Find(x => x.Index.Equals(index));
                        switch (userType)
                        {
                            case 's':
                                studentMenu();
                                break;
                            case 't':
                                teacherMenu();
                                break;
                            default:
                                adminMenu();
                                break;
                        }
                    }
                }
            }
        }

        private void studentMenu()
        {
            while (login.currentStatus.Equals(Statuses.logged))
            {
                string[] command = checkMessage(read());
                if (command[0] == "\r\n")
                {
                    write("CHECK - sprawdz oceny\r\n" +
                        "NEW_PASS < nowe_haslo > -zmien haslo\r\n" +
                        "LOGOUT - wylogowanie\r\n");
                }
                else
                {
                    switch (command[0])
                    {
                        case ("CHECK"):
                            string grades = "Oceny: " + loggedUser.readGrades() + "\r\n";
                            write(grades);
                            break;
                        case ("NEW_PASS"):
                            loggedUser.changePassword(base_, command[1]);
                            break;
                        case ("LOGOUT"):
                            login.currentStatus = Statuses.logged_out;
                            break;
                        default:
                            break;
                    }
                }
                
            }
        }

        private void teacherMenu()
        {
            while (login.currentStatus.Equals(Statuses.logged))
            {
                string[] command = checkMessage(read());
                if (command[0] == "\r\n")
                {
                    write("ADDGRADE <indeks_studenta> <ocena> - dodaj ocene do studenta\n\r" +
                        "NEW_PASS <nowe_haslo>\r\n" +
                        "STUDENTLIST - lista studentow\r\n" +
                        "LOGOUT - wylogowanie\r\n");
                }
                else
                {
                    switch (command[0])
                    {
                        case ("ADDGRADE"):
                            ((Teacher)loggedUser).addGrade(base_, Int32.Parse(command[1]), Int32.Parse(command[2]));
                            break;
                        case ("NEW_PASS"):
                            ((Teacher)loggedUser).changePassword(base_, command[1]);
                            break;
                        case ("STUDENTLIST"):
                            string grades = ((Teacher)loggedUser).readGradesAllGroupBySubject(base_);
                            write(grades);
                            break;
                        case ("LOGOUT"):
                            login.currentStatus = Statuses.logged_out;
                            break;
                        default:
                            break;
                    }
                }
                
            }
        }

        private void adminMenu()
        {
            while (login.currentStatus.Equals(Statuses.logged))
            {
                string[] command = checkMessage(read());
                if (command[0] == "\r\n")
                {
                    write("USERLIST - lista wszystkich uzytkownikow\n\r" +
                      "EDIT <indeks_studenta> <przedmiot> <indeks_oceny> <nowa ocena> - edytuj ocene\n\r" +
                      "ADDUSER <imie> <nazwisko> <haslo> <przedmiot> <indeks> <typ uzytkownika(s lub t)> - dodaj uzytkownika\n\r" +
                      "REMOVE <indeks> - usun uzytkownika z bazy\n\r" +
                      "NEW_PASS - <nowe_haslo> - zmien haslo\n\r" +
                      "LOGOUT - wylogowanie\n\r");
                }
                else { 
                    switch (command[0])
                    {
                        case ("USERLIST"):
                            write(((Admin)loggedUser).listAllUsers(base_));
                            break;
                        case ("EDIT"):
                            ((Admin)loggedUser).editGrades(base_, Int32.Parse(command[1]), command[2], Int32.Parse(command[3]), Int32.Parse(command[4]));
                            break;
                        case ("ADDUSER"):
                            ((Admin)loggedUser).addUser(base_, command[1], command[2], command[3], command[4], Int32.Parse(command[5]), Char.Parse(command[6]));
                            break;
                        case ("REMOVE"):
                            ((Admin)loggedUser).deleteUser(base_, Int32.Parse(command[1]));
                            break;
                        case ("NEW_PASS"):
                            ((Admin)loggedUser).changePassword(base_, command[1]);
                            break;
                        case ("LOGOUT"):
                            login.currentStatus = Statuses.logged_out;
                            break;
                        default:
                            break;
                    }
                }
                
                
            }
        }

        private string read()
        {
            byte[] buffer = new byte[1024];
            try
            {
                int message_size = stream.Read(buffer, 0, 1024);
            } 
            catch (Exception e)
            {
                Console.Write(e);
            }
            string s = System.Text.Encoding.UTF8.GetString(buffer);
            s = s.Replace("\0", "");
            return s;
        }

        private void write(string toWrite)
        {
            byte[] buffer = ASCIIEncoding.UTF8.GetBytes(toWrite);
            stream.Write(buffer, 0, buffer.Length);
        }

        private string[] checkMessage(string s)
        {
            return s.Split(' ');
        }
    }
}
