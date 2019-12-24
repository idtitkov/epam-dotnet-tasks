using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class StandartBonusCalculator : IBonusCalculator
    {
        public double GetBonusValue(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Base:
                    return 0.01;
                case AccountType.Silver:
                    return 0.05;
                case AccountType.Gold:
                    return 0.10;
                case AccountType.Platinum:
                    return 0.15;
                default:
                    break;
            }

            return 0;
        }
    }
}
