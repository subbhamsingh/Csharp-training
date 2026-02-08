using System;
using System.Collections.Generic;

class  Program
{
    static List<string> books = new List<string>();
     static void Main()
    {
        while (true)
        {
            Console.WriteLine("Book Manager System");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Remove a Book");
            Console.WriteLine("3. Search a Book");
            Console.WriteLine("4.Exit from system");

            Console.Write("Choose the option from menu");
            int choice=Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: AddBook();
                    break;
                case 2: RemoveBook();
                    break;
                case 3: SearchBook();
                    break;
                case 4: return;
                default: Console.WriteLine("Invalid choice");
                    break;
            }

        }
    }

    static void AddBook()
    {
        Console.WriteLine("Enter Book name");
        string book= Console.ReadLine(); 
        if(!string.IsNullOrEmpty(book))
        {
            books.Add(book);
            Console.WriteLine("Book Added");
        }
        else
        {
            Console.WriteLine("Invalid name");
        }
    }

    static void RemoveBook()
    {
        Console.Write("Enter book name to remove");
        string book=Console.ReadLine();
        if (books.Remove(book))
        {
            Console.WriteLine("Book removed");

        }
        else
        {
            Console.WriteLine("Book not found");
        }
    }

    static void SearchBook()
    {
        Console.Write("Enter book name to search");
        string book = Console.ReadLine();
        if (books.Contains(book))
        {
            Console.WriteLine("Book found");

        }
        else
        {
            Console.WriteLine("Book not found");
        }
    }
}
