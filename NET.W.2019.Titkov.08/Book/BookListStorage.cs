using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08
{
    public class BookListStorage
    {
        private readonly string filePath = @"D:\Downloads\books.dat";
        private List<Book> books = new List<Book>();

        public BookListStorage()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.OpenOrCreate)))
                {
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    while (reader.PeekChar() > -1)
                    {
                        var book = new Book
                        {
                            Id = reader.ReadInt32(),
                            ISBN = reader.ReadString(),
                            Author = reader.ReadString(),
                            Title = reader.ReadString(),
                            Publisher = reader.ReadString(),
                            YearPublished = DateTime.Parse(reader.ReadString()),
                            Pages = reader.ReadInt32(),
                            Price = reader.ReadDouble(),
                        };

                        Books.Add(book);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Book> Books { get => books; set => books = value; }

        public void Add(Book book)
        {
            try
            {
                // создаем объект BinaryWriter
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Append)))
                {
                    // записываем в файл значение каждого поля структуры
                    writer.Write(book.Id);
                    writer.Write(book.ISBN);
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Publisher);
                    writer.Write(book.YearPublished.ToString());
                    writer.Write(book.Pages);
                    writer.Write(book.Price);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Books.Add(book);
        }

        public void Synchronize()
        {
            try
            {
                // создаем объект BinaryWriter
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    foreach (var book in Books)
                    {
                        // записываем в файл значение каждого поля структуры
                        writer.Write(book.Id);
                        writer.Write(book.ISBN);
                        writer.Write(book.Author);
                        writer.Write(book.Title);
                        writer.Write(book.Publisher);
                        writer.Write(book.YearPublished.ToString());
                        writer.Write(book.Pages);
                        writer.Write(book.Price);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
