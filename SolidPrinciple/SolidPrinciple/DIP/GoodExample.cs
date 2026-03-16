using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple.DIP
{
    public interface IMessage
    {
        void Send();
    }

    public class EmailService : IMessage
    {
        public void Send()
        {
            Console.WriteLine("Email sent");
        }
    }

    public class SmsService : IMessage
    {
        public void Send()
        {
            Console.WriteLine("SMS sent");
        }
    }

    public class OrderServiceRefactored
    {
        private IMessage message;

        public OrderServiceRefactored(IMessage msg)
        {
            message = msg;
        }

        public void PlaceOrder()
        {
            Console.WriteLine("Order placed");
            message.Send();
        }
    }
}
