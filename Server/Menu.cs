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
        List<User> loggedUser;
        User baseLoggedUser;
        LoginStatus login;
        NetworkStream stream;

        public Menu(Base base_, NetworkStream stream)
        {
            this.base_ = base_;
            this.stream = stream;
        }

        public void start()
        {
            while(true)
            {
                string[] command = checkMessage(read());
                try
                {
                    /*if (command[0] == "\r\n" || command.Length < 3)
                    {
                        //write("Zaloguj sie ponownie podajac LOGIN <login> <haslo>: ");
                    }
                    else
                    {*/
                    if(command.Length == 3)
                    {
                        login = new LoginStatus(base_, command[1], command[2]);
                        login.Login();
                        char[] charsToTrim = { 's', 't', 'A' };
                        char userType = command[1][0];
                        int index = Int32.Parse(command[1].Trim(charsToTrim));
                        if (login.currentStatus.Equals(Statuses.logged))
                        {
                            loggedUser = base_.userDatabase.FindAll(x => x.Index.Equals(index));
                            baseLoggedUser = loggedUser[0];
                            switch (userType)
                            {
                                case 's':
                                    write("s");
                                    studentMenu();
                                    break;
                                case 't':
                                    write("t");
                                    teacherMenu();
                                    break;
                                default:
                                    write("a");
                                    adminMenu();
                                    break;
                            }
                        }
                        else
                            throw new ArgumentException("Zla ilosc argumentow");
                        
                       // }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void studentMenu()
        {
            StringBuilder grades = new StringBuilder("Oceny: \n");
            foreach (User a in loggedUser)
            {
                grades.Append(a.readGrades());
                grades.Append("\n");
            }
            write(grades.ToString());

            while (login.currentStatus.Equals(Statuses.logged))
            {
                string[] command = checkMessage(read());
                switch (command[0])
                {
                    case ("CHECK"):
                        grades = new StringBuilder("Oceny: \n");
                        foreach (User a in loggedUser)
                        {
                            grades.Append(a.readGrades());
                            grades.Append("\r\n");
                        }
                        write(grades.ToString());
                        break;
                    case ("NEW_PASS"):
                        foreach (User a in loggedUser)
                        {
                            try
                            {
                                a.changePassword(base_, command[1]);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e);
                            }
                        }

                        break;
                    case ("LOGOUT"):
                        login.currentStatus = Statuses.logged_out;
                        break;
                    default:
                        break;
                }

            }
        }

        private void teacherMenu()
        {
            while (login.currentStatus.Equals(Statuses.logged))
            {
                string[] command = checkMessage(read());
                /*if (command[0] == "\r\n")
                {
                    write("Twoj obecny przedmiot to " + baseLoggedUser.Subject +
                        "\n\rADDGRADE <indeks_studenta> <ocena> - dodaj ocene do studenta\n\r" +
                        "NEW_PASS <nowe_haslo>\r\n" +
                        "STUDENTLIST - lista studentow\r\n" +
                        "CHNGSUBJECT <nazwa_przedmiotu>\r\n" +
                        "LOGOUT - wylogowanie\r\n");
                }
                else
                {*/
                    try
                    {
                        switch (command[0])
                        {
                            case ("SUBJECTS"):
                                write(teacherSubjects());
                                break;
                            case ("ADDGRADE"):
                                ((Teacher)baseLoggedUser).addGrade(base_, Int32.Parse(command[1]), Int32.Parse(command[2]));
                                break;
                            case ("NEW_PASS"):
                                foreach (User a in loggedUser)
                                {
                                    ((Teacher)a).changePassword(base_, command[1]);
                                }
                                break;
                            case ("STUDENTLIST"):
                                string grades = ((Teacher)baseLoggedUser).readGradesAllGroupBySubject(base_);
                                write(grades);
                                break;
                            case ("CHNGSUBJECT"):
                                foreach (User a in loggedUser)
                                {
                                    if (a.Subject.Equals(command[1]))
                                    {
                                        baseLoggedUser = a;
                                        break;
                                    }
                                }
                                break;
                            case ("LOGOUT"):
                                login.currentStatus = Statuses.logged_out;
                                break;
                            default:
                                break;
                        }
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e);
                    }

                //}
                
            }
        }

        private void adminMenu()
        {
            while (login.currentStatus.Equals(Statuses.logged))
            {
                string[] command = checkMessage(read());
                /* if (command[0] == "\r\n")
                 {
                     write("USERLIST - lista wszystkich uzytkownikow\n\r" +
                       "EDIT <indeks_studenta> <przedmiot> <indeks_oceny> <nowa ocena> - edytuj ocene\n\r" +
                       "ADDUSER <imie> <nazwisko> <haslo> <przedmiot> <indeks> <typ uzytkownika(s lub t)> - dodaj uzytkownika\n\r" +
                       "REMOVE <indeks> - usun uzytkownika z bazy\n\r" +
                       "NEW_PASS - <nowe_haslo> - zmien haslo\n\r" +
                       "LOGOUT - wylogowanie\n\r");
                 }
                 else { */
                try
                {
                    switch (command[0])
                    {
                        case ("USERS"):
                            write(((Admin)baseLoggedUser).listAllUsers(base_).Length.ToString());
                            break;
                        case ("USERLIST"):
                            write(((Admin)baseLoggedUser).listAllUsers(base_));
                            break;
                        case ("EDIT"):
                            ((Admin)baseLoggedUser).editGrades(base_, Int32.Parse(command[1]), command[2], Int32.Parse(command[3]), Int32.Parse(command[4]));
                            break;
                        case ("ADDUSER"):
                            ((Admin)baseLoggedUser).addUser(base_, command[1], command[2], command[3], command[4], Int32.Parse(command[5]), Char.Parse(command[6]));
                            break;
                        case ("REMOVE"):
                            ((Admin)baseLoggedUser).deleteUser(base_, Int32.Parse(command[1]));
                            break;
                        case ("NEW_PASS"):
                            ((Admin)baseLoggedUser).changePassword(base_, command[1]);
                            break;
                        case ("LOGOUT"):
                            login.currentStatus = Statuses.logged_out;
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);
                }

            //}
                
                
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
            try
            {
                stream.Write(buffer, 0, buffer.Length);
            } 
            catch (Exception e)
            {

            }
            
        }

        private string[] checkMessage(string s)
        {
            return s.Split(' ');
        }
        private string teacherSubjects()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var e in loggedUser) 
            {
                sb.Append(e.Subject);
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
