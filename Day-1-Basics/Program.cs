using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int sum = num1 + num2;
        int difference = num1 - num2;
        int product = num1 * num2;
        double division = (double)num1 / num2;

        Console.WriteLine("\n--- Results ---");
        Console.WriteLine("Addition: " + sum);
        Console.WriteLine("Subtraction: " + difference);
        Console.WriteLine("Multiplication: " + product);
        Console.WriteLine("Division: " + division);
    }
}
