using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._12
{
    /// <summary>
    /// Class containing args for ClockEvent.
    /// </summary>
    public class ClockEventArgs : EventArgs
    {
        private int seconds;

        private string message;

        public ClockEventArgs(int seconds, string message)
        {
            this.Seconds = seconds;
            this.Message = message;
        }

        public int Seconds { get => this.seconds; private set => this.seconds = value; }

        public string Message { get => this.message; private set => this.message = value; }
    }
}
