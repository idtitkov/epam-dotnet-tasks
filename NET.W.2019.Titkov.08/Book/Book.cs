using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08
{
    [Serializable]
    public class Book : IComparable, IComparer<Book>, IEquatable<Book>
    {
        public int Id { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public DateTime YearPublished { get; set; }

        public int Pages { get; set; }

        public double Price { get; set; }

        public static bool operator ==(Book a, Book b)
        {
            if (a.ISBN == b.ISBN &&
                a.Author == b.Author &&
                a.Title == b.Title &&
                a.Publisher == b.Publisher &&
                a.YearPublished == b.YearPublished &&
                a.Pages == b.Pages &&
                a.Price == b.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Book a, Book b)
        {
            return !(a == b);
        }

        public int CompareTo(object obj)
        {
            if (obj is Book p)
            {
                return this.Price.CompareTo(p.Price);
            }
            else
            {
                throw new Exception("Unable to compare!");
            }
        }

        public int Compare(Book x, Book y)
        {
            return (int)(x.Price - y.Price);
        }

        public override string ToString()
        {
            string outputDateFormat = "yyyy";

            string bookToString =
                $"Id: {Id}" +
                $"\nISBN: {ISBN}" +
                $"\nAuthor: {Author}" +
                $"\nTitle: {Title}" +
                $"\nPublisher: {Publisher}" +
                $"\nYear published: {YearPublished.ToString(outputDateFormat)}" +
                $"\nPages: {Pages}" +
                $"\nPrice: {Price}" +
                $"\n\n";

            return bookToString;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Book);
        }

        public bool Equals(Book other)
        {
            return other != null &&
                   Id == other.Id &&
                   ISBN == other.ISBN &&
                   Author == other.Author &&
                   Title == other.Title &&
                   Publisher == other.Publisher &&
                   YearPublished == other.YearPublished &&
                   Pages == other.Pages &&
                   Price == other.Price;
        }

        public override int GetHashCode()
        {
            var hashCode = -619652410;
            hashCode = (hashCode * -1521134295) + this.Id.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.ISBN);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Publisher);
            hashCode = (hashCode * -1521134295) + YearPublished.GetHashCode();
            hashCode = (hashCode * -1521134295) + Pages.GetHashCode();
            hashCode = (hashCode * -1521134295) + Price.GetHashCode();
            return hashCode;
        }
    }
}