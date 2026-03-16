//using System;
//using System.Diagnostics;
//namespace EventsPractise
//{
//    class Process
//    {
//        public event Action Completed;   // event

//        public void Start()
//        {
//            Console.WriteLine("Process running...");
//            Completed?.Invoke();         // raise event
//        }
//    }
//    public class Program
//    {
//        public static void Main()
//        {
//            Process p = new Process();

//            p.Completed += ShowMessage;   // subscribe

//            p.Start();
//        }

//        public static void ShowMessage()
//        {
//            Console.WriteLine("Process finished!");
//        }
//    }
//}

using System;
namespace EventsPractise
{
    class Alarm
    {
        public event Action Ring;

        public void StartAlarm()
        {
            Console.WriteLine("Alarm ringing...");
            Ring?.Invoke();
        }
    }

    class Program
    {
        static void Main()
        {
            Alarm a = new Alarm();

            a.Ring += WakeUp;
            a.Ring += BrushTeeth;

            a.StartAlarm();
        }

        static void WakeUp()
        {
            Console.WriteLine("Wake up!");
        }

        static void BrushTeeth()
        {
            Console.WriteLine("Brush teeth!");
        }
    }
}