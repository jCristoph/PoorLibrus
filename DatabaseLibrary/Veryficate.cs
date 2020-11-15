using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLibrary
{
    class Veryfication
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

        public bool veryficate()
        {
            bool exist = false;
            User client = new User();
            for (int i = 0; i < savedBase.length(); i++)
            {
                client = savedBase.getUser(i);
                if (client.Login == login && client.Pass == password)
                    exist = true;
            }

            return exist;
        }
    }
}
