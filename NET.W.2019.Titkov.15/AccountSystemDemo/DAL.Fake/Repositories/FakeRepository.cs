using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public class FakeRepository : IRepository
    {
        private readonly List<Account> fakeRepository = new List<Account>();

        public void Add(Account account)
        {
            fakeRepository.Add(account);
        }

        public void Remove(int accountNumber)
        {
            int index = fakeRepository.FindIndex(a => a.AccountNumber == accountNumber);
            fakeRepository[index].IsActive = false;
        }

        public void DepositMoney(int accountNumber, decimal amount, double bonus)
        {
            int index = fakeRepository.FindIndex(a => a.AccountNumber == accountNumber);

            fakeRepository[index].Balance += amount;
            fakeRepository[index].Bonus += (int)(bonus * (double)amount);
        }

        public void WithdrawMoney(int accountNumber, decimal amount, double bonus)
        {
            int index = fakeRepository.FindIndex(a => a.AccountNumber == accountNumber);

            fakeRepository[index].Balance -= amount;
            fakeRepository[index].Bonus -= (int)(bonus * (double)amount);
        }

        public Account GetAccount(int accountNumber)
        {
            Account account = fakeRepository.Single(a => a.AccountNumber == accountNumber);

            return account;
        }

        public AccountType GetAccountType(int accountNumber)
        {
            Account account = GetAccount(accountNumber);

            if (account is BaseAccount)
            {
                return AccountType.Base;
            }
            else if (account is SilverAccount)
            {
                return AccountType.Silver;
            }
            else if (account is GoldAccount)
            {
                return AccountType.Gold;
            }
            else if (account is PlatinumAccount)
            {
                return AccountType.Platinum;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public IEnumerable<Account> GetAccounts()
        {
            return fakeRepository.Where(a => a.IsActive == true);
        }
    }
}
