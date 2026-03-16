using System;
namespace DesignPattern
{
    class Program 
    {
        public static void Main()
        {
            SingletonClass obj1 =SingletonClass.GetInstance();
            SingletonClass obj2 = SingletonClass.GetInstance();
            Console.WriteLine(obj1 == obj2);
        }
    }

}
