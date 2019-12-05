using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08
{
    [Serializable]
    public class Book : IComparable, IEquatable<Book>, IFormattable
    {
        public int Id { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public DateTime YearPublished { get; set; }

        public int Pages { get; set; }

        public double Price { get; set; }

        /// <summary>
        /// Operator "==" logic.
        /// </summary>
        /// <param name="a">Book a</param>
        /// <param name="b">Book </param>
        /// <returns>True if all properties are equal. Otherwise false.</returns>
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

        /// <summary>
        /// Operator "!=" logic.
        /// </summary>
        /// <param name="a">Book a</param>
        /// <param name="b">Book b</param>
        /// <returns>False if all properties are equal. Otherwise true.</returns>
        public static bool operator !=(Book a, Book b)
        {
            return !(a == b);
        }

        /// <summary>
        /// IComparable interface implementation.
        /// </summary>
        /// <param name="obj">Object Class variable.</param>
        /// <returns>True if books are with equal ISBN. Otherwise false.</returns>
        public int CompareTo(object obj)
        {
            if (obj is Book p)
            {
                return this.ISBN.CompareTo(p.ISBN);
            }
            else
            {
                throw new Exception("Unable to compare!");
            }
        }

        /// <summary>
        /// Object ToString() overriding.
        /// </summary>
        /// <returns>Book as a string.</returns>
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

        /// <summary>
        /// Object Equals() overriding.
        /// </summary>
        /// <param name="obj">Any object class.</param>
        /// <returns>True if objects are equal. Otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Book);
        }

        /// <summary>
        /// Interface implementation.
        /// </summary>
        /// <param name="other">Book class object.</param>
        /// <returns>True if objects are equal. Otherwise false.</returns>
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

        /// <summary>
        /// Object GetHashCode() overriding.
        /// </summary>
        /// <returns>Book object hash code.</returns>
        public override int GetHashCode()
        {
            var hashCode = -619652410;
            hashCode = (hashCode * -1521134295) + Id.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(ISBN);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Publisher);
            hashCode = (hashCode * -1521134295) + YearPublished.GetHashCode();
            hashCode = (hashCode * -1521134295) + Pages.GetHashCode();
            hashCode = (hashCode * -1521134295) + Price.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// IFormattable interface implementation.
        /// </summary>
        /// <param name="format">Format type.</param>
        /// <param name="formatProvider">Culture.</param>
        /// <returns>Book as a string with particular format.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "FULL";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            string outputDateFormat = "yyyy";

            switch (format.ToUpperInvariant())
            {
                case "FULL":
                    return
                    $"ISBN: {ISBN}" +
                    $"\nAuthor: {Author}" +
                    $"\nTitle: {Title}" +
                    $"\nPublisher: {Publisher}" +
                    $"\nYear published: {YearPublished.ToString(outputDateFormat)}" +
                    $"\nPages: {Pages}" +
                    $"\nPrice: {Price}" +
                    $"\n\n";
                case "AT":
                    return
                    $"Author: {Author}" +
                    $"\nTitle: {Title}" +
                    $"\n\n";
                case "IATPUYPR":
                    return
                    $"ISBN: {ISBN}" +
                    $"\nAuthor: {Author}" +
                    $"\nTitle: {Title}" +
                    $"\nPublisher: {Publisher}" +
                    $"\nYear published: {YearPublished.ToString(outputDateFormat)}" +
                    $"\nPrice: {Price}" +
                    $"\n\n";
                default:
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }
    }
}