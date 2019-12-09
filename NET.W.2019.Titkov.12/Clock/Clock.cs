using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace NET.W._2019.Titkov._12
{
    public class Clock
    {
        private static DateTime timerStart;
        private Timer timer;
        private int seconds;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="seconds">Seconds quantity for timer.</param>
        public Clock(int seconds)
        {
            // Set timer start value.
            this.seconds = seconds;
            timerStart = DateTime.MinValue.AddSeconds(seconds);

            // Create a timer with one second interval.
            timer = new Timer();
            timer.Interval = 1000;

            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public delegate void ClockEventHandler(object sender, ClockEventArgs e);
        public event ClockEventHandler TimerEnded;

        /// <summary>
        /// Method subscribed to Elapsed event of System.Timers.
        /// </summary>
        /// <param name="source">Sender of an event.</param>
        /// <param name="e">Event args.</param>
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            timerStart = timerStart.AddSeconds(-1);
            Console.Write("Time till event invoke: {0:HH}:{0:mm}:{0:ss}", timerStart);

            if (timerStart == DateTime.MinValue)
            {
                timer.Elapsed -= OnTimedEvent;
                Console.WriteLine();
                TimerEnded.Invoke(this, new ClockEventArgs(seconds, "Timer ended"));
            }

            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}
