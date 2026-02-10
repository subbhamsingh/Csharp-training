using System;

//interface
interface IBookService
{
    void AddBook(string bookName);
    void GetBook(string bookName);
}

// custom exception handling
class BookNotFoundException : ApplicationException
{
    public override string Message
    {
        get
        {
            return "Book not Found in the sytem";
        }
    }
}

//Book service implementation
class BookService: IBookService
{
    List<string> books = new List<string>();
    public void AddBook(string bookName)
    {
        books.Add(bookName);
        Console.WriteLine("Book Added " + bookName);
    }

    public void GetBook(string bookName)
    {
        if (!books.Contains(bookName))
            throw new BookNotFoundException();

        Console.WriteLine("Book found " + bookName);
    }

}

class Program
{
    static void Main()
    {
        IBookService service = new BookService();
        service.AddBook("C# basics");
        try
        {
            service.GetBook("Java");

        }
        catch(BookNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
