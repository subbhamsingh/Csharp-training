using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple.ISP
{
     public  interface IWorker
    {
        // bad practise

        void Work();
        void Eat();
    }

    public interface IWork
    {
        void Work();
    }
    public interface IEat
    {
        void Eat();
    }
}
