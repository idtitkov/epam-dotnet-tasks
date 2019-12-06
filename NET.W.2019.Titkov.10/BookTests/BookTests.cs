using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.W._2019.Titkov._08;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08.Tests
{
    [TestClass()]
    public class BookTests
    {
        [TestMethod()]
        public void BookToStringATFormat()
        {
            // Arrange
            string inputDateFormat = "yyyy";
            CultureInfo CultureInfo = CultureInfo.InvariantCulture;

            Book book = new Book
            {
                Id = 1,
                ISBN = "978-5-9614-6742-0",
                Author = "Айн Рэнд",
                Title = "Атлант расправил плечи",
                Publisher = "Альпина Паблишер",
                YearPublished = DateTime.ParseExact("2019", inputDateFormat, CultureInfo),
                Pages = 1408,
                Price = 28.31,
            };

            string expected = "Author: Айн Рэнд" +
                              "\nTitle: Атлант расправил плечи" +
                              "\n\n";

            // Act
            string actual = book.ToString("AT", CultureInfo);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BookToStringIATPUYPRFormat()
        {
            // Arrange
            string inputDateFormat = "yyyy";
            CultureInfo CultureInfo = CultureInfo.InvariantCulture;

            Book book = new Book
            {
                Id = 1,
                ISBN = "978-5-17-103595-2",
                Author = "Джордж Оруэлл",
                Title = "1984",
                Publisher = "АСТ",
                YearPublished = DateTime.ParseExact("2018", inputDateFormat, CultureInfo),
                Pages = 320,
                Price = 11.21,
            };

            string expected = "ISBN: 978-5-17-103595-2" +
                              "\nAuthor: Джордж Оруэлл" +
                              "\nTitle: 1984" +
                              "\nPublisher: АСТ" +
                              "\nYear published: 2018" +
                              "\nPrice: 11,21" +
                              "\n\n"; ;

            // Act
            string actual = book.ToString("IATPUYPR", CultureInfo);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }

    [TestClass()]
    public class BookExtentionTests
    {
        [TestMethod()]
        public void BookToStringATPRFormat()
        {
            // Arrange
            string inputDateFormat = "yyyy";
            CultureInfo CultureInfo = CultureInfo.InvariantCulture;

            Book book = new Book
            {
                Id = 1,
                ISBN = "978-5-389-01686-6",
                Author = "Михаил Булгаков",
                Title = "Мастер и Маргарита",
                Publisher = "Азбука",
                YearPublished = DateTime.ParseExact("2016", inputDateFormat, CultureInfo),
                Pages = 480,
                Price = 7.55,
            };

            string expected = "Author: Михаил Булгаков" +
                              "\nTitle: Мастер и Маргарита" +
                              "\nPrice: 7,55" +
                              "\n\n"; ;

            // Act
            string actual = string.Format(new BookExtention(), "{0:ATPR}", book);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BookToStringATPAPRFormat()
        {
            // Arrange
            string inputDateFormat = "yyyy";
            CultureInfo CultureInfo = CultureInfo.InvariantCulture;

            Book book = new Book
            {
                Id = 1,
                ISBN = "978-5-17-082358-1",
                Author = "Эрих Мария Ремарк",
                Title = "Три товарища",
                Publisher = "АСТ",
                YearPublished = DateTime.ParseExact("2014", inputDateFormat, CultureInfo),
                Pages = 480,
                Price = 12.77,
            };

            string expected = "Author: Эрих Мария Ремарк" +
                              "\nTitle: Три товарища" +
                              "\nPages: 480" +
                              "\nPrice: 12,77" +
                              "\n\n";

            // Act
            string actual = string.Format(new BookExtention(), "{0:ATPAPR}", book);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}