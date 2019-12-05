using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08
{
    public class BookListService
    {
        private const string DateFormat = "yyyy";
        private BookListStorage bookListStorage = new BookListStorage();

        /// <summary>
        /// All possible tags to apply to book.
        /// </summary>
        public enum BookTags
        {
            Id = 1,
            ISBN,
            Author,
            Title,
            Publisher,
            YearPublished,
            Pages,
            Price
        }

        /// <summary>
        /// Adds book to storage.
        /// </summary>
        /// <param name="isbn">ISBN</param>
        /// <param name="author">Author</param>
        /// <param name="title">Title</param>
        /// <param name="publisher">Publisher</param>
        /// <param name="yearPublished">YearPublished</param>
        /// <param name="pages">Pages</param>
        /// <param name="price">Price</param>
        public void AddBook(string isbn, string author, string title, string publisher, DateTime yearPublished, int pages, double price)
        {
            _ = isbn ?? throw new ArgumentException("Value should not be null", nameof(isbn));
            _ = author ?? throw new ArgumentException("Value should not be null", nameof(author));
            _ = title ?? throw new ArgumentException("Value should not be null", nameof(title));
            _ = publisher ?? throw new ArgumentException("Value should not be null", nameof(publisher));

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

        /// <summary>
        /// Removes book from storage by ISBN.
        /// </summary>
        /// <param name="isbn">ISBN</param>
        public void RemoveBook(string isbn)
        {
            _ = isbn ?? throw new ArgumentException("Value should not be null", nameof(isbn));

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

        /// <summary>
        /// Finds book by tag.
        /// </summary>
        /// <param name="tag">Tag</param>
        /// <param name="value">Tag value</param>
        /// <returns></returns>
        public List<Book> FindBookByTag(BookTags tag, string value)
        {
            _ = value ?? throw new ArgumentException("Value should not be null", nameof(value));

            List<Book> searchResult = new List<Book>();

            switch (tag)
            {
                case BookTags.Id:
                    if (int.TryParse(value, out var id))
                    {
                        searchResult = bookListStorage.Books.Where(b => b.Id == id).ToList();
                    }

                    break;
                case BookTags.ISBN:
                    searchResult = bookListStorage.Books.Where(b => b.ISBN == value).ToList();
                    break;
                case BookTags.Author:
                    searchResult = bookListStorage.Books.Where(b => b.Author == value).ToList();
                    break;
                case BookTags.Title:
                    searchResult = bookListStorage.Books.Where(b => b.Title == value).ToList();
                    break;
                case BookTags.Publisher:
                    searchResult = bookListStorage.Books.Where(b => b.Publisher == value).ToList();
                    break;
                case BookTags.YearPublished:
                    if (DateTime.TryParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var year))
                    {
                        searchResult = bookListStorage.Books.Where(b => b.YearPublished == year).ToList();
                    }

                    break;
                case BookTags.Pages:
                    if (int.TryParse(value, out var pages))
                    {
                        searchResult = bookListStorage.Books.Where(b => b.Pages == pages).ToList();
                    }

                    break;
                case BookTags.Price:
                    if (double.TryParse(value, out var price))
                    {
                        searchResult = bookListStorage.Books.Where(b => b.Price == price).ToList();
                    }

                    break;
                default:
                    break;
            }

            return searchResult;
        }

        /// <summary>
        /// Sorts book by tag.
        /// </summary>
        /// <param name="tag">Tag</param>
        public void SortBooksByTag(BookTags tag)
        {
            List<Book> sortedBooks = new List<Book>();

            switch (tag)
            {
                case BookTags.Id:
                    sortedBooks = bookListStorage.Books.OrderBy(b => b.Id).ToList();
                    break;
                case BookTags.ISBN:
                    sortedBooks = bookListStorage.Books.OrderBy(b => b.ISBN).ToList();
                    break;
                case BookTags.Author:
                    sortedBooks = bookListStorage.Books.OrderBy(b => b.Author).ToList();
                    break;
                case BookTags.Title:
                    sortedBooks = bookListStorage.Books.OrderBy(b => b.Title).ToList();
                    break;
                case BookTags.Publisher:
                    sortedBooks = bookListStorage.Books.OrderBy(b => b.Publisher).ToList();
                    break;
                case BookTags.YearPublished:
                    sortedBooks = bookListStorage.Books.OrderBy(b => b.YearPublished).ToList();
                    break;
                case BookTags.Pages:
                    sortedBooks = bookListStorage.Books.OrderBy(b => b.Pages).ToList();
                    break;
                case BookTags.Price:
                    sortedBooks = bookListStorage.Books.OrderBy(b => b.Price).ToList();
                    break;
                default:
                    break;
            }

            bookListStorage.Books = sortedBooks;

            bookListStorage.Synchronize();
        }

        /// <summary>
        /// Prints all storage to Console. Debugging method.
        /// </summary>
        public void PrintAll()
        {
            bookListStorage.Books.ForEach(book => Console.Write(book));
        }
    }
}