using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple.SRP
{
    public  class User
    {
        // bad practise 
        //User class  has 3 responsibilities

        public void CreateUser(string name)
        {
            // Business logic
            Console.WriteLine("User created: " + name);

            // Logging
            Console.WriteLine("Log saved");

            // Email sending
            Console.WriteLine("Email sent");
        }
    }

    public class UserService
    {
        public void CreateUser(string name)
        {
            Console.WriteLine("User created: " + name);
        }
    }
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine("Log: " + message);
        }
    }
    public class EmailServiceSrp
    {
        public void SendEmail(string name)
        {
            Console.WriteLine("Email sent to " + name);
        }
    }
}
