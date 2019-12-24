using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        void Add(Account account);

        void Remove(int accountNumber);

        void DepositMoney(int accountNumber, decimal amount, double bonus);

        void WithdrawMoney(int accountNumber, decimal amount, double bonus);

        Account GetAccount(int accountNumber);

        AccountType GetAccountType(int accountNumber);

        IEnumerable<Account> GetAccounts();
    }
}
