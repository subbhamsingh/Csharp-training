using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple.LSP
{
    public class Bird1
    {
    }

    public class FlyingBird1 : Bird1
    {
        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }

    public class Sparrow1 : FlyingBird1
    {
    }

    public class Penguin1 : Bird1
    {
    }
}
