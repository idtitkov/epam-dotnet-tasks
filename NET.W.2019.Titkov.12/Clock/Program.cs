using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace NET.W._2019.Titkov._12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int seconds;
            Console.Write("How many seconds do you want to wait?: ");
            seconds = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPress the Enter key to exit the application...\n");

            Clock clock = new Clock(seconds);

            ClockSubscriber clockSubscriber = new ClockSubscriber();
            clockSubscriber.Subscribe(clock);

            Console.ReadLine();
        }
    }
}
