using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class SilverAccount : Account
    {
        public SilverAccount(int accountNumber, string name, decimal balance, int bonus)
            : base(accountNumber, name, balance, bonus)
        {
            this.Type = AccountType.Silver;
        }

        public AccountType Type { get; private set; }

        public override string ToString()
        {
            string accountToString =
                base.ToString() +
                $"\nAccount type: {Type.ToString("g")}";

            return accountToString;
        }
    }
}
