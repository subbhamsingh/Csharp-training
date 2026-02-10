// Abstract Example 

using System;

abstract class Employee
{
    public void ShowCompany()
    {
        Console.WriteLine("company : In Time tec");
    }
    public abstract void CalculateBonus();
}

class Coder : Employee
{
    public override void CalculateBonus()
    {
        Console.WriteLine("Coder Bonus : 10000");
    }
}

class Program
{
    static void Main()
    {
        Coder c = new Coder();
        c.ShowCompany();
        c.CalculateBonus();
    }
}

// Interface example 

using System;

interface IEmployee
{
    void CalculateBonus();
}

class Coder : IEmployee
{
    public void CalculateBonus()
    {
        Console.WriteLine("Coder Bonus : 10000");
    }
}

class program
{
    static void Main()
    {
        Coder c = new Coder();
        c.CalculateBonus();
    }
}

