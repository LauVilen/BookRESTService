using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary;

namespace BookRESTService.Managers
{
    public class BookManager
    {
        private static readonly List<Book> _books = new List<Book>
        {
            new Book(){ISBN13 = "9780609806951", Title = "Who Cooked the Last Supper?", Author = "Rosalind Miles", NumberOfPages = 352},
            new Book(){ISBN13 = "9781911344056", Title = "South of Forgiveness", Author = "Thordis Elva", NumberOfPages = 320},
            new Book(){ISBN13 = "9788702055023", Title = "Paula", Author = "Isabel Allende", NumberOfPages = 337}
        };
        public List<Book> GetAll()
        {
            return new List<Book>(_books);
        }

        public Book GetById(string isbn)
        {
            return _books.Find(book => book.ISBN13 == isbn);
        }

        public Book Add(Book newBook)
        {
            if (!_books.Exists(book => newBook.ISBN13 == book.ISBN13))
            {
                _books.Add(newBook);
                return newBook;
            }
            else
            {
                throw new DuplicateNameException(
                    "This ISBN number already exists in the database. Please try another ISBN number");
            }
        }

        public Book Delete(string isbn)
        {
            Book bookToDelete = _books.Find(book => book.ISBN13 == isbn);
            if (bookToDelete == null) return null;
            _books.Remove(bookToDelete);
            return bookToDelete;
        }

        public Book Update(string isbn, Book updateBook)
        {
            Book bookToUpdate = _books.Find(book => book.ISBN13 == isbn);
            if (bookToUpdate == null) return null;
            bookToUpdate.Title = updateBook.Title;
            bookToUpdate.Author = updateBook.Author;
            bookToUpdate.NumberOfPages = updateBook.NumberOfPages;
            bookToUpdate.ISBN13 = bookToUpdate.ISBN13;
            return bookToUpdate;
        }
    }
}
