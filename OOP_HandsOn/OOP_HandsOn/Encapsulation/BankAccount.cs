using System;

namespace OOP_HandsOn.Encapsulation
{
    internal class BankAccount
    {
        private  int balance=100; // hiding data 
        public void ShowBalance()
        {
            Console.WriteLine("Accounr Balance is " + balance);

        }
    }
}
