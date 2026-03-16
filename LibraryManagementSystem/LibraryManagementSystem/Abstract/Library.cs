using System;
using LibraryManagementSystem.Models; // important to add 

namespace LibraryManagementSystem.Abstract
{
    // problem why it is abstract class , 
    public abstract  class Library
    {
        public List<Book> books = new List<Book>(); // shared member 

        // run time polymoprphism
        public virtual void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Books Added.");

        }



    }
}
