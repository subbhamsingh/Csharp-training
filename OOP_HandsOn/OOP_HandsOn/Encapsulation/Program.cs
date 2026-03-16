using System;

namespace OOP_HandsOn.Encapsulation
{
    internal class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount();
            account.ShowBalance();

            //account.balance = 400;  it is unaccessible becouse it is private in class 
            //account.balance = 200;
            //account.ShowBalance();  // this will work if we do as a internal or public 
        }
    }
}
