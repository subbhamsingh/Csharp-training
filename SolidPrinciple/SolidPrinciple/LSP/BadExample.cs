using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple.LSP
{
    public class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("Bird flying");
        }
    }

    public class Sparrow : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Sparrow flying");
        }
    }

    public class Penguin : Bird
    {
        public override void Fly()
        {
          
            Console.WriteLine("Penguins cannot fly");
        }
    }
}
