using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BankService bankService = new BankService();

            Console.WriteLine("All Acoounts:");
            bankService.CreateAccount("Ivan", "Ivanov", 0, 0, Grades.Base);
            bankService.CreateAccount("Petr", "Petrov", 346.65, 1, Grades.Gold);
            bankService.CreateAccount("Vasil", "Vasilyev", 1246.50, 5, Grades.Platinum);
            bankService.ShowAll();

            Console.WriteLine("Acoounts after deposit:");
            bankService.DepositMoney(3, 253.50);
            bankService.ShowAll();

            Console.WriteLine("Acoounts after withdrawal:");
            bankService.WithdrawMoney(3, 253.50);
            bankService.ShowAll();

            Console.WriteLine("Acoounts after closing:");
            bankService.CloseAccount("Vasil", "Vasilyev");
            bankService.ShowAll();
        }
    }
}
