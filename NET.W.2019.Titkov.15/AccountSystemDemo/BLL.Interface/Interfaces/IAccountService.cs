using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void OpenAccount(string name, AccountType accountType, IAccountNumberCreateService accountNumberCreateService);

        void CloseAccount(int accountNumber);

        void DepositAccount(int accountNumber, decimal amount);

        void WithdrawAccount(int accountNumber, decimal amount);

        Account GetAccount(int accountNumber);

        List<Account> GetAllAccounts();

    }
}
