using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    sealed class SingletonClass
    {
        private SingletonClass()
        { }

        //private static SingletonClass instance=new SingletonClass(); // eager initialization
        private static SingletonClass? instance; // lazy initialization

        private static object instanceLock = new object();  

        public static SingletonClass GetInstance()
        {
            if(instance == null) // reducing lock overhead 
            {
                lock (instanceLock) // multithreading singleton issue resolved , thread safety
                {
                    if (instance == null)  // for only one object creation 
                    {
                        instance = new SingletonClass();
                    }
                }
               
            }
           
            return instance;
        }
    }
}
