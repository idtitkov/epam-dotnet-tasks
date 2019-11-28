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
        private static CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        public static void Main(string[] args)
        {
            string inputDateFormat = "yyyy";
            BookListService bookListService = new BookListService();

            bookListService.AddBook("978-5-9614-6742-0", "Айн Рэнд", "Атлант расправил плечи", "Альпина Паблишер", DateTime.ParseExact("2019", inputDateFormat, cultureInfo), 1408, 28.31);
            bookListService.AddBook("978-5-17-103595-2", "Джордж Оруэлл", "1984", "АСТ", DateTime.ParseExact("2018", inputDateFormat, cultureInfo), 320, 11.21);
            bookListService.AddBook("978-5-389-01686-6", "Михаил Булгаков", "Мастер и Маргарита", "Азбука", DateTime.ParseExact("2016", inputDateFormat, cultureInfo), 480, 7.55);
            bookListService.AddBook("978-5-17-082358-1", "Эрих Мария Ремарк", "Три товарища", "АСТ", DateTime.ParseExact("2014", inputDateFormat, cultureInfo), 480, 12.77);
            bookListService.AddBook("978-5-389-04926-0", "Федор Достоевский", "Преступление и наказание", "Азбука", DateTime.ParseExact("2017", inputDateFormat, cultureInfo), 608, 6.58);

            Console.WriteLine("Storage before sorting:");
            bookListService.PrintAll();

            bookListService.SortBooksByTag();

            Console.WriteLine("Storage after sorting:");
            bookListService.PrintAll();

            bookListService.RemoveBook("978-5-9614-6742-0");

            Console.WriteLine("Storage after removing:");
            bookListService.PrintAll();

            Console.WriteLine("Search results:");
            bookListService.FindBookByTag("978-5-17-082358-1");
        }
    }
}
