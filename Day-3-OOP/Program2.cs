using System;
using System.Runtime.InteropServices;


//encapsulation
class BankAccount
{
    private int balance = 100;  // hidden data
    public void showBalance()
    {
        Console.WriteLine("balance " + balance);
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();
        acc.showBalance();
    }
}

//inheritance

class Animal
{
    public void Eat()
    {
        Console.WriteLine("Animals eats");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Dog Barks");
    }
}

class program
{
    static void Main()
    {
        Dog d = new Dog();
        d.Eat();  // inherited
        d.Bark();
    }
}


//compile time polymorphism

class Calculate
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

class Program
{
    static void Main()
    {
        Calculate c1 = new Calculate();
        Console.WriteLine(c1.Add(10, 20));
        Console.WriteLine(c1.Add(10, 20, 30));
    }

}

// run time polymorphism

class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal is making Sound");
    }
}

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Dog is making sound");
    }
}

class Program
{
    static void Main()
    {
        Animal a = new Dog();
        a.Sound();
    }
}
