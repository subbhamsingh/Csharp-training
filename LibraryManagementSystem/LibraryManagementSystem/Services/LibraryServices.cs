using System;

using LibraryManagementSystem.Abstract;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Exceptions;

namespace LibraryManagementSystem.Services
{
    public class LibraryServices : Library, ILibraryServices  // inheritance occur here 
    {

        public  void AddBook(Book book)  // run time polymorphism 
        {
            base.AddBook(book);
            //books.Add(book);
        }

        public void RemoveBook(int id)
        {
            Book found = null;
            foreach (Book b in books)
            {
                if (b._Id == id)
                {
                    found = b;
                    break;
                }
            }
            if (found == null)
            {
                throw new BookNotFoundException();
            }
            books.Remove(found);
            Console.WriteLine("Book Removed");
        }

        public void ShowBooks()
        {
            foreach (Book b in books)
            {
                b.Display();
            }
        }

        public void ShowBooksWithoutAuthor()
        {
            foreach (Book b in books)
            {
                b.Display(false); // calls overloaded method
            }
        }
    }
}
