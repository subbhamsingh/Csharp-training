using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple.DIP
{
    public class EmailServiceDip
    {
        public void Send()
        {
            Console.WriteLine("Email sent");
        }
    }

    public class OrderService
    {
        private EmailServiceDip email = new EmailServiceDip();

        public void PlaceOrder()
        {
            Console.WriteLine("Order placed");
            email.Send();
        }
    }
     //OrderService -> directly depends on EmailService

    //If tomorrow we want:SMS,Push Notification WhatsApp

     //We must modify OrderService.
     //So DIP is violated.
}
