using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08
{
    public class BookListService
    {
        private BookListStorage bookListStorage = new BookListStorage();

        public void AddBook(string isbn, string author, string title, string publisher, DateTime yearPublished, int pages, double price)
        {
            bool isBookUnique = true;

            var newBook = new Book
            {
                Id = this.bookListStorage.Books.Count + 1,
                ISBN = isbn,
                Author = author,
                Title = title,
                Publisher = publisher,
                YearPublished = yearPublished,
                Pages = pages,
                Price = price,
            };

            foreach (var existingBook in bookListStorage.Books)
            {
                if (newBook == existingBook)
                {
                    isBookUnique = false;
                    throw new Exception("Book already exists!");
                }
            }

            if (isBookUnique)
            {
                this.bookListStorage.Add(newBook);
            }
        }

        public void RemoveBook(string isbn)
        {
            List<Book> booksAfterRemoving = new List<Book>();
            booksAfterRemoving = bookListStorage.Books.Where(x => x.ISBN != isbn).ToList();

            if (booksAfterRemoving.Count == bookListStorage.Books.Count)
            {
                throw new Exception("Nothing to remove!");
            }
            else
            {
                bookListStorage.Books = booksAfterRemoving;
                bookListStorage.Synchronize();
            }
        }

        public void FindBookByTag(string isbn)
        {
            List<Book> booksWithTag = new List<Book>();

            booksWithTag = bookListStorage.Books.Where(x => x.ISBN == isbn).ToList();

            booksWithTag.ForEach(book => Console.Write(book));
        }

        public void SortBooksByTag()
        {
            List<Book> sortedBooks = new List<Book>();
            sortedBooks = bookListStorage.Books.OrderBy(b => b.ISBN).ToList();

            bookListStorage.Books = sortedBooks;
            bookListStorage.Synchronize();
        }

        public void PrintAll()
        {
            bookListStorage.Books.ForEach(book => Console.Write(book));
        }
    }
}