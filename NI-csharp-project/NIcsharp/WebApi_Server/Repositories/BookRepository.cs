using System.Collections.Generic;
using System.Linq;
using WebApi_Common.Models;

namespace WebApi_Server.Repositories
{
    public static class BookRepository
    {
        public static IEnumerable<Book> GetBooks()
        {
            using (var database = new BookContext())
            {
                var books = database.Books.ToList();

                return books;
            }
        }

        public static Book GetBook(long id)
        {
            using (var database = new BookContext())
            {
                var person = database.Books.ToList().Where(b => b.Id == id).FirstOrDefault();

                return person;
            }

        }

        public static IEnumerable<Book> GetBooksOfBorrower(string borrower)
        {
            using (var database = new BookContext())
            {
                var books = database.Books.ToList().Where(b => b.NameOfBorrower == borrower).ToList();

                return books;
            }

        }

        public static void AddBook(Book book)
        {
            using (var database = new BookContext())
            {
                database.Books.Add(book);

                database.SaveChanges();
            }
        }

        public static void UpdateBook(Book book)
        {
            using (var database = new BookContext())
            {
                database.Books.Update(book);

                database.SaveChanges();
            }
        }

        public static void DeleteBook(Book book)
        {
            using (var database = new BookContext())
            {
                database.Books.Remove(book);

                database.SaveChanges();
            }
        }
    }
}
