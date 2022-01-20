
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assignment3
{

    // public class TimeInfoEventArgs : EventArgs
    // {
    //     public int hour;
    //     public int minute;
    //     public int second;

    //     public TimeInfoEventArgs(int hour, int minute, int second) 
    //     {
    //         this.hour = hour;
    //         this.minute = minute;
    //         this.second = second;
    //     }
    // }


    // public class Clock
    // {
    //     private int hour;
    //     private int minute;
    //     private int second;

    //     /// The delegate the suscribers must implement
    //     public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInformation);

    //     // An instance of the delegate
    //     // use event keyword to avoid execution of the
    //     // delegate outside the Clock class.
    //     public event SecondChangeHandler SecondChanged;

    //     // Set the clock running
    //     // it will raise an event for each new second
    //     public void Start()
    //     {
    //         for (; ; )
    //         {
    //             Thread.Sleep(500);

    //             DateTime dt = DateTime.Now;

    //             if (dt.Second != second)
    //             {
    //                 TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);

    //                 if (SecondChanged != null)
    //                 {
    //                     SecondChanged(this, timeInformation);
    //                 }
    //             }
    //             // update state
    //             this.second = dt.Second;
    //             this.minute = dt.Minute;
    //             this.hour = dt.Hour;
    //         }
    //     }
    // }

    // public class DisplayClock
    // { 

    //     public void Subscribe(Clock theClock)
    //     {
    //         theClock.SecondChanged += new Clock.SecondChangeHandler(TimeHasChanged);
    //     }

    //     // The method that implements the
    //     // delegated functionality
    //     public void TimeHasChanged(object theClock, TimeInfoEventArgs ti)
    //     {
    //         Console.WriteLine("Current Time: {0}:{1}:{2}", ti.hour, ti.minute, ti.second);
    //     }
    // }


    // public class LogCurrentTime
    // {
    //     public void Subscribe(Clock theClock)
    //     {
    //         theClock.SecondChanged += new Clock.SecondChangeHandler(WriteLogEntry);
    //     }

    //     public void WriteLogEntry(object theClock, TimeInfoEventArgs ti)
    //     {
    //         Console.WriteLine("Logging to file: {0}:{1}:{2}", ti.hour, ti.minute, ti.second);
    //     }
    // }

    public class Program
    {

        // public static void Main(string[] args)
        // {
        // //    Clock theClock = new Clock();

        // //     DisplayClock dc = new DisplayClock();
        // //     dc.Subscribe(theClock);

        // //     LogCurrentTime lct = new LogCurrentTime();
        // //     lct.Subscribe(theClock);

        // //     theClock.Start();

        // }
         public static async Task Main(string[] args)
        {
            int min = 0, max = 100;
            var number = await GetPrimeNumbersAsync(min, max);
            PrintNumbers(number);
        }
        static bool IsPrimeNumber(int number)
        {
            int i;
            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            if (number == i) { return true; }
            return false;
        }
        static async Task<List<int>> GetPrimeNumbersAsync(int min, int max)
        {
            var list = new List<int>();
            var result = await Task.Factory.StartNew(() =>
            {
                for (int i = min; i <= max; i++)
                {
                    if (IsPrimeNumber(i))
                    {
                        list.Add(i);
                    }
                }
                return list;
            });
            return result;
        }
        static void PrintNumbers(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
    }

}

