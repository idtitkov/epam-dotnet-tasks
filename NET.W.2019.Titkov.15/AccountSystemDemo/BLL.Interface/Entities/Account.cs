using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        private string name;

        protected Account(int accountNumber, string name, decimal balance, int bonus)
        {
            AccountNumber = accountNumber;
            Name = name;
            Balance = balance;
            Bonus = bonus;

            IsActive = true;
        }

        public bool IsActive { get; set; }

        public int AccountNumber { get; set; }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                name = value;
            }
        }

        public decimal Balance { get; set; }

        public int Bonus { get; set; }

        public override string ToString()
        {
            string accountToString =
                $"Account number: {AccountNumber}" +
                $"\nFirst Name: {Name}" +
                $"\nBalance: {Balance}" +
                $"\nBonus: {Bonus}";

            return accountToString;
        }
    }
}
