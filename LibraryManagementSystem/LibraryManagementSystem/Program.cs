using System;

using LibraryManagementSystem.Exceptions;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;


namespace LibraryManagementSystem
{
    class Program
    {
        static void Main()
        {
            // dependency inversion foolowed here 
            ILibraryServices library = new LibraryServices();

            while (true)
            {
                Console.WriteLine("1. Add Book  2.Remove Book 3.Show Books 4. Show Books(No Author) 5.Exit");
                Console.WriteLine("Enter choice:");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Title: ");
                            string title = Console.ReadLine();
                            Console.WriteLine("Author: ");
                            string author = Console.ReadLine();
                            //object creation
                            Book book = new Book(id, title, author);
                            library.AddBook(book);
                            break;

                        case "2":
                            Console.WriteLine("Enter Id to remove: ");
                            int removeId = int.Parse(Console.ReadLine());
                            library.RemoveBook(removeId);
                            break;

                        case "3":
                            library.ShowBooks(); // run time polymorphism
                            break;

                        case "4":
                            library.ShowBooksWithoutAuthor();
                            break;

                        case "5":
                            return;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (BookNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}