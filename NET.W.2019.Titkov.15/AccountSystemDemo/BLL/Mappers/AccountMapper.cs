using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class AccountMapper
    {
        public static DTOAccount ConvertToDTO(this Account account)
        {
            return new DTOAccount
            {
                Id = account.AccountNumber,
                IsActive = account.IsActive,
                AccountType = (int)GetAccountType(account).GetProperty("Type").GetValue(account),
                Name = account.Name,
                Balance = account.Balance,
                Bonus = account.Bonus,
            };
        }

        public static Account ConvertToAccount(this DTOAccount dtoAccount)
        {
            switch (dtoAccount.AccountType)
            {
                case (int)AccountType.Base:
                    return new BaseAccount(dtoAccount.Id, dtoAccount.Name, dtoAccount.Balance, dtoAccount.Bonus);
                case (int)AccountType.Silver:
                    return new BaseAccount(dtoAccount.Id, dtoAccount.Name, dtoAccount.Balance, dtoAccount.Bonus);
                case (int)AccountType.Gold:
                    return new BaseAccount(dtoAccount.Id, dtoAccount.Name, dtoAccount.Balance, dtoAccount.Bonus);
                case (int)AccountType.Platinum:
                    return new BaseAccount(dtoAccount.Id, dtoAccount.Name, dtoAccount.Balance, dtoAccount.Bonus);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Type GetAccountType(Account account)
        {
            if (account is BaseAccount)
            {
                return typeof(BaseAccount);
            }
            else if (account is SilverAccount)
            {
                return typeof(SilverAccount);
            }
            else if (account is GoldAccount)
            {
                return typeof(GoldAccount);
            }
            else if (account is PlatinumAccount)
            {
                return typeof(PlatinumAccount);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
