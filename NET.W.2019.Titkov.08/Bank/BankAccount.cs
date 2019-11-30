using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08
{
    /// <summary>
    /// Card types.
    /// </summary>
    public enum Grades
    {
        Base = 1,
        Gold = 2,
        Platinum = 3
    }

    [Serializable]
    public class BankAccount : IComparable, IComparer<BankAccount>, IEquatable<BankAccount>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public double Balance { get; set; }

        public int Bonus { get; set; }

        public Grades Grade { get; set; }

        public static bool operator ==(BankAccount left, BankAccount right)
        {
            return left.FirstName == right.FirstName &&
                   left.Surname == right.Surname &&
                   left.Balance == right.Balance &&
                   left.Bonus == right.Bonus &&
                   left.Grade == right.Grade;
        }

        public static bool operator !=(BankAccount left, BankAccount right)
        {
            return !(left == right);
        }

        public int Compare(BankAccount x, BankAccount y)
        {
            return (int)(x.Balance - y.Balance);
        }

        public int CompareTo(object obj)
        {
            if (obj is BankAccount b)
            {
                return this.Balance.CompareTo(b.Balance);
            }
            else
            {
                throw new Exception("Unable to compare!");
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as BankAccount);
        }

        public bool Equals(BankAccount other)
        {
            return other != null &&
                   Id == other.Id &&
                   FirstName == other.FirstName &&
                   Surname == other.Surname &&
                   Balance == other.Balance &&
                   Bonus == other.Bonus &&
                   Grade == other.Grade;
        }

        public override int GetHashCode()
        {
            var hashCode = 1061079171;
            hashCode = (hashCode * -1521134295) + Id.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = (hashCode * -1521134295) + Balance.GetHashCode();
            hashCode = (hashCode * -1521134295) + Bonus.GetHashCode();
            hashCode = (hashCode * -1521134295) + Grade.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            string accountToString =
                $"Id: {Id}" +
                $"\nFirst Name: {FirstName}" +
                $"\nSurname: {Surname}" +
                $"\nBalance: {Balance}" +
                $"\nBonus: {Bonus}" +
                $"\nGrade: {Grade.ToString()}" +
                $"\n";

            return accountToString;
        }
    }
}
