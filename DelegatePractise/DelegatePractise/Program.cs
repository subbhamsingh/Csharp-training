using System;
namespace DelegatePractise
{
    // declaring multiple delgates 
    public delegate void Calculation(int a, int b); // it is multi cast delegate // one delegate having multiple mehtods 

    public delegate void Calculation2(int num); 
    class Program
    {
        public static void Square(int num)
        {
            int res = num * num;
            Console.WriteLine("Square is " + res);
        }

        public static void Cube(int num)
        {
            int res = num * num * num;
            Console.WriteLine("cube is " + res);
        }


        public static void Addition(int a, int b)
        {
            int res=a+b;
            Console.WriteLine("Addition is " + res);
        }
        public static void Subtraction(int a, int b)
        {
            int res = a - b;
            Console.WriteLine("Subtraction is " + res);
        }
        public static void Multiplication(int a, int b)
        {
            int res = a * b;
            Console.WriteLine("Multiplication is " + res);
        }
        public static void Division(int a, int b)
        {
            int res = a / b;
            Console.WriteLine("Division is " + res);
        }
        public static void Main()
        {

            //Calculation obj1 = new Calculation(Program.Addition);
            //obj1.Invoke(10, 20);

            //Calculation obj2 = new Calculation(Program.Subtraction);
            //obj2.Invoke(100, 20);

            //Calculation obj3 = new Calculation(Program.Multiplication);
            //obj3.Invoke(1, 2);

            //Calculation obj4 = new Calculation(Program.Division);
            //obj4.Invoke(20, 10);


            //Calculation obj = new Calculation(Addition);
            //obj += Subtraction;
            //obj += Multiplication;
            //obj += Division;
            //obj.Invoke(20, 10);

            Calculation2 obj = new Calculation2(Square);
            obj += Cube;
            obj.Invoke(2);
        }
    }
}