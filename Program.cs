using System;

namespace Day1_CSharp
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name  + "Welcome to Day 1st of learning of C#");

            Console.WriteLine("Enter first number");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("sum = " + (a + b));
            Console.WriteLine("Difference = " + (a - b));
            Console.WriteLine("Product = " + (a * b));

        }
    }
}
