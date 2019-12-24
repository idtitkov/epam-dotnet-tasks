using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class AccountBinaryRepository : IRepository
    {
        public void Add(Account account)
        {
            throw new NotImplementedException();
        }

        public void DepositMoney(int accountNumber, decimal amount, double bonus)
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public AccountType GetAccountType(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public void Remove(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public void WithdrawMoney(int accountNumber, decimal amount, double bonus)
        {
            throw new NotImplementedException();
        }
    }
}
