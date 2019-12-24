using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        public static void Main(string[] args)
        {
            IAccountService service = Resolver.Get<IAccountService>();
            IAccountNumberCreateService creator = Resolver.Get<IAccountNumberCreateService>();

            service.OpenAccount("Base acc owner 1", AccountType.Base, creator);
            service.OpenAccount("Silver acc owner 2", AccountType.Silver, creator);
            service.OpenAccount("Gold acc owner 3", AccountType.Gold, creator);
            service.OpenAccount("Platinum acc owner 4", AccountType.Platinum, creator);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            foreach (var t in creditNumbers)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
                Console.WriteLine();
                var qwe = AccountMapper.ConvertToDTO(item);
            }
        }
    }
}
