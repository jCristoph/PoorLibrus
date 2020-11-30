using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLib;

namespace LoginLib
{
    public class Veryfication
    {
        private Base savedBase;
        private String login;
        private String password;
        
        public Veryfication(Base base_, String login_, String password_)
        {
            savedBase = base_;
            password = password_;
            login = login_;
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Pass
        {
            get { return password; }
            set { password = value; }
        }

        public bool veryficate()
        {
            bool exist = false;
            User client = new Student();
            for (int i = 0; i < savedBase.length(); i++)
            {
                client = savedBase.getUser(i);
                if (client.Login == login && client.Pass == password) { 
                    exist = true;
                    break;
                }
                    
            }

            return exist;
        }
    }
}
