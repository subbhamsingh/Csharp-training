using LibraryManagementSystem.Models;


namespace LibraryManagementSystem.Interfaces
{
    public interface ILibraryServices
    {
        // why no specifier for each of these 
        // by default all members are public in an interface  
        void AddBook(Book book);
        void RemoveBook(int id);
        void ShowBooks();
        void ShowBooksWithoutAuthor();
    }

}
