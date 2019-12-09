using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NET.W._2019.Titkov._08
{
    public class BookListService
    {
        private const string DateFormat = "yyyy";

        // Iloger interface instance.
        private ILogger logger;

        private BookListStorage bookListStorage = new BookListStorage();


        /// <summary>
        /// Service constructor.
        /// </summary>
        /// <param name="logger">Logges is ILogger Instance.</param>
        public BookListService(ILogger logger)
        {
            this.logger = logger;
            logger.Debug("Logger initialized.");
        }

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
            if (isbn == null)
            {
                logger.Error("isbn value is null");
                throw new ArgumentException("Value should not be null", nameof(isbn));
            }

            if (author == null)
            {
                logger.Error("author value is null");
                throw new ArgumentException("Value should not be null", nameof(author));
            }

            if (title == null)
            {
                logger.Error("title value is null");
                throw new ArgumentException("Value should not be null", nameof(title));
            }

            if (publisher == null)
            {
                logger.Error("publisher value is null");
                throw new ArgumentException("Value should not be null", nameof(publisher));
            }

            bool isBookUnique = true;

            logger.Trace("New book created");
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

            logger.Trace("Book duplacate checking.");
            foreach (var existingBook in bookListStorage.Books)
            {
                if (newBook == existingBook)
                {
                    isBookUnique = false;
                    logger.Warn("Book duplicate detected.");
                    throw new Exception("Book already exists!");
                }
            }

            if (isBookUnique)
            {
                logger.Info("Book added to storage.");
                this.bookListStorage.Add(newBook);
            }
        }

        /// <summary>
        /// Removes book from storage by ISBN.
        /// </summary>
        /// <param name="isbn">ISBN</param>
        public void RemoveBook(string isbn)
        {
            if (isbn == null)
            {
                logger.Error("isbn value is null");
                throw new ArgumentException("Value should not be null", nameof(isbn));
            }

            List<Book> booksAfterRemoving = new List<Book>();

            logger.Trace("Trying to remove book");
            booksAfterRemoving = bookListStorage.Books.Where(x => x.ISBN != isbn).ToList();

            if (booksAfterRemoving.Count == bookListStorage.Books.Count)
            {
                logger.Warn("Book to remove is not found.");
                throw new Exception("Nothing to remove!");
            }
            else
            {
                bookListStorage.Books = booksAfterRemoving;

                logger.Debug("Writing changes to storage");
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
            if (value == null)
            {
                logger.Error("string value is null");
                throw new ArgumentException("Value should not be null", nameof(value));
            }

            List<Book> searchResult = new List<Book>();

            logger.Trace($"Serching for book by tag {tag} and value {value}");

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

            logger.Trace($"Sorting book by tag {tag}");

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

            logger.Debug("Writing changes to storage");
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