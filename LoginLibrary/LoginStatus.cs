using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLib;

namespace LoginLib
{
    public class LoginStatus
    {
        Veryfication ver;

        public LoginStatus(Base base_) 
        {
            ver = new Veryfication(base_, "", "");
            this.currentStatus = Statuses.not_logged;
        }

        public LoginStatus(Base base_, String login, String password)
        {
            ver = new Veryfication(base_, login, password);
            this.currentStatus = Statuses.not_logged;
        }

        public void changeLoginData(String login, String password)
        {
            this.ver.Login = login;
            this.ver.Pass = password;
        }

        public Statuses currentStatus { get; set; }
        
        public void Login()
        {
            if(ver.veryficate())
            {
                currentStatus = Statuses.logged;
            }
            else
            {
                currentStatus = Statuses.invalid_data;
            }
        } 
    }
}
