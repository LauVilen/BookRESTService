using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary;

namespace BookRESTService.Managers
{
    public class BooksManager
    {
        //The assignment stated to put the static list of books in the controller, but it seemed more appropriate to put it in the manager class, so that's what I did.
        private static readonly List<Book> _books = new List<Book>
        {
            new Book(){ISBN13 = "9780609806951", Title = "Who Cooked the Last Supper?", Author = "Rosalind Miles", NumberOfPages = 352},
            new Book(){ISBN13 = "9781911344056", Title = "South of Forgiveness", Author = "Thordis Elva", NumberOfPages = 320},
            new Book(){ISBN13 = "9788702055023", Title = "Paula", Author = "Isabel Allende", NumberOfPages = 337}
        };

        /// <summary>
        /// Method that returns a static list of books
        /// </summary>
        /// <returns>A List</returns>
        public List<Book> GetAll()
        {
            return new List<Book>(_books);
        }

        /// <summary>
        /// Method that takes an ISBN13 as an argument to search the static list of books for an instance with a matching isbn and return it
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns>A Book</returns>
        public Book GetByISBN(string isbn)
        {
            return _books.Find(book => book.ISBN13 == isbn);
        }

        /// <summary>
        /// Adds a book to the static list, as long as no matching ISBN number already exists in the list
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        public Book Add(Book newBook)
        {
            if (!_books.Exists(book => newBook.ISBN13 == book.ISBN13))
            {
                _books.Add(newBook);
                return newBook;
            }

            return null;
        }

        /// <summary>
        /// Deletes a book with the same ISBN13 as the given argument, from the static list
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public Book Delete(string isbn)
        {
            Book bookToDelete = _books.Find(book => book.ISBN13 == isbn);
            if (bookToDelete == null) return null;
            _books.Remove(bookToDelete);
            return bookToDelete;
        }

        /// <summary>
        /// Takes a book with the same ISBN13 as the string argument and replaces its properties with those of the book object given as an argument
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="updateBook"></param>
        /// <returns></returns>
        public Book Update(string isbn, Book updateBook)
        {
            Book bookToUpdate = _books.Find(book => book.ISBN13 == isbn);
            if (bookToUpdate == null) return null;
            bookToUpdate.Title = updateBook.Title;
            bookToUpdate.Author = updateBook.Author;
            bookToUpdate.NumberOfPages = updateBook.NumberOfPages;
            bookToUpdate.ISBN13 = updateBook.ISBN13;
            return bookToUpdate;
        }
    }
}
