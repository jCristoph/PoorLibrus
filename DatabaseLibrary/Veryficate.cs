using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLibrary
{
    class Veryficate
    {
        Base savedBase;
        String login;
        String password;
        
        Veryficate(Base base_, String login_, String password_)
        {
            savedBase = base_;
            password = password_;
            login = login_;
        }

    }
}
