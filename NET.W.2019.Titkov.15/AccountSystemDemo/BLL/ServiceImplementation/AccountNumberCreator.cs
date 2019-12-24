using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        private static readonly Random Random = new Random();
        private static readonly object SyncLock = new object();

        public int CreateAccountNumber()
        {
            string format = "yyMMdd";
            string dateTimePart = DateTime.Now.ToString(format, DateTimeFormatInfo.InvariantInfo);

            string randomPart;
            lock (SyncLock)
            {
                randomPart = Random.Next(100, 999).ToString();
            }

            int number = int.Parse(dateTimePart + randomPart);

            return number;
        }
    }
}
