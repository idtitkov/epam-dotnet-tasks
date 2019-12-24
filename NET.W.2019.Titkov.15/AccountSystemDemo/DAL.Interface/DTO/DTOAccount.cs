using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DTOAccount
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public int AccountType { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public int Bonus { get; set; }
    }
}
