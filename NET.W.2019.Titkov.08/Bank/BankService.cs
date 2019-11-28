using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08
{
    public class BankService
    {
        private BankStorage bankStorage = new BankStorage();

        public int CreateAccount(string firstName, string surname, double balance, int bonus, Grades grade)
        {
            bool isAccountUnique = true;

            var newAccount = new BankAccount
            {
                Id = bankStorage.AllAccounts.Count + 1,
                FirstName = firstName,
                Surname = surname,
                Balance = balance,
                Bonus = bonus,
                Grade = grade,
            };

            foreach (var existingAccount in bankStorage.AllAccounts)
            {
                if (newAccount == existingAccount)
                {
                    isAccountUnique = false;
                    throw new Exception("Account already exists!");
                }
            }

            if (isAccountUnique)
            {
                bankStorage.AllAccounts.Add(newAccount);

                bankStorage.Synchronize();
            }

            return newAccount.Id;
        }

        public void CloseAccount(string firstName, string surname)
        {
            bankStorage.AllAccounts = bankStorage.AllAccounts.Where(x => x.FirstName != firstName && x.Surname != surname).ToList();

            bankStorage.Synchronize();
        }

        public void DepositMoney(int id, double amount)
        {
            int index = bankStorage.AllAccounts.FindIndex(account => account.Id == id);
            BankAccount accountToDeposit = bankStorage.AllAccounts[index];

            accountToDeposit.Bonus += BonusCalculate(accountToDeposit, amount);
            accountToDeposit.Balance += amount;

            bankStorage.Synchronize();
        }

        public void WithdrawMoney(int id, double amount)
        {
            int index = bankStorage.AllAccounts.FindIndex(account => account.Id == id);
            BankAccount accountToWithdraw = bankStorage.AllAccounts[index];

            accountToWithdraw.Bonus -= BonusCalculate(accountToWithdraw, amount);
            accountToWithdraw.Balance -= amount;

            bankStorage.Synchronize();
        }

        public void ShowAll()
        {
            foreach (var account in bankStorage.AllAccounts)
            {
                Console.WriteLine(account);
            }
        }

        private int BonusCalculate(BankAccount account, double amount)
        {
            double baseMultiplier = 1;
            double goldMultiplier = 1.1;
            double platinumMultiplier = 1.2;

            //// Bonus calculation custom formula.
            double bonusBase = (account.Balance * 0.001) + (amount * 0.01);

            int totalBonus;
            switch (account.Grade)
            {
                case Grades.Platinum:
                    totalBonus = (int)(bonusBase * platinumMultiplier);
                    break;
                case Grades.Gold:
                    totalBonus = (int)(bonusBase * goldMultiplier);
                    break;
                case Grades.Base:
                    totalBonus = (int)(bonusBase * baseMultiplier);
                    break;
                default:
                    goto case Grades.Base;
            }

            return totalBonus;
        }
    }
}