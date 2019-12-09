using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._12
{
    /// <summary>
    /// Test subscriber for Clock class.
    /// </summary>
    public class ClockSubscriber
    {
        /// <summary>
        /// Allows to subscribe to Clock Timer event.
        /// </summary>
        /// <param name="clock">Clock object to subscribe</param>
        public void Subscribe(Clock clock)
        {
            clock.TimerEnded += Clock_TimerEnded;
        }

        /// <summary>
        /// Allows to unsubscribe to Clock Timer event.
        /// </summary>
        /// <param name="clock">Clock object to unsubscribe</param>
        public void Unsubscribe(Clock clock)
        {
            clock.TimerEnded -= Clock_TimerEnded;
        }

        /// <summary>
        /// Reaction to Clock.TimerEnded event.
        /// </summary>
        /// <param name="sender">Sender of an event.</param>
        /// <param name="e">Event args.</param>
        private void Clock_TimerEnded(object sender, ClockEventArgs e)
        {
            Console.WriteLine("Event catched.");
            Console.WriteLine("Event args are: {0} after {1} seconds.", e.Message, e.Seconds);
        }
    }
}
