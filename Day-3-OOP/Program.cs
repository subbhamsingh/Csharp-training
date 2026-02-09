using System;

class Book
{
    public string Title;
    public Book(string title)
    {
        Title = title;
    }

}

class User
{
    public string Name;
    public User(string name)
    {
        Name = name;
    }
}

class LibraryService
{
    public void ShowBook(Book book)
    {
        Console.WriteLine("Book title : " + book.Title);
    }
    public void BorrowBook(Book book, User user)
    {
        Console.WriteLine(user.Name + " borrowed " + book.Title);
    }


}


class Program
{ 
    static void Main()
    {
        Console.Write("Enter user name : ");
        string userName = Console.ReadLine();
        User user = new User(userName);

        Console.Write("Enter Book Title : ");
        string bookName=Console.ReadLine();
        Book book = new Book(bookName);

        LibraryService library = new LibraryService();
        library.ShowBook(book);
        library.BorrowBook(book, user);
    }
}

