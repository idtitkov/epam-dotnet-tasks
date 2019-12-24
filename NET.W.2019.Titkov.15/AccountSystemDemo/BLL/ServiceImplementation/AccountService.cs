using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private readonly IRepository accountRepository;
        private readonly IBonusCalculator bonusCalculator;

        public AccountService(IRepository repository, IBonusCalculator bonusCalculator)
        {
            this.accountRepository = repository;
            this.bonusCalculator = bonusCalculator;
        }

        public void OpenAccount(string name, AccountType accountType, IAccountNumberCreateService accountNumberCreateService)
        {
            _ = name ?? throw new ArgumentNullException();
            _ = accountNumberCreateService ?? throw new ArgumentNullException();

            Account account;
            int number = accountNumberCreateService.CreateAccountNumber();

            switch (accountType)
            {
                case AccountType.Base:
                    account = new BaseAccount(number, name, 0, 0);
                    break;
                case AccountType.Silver:
                    account = new SilverAccount(number, name, 0, 0);
                    break;
                case AccountType.Gold:
                    account = new GoldAccount(number, name, 0, 0);
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount(number, name, 0, 0);
                    break;
                default:
                    throw new ArgumentException();
            }

            accountRepository.Add(account);
        }

        public void CloseAccount(int accountNumber)
        {
            accountRepository.Remove(accountNumber);
        }

        public void DepositAccount(int accountNumber, decimal amount)
        {
            var accountType = accountRepository.GetAccountType(accountNumber);
            var bonus = bonusCalculator.GetBonusValue(accountType);

            accountRepository.DepositMoney(accountNumber, amount, bonus);
        }

        public void WithdrawAccount(int accountNumber, decimal amount)
        {
            var accountType = accountRepository.GetAccountType(accountNumber);
            var bonus = bonusCalculator.GetBonusValue(accountType);

            accountRepository.WithdrawMoney(accountNumber, amount, bonus);
        }

        public Account GetAccount(int accountNumber)
        {
            return accountRepository.GetAccount(accountNumber);
        }

        public List<Account> GetAllAccounts()
        {
            return accountRepository.GetAccounts().ToList();
        }
    }
}
