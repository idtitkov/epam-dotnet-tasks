using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08
{
    public class BookExtention : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Additional formats for Book string representation.
        /// </summary>
        /// <param name="format">Format</param>
        /// <param name="arg">Book</param>
        /// <param name="formatProvider">IFormatProvider</param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            _ = format ?? throw new ArgumentNullException(nameof(format), "format should not be null.");

            Book book;
            if (arg is Book)
            {
                book = (Book)arg;
            }
            else
            {
                throw new InvalidCastException("arg is not a Book");
            }

            switch (format.ToUpperInvariant())
            {
                case "ATPR":
                    return
                    $"Author: {book.Author}" +
                    $"\nTitle: {book.Title}" +
                    $"\nPrice: {book.Price}" +
                    $"\n\n";
                case "ATPAPR":
                    return
                    $"Author: {book.Author}" +
                    $"\nTitle: {book.Title}" +
                    $"\nPages: {book.Pages}" +
                    $"\nPrice: {book.Price}" +
                    $"\n\n";
                default:
                    HandleOtherFormats(format, arg);
                    break;
            }

            return book.ToString();
        }

        /// <summary>
        /// IFormatProvider implementation.
        /// </summary>
        /// <param name="formatType">This</param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Unknown formats processing.
        /// </summary>
        /// <param name="format">Format</param>
        /// <param name="arg">Book</param>
        /// <returns></returns>
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
