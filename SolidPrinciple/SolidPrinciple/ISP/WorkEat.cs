using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple.ISP
{
    // robot has also have to implement eat()
    //Robot forced to implement something it doesn't need
    class Robot : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Robot working");
        }

        public void Eat()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Not applicable for Robot");
        }
    }


    // good

    class Robot1 : IWork
    {
        public void Work()
        {
            Console.WriteLine("Robot working");
        }
    }

    //Now classes implement only what they need.
    class Human : IWork, IEat
    {
        public void Work()
        {
            Console.WriteLine("Human working");
        }

        public void Eat()
        {
            Console.WriteLine("Human eating");
        }
    }
}
