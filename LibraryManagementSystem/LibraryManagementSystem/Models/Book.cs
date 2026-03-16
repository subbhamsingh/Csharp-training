using System;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        private int Id;  // data hidden
        public string Title;
        public String Author;

        // constrctor for making objects 
        public Book(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }

        // safely accessing using get ( read-only) property Encapsulation 
        public int _Id
        {
            get { return Id; }
        }
        // compile time polymorphism 
        public void Display()
        {
            Console.WriteLine("ID: " + Id + ", Title: " + Title + ", Author: " + Author);
        }

        public int Display(bool showAuthor)
        {
            if (showAuthor)
                Console.WriteLine("ID: " + Id + ", Title: " + Title + ", Author: " + Author);
            else
                Console.WriteLine("ID: " + Id + ", Title: " + Title);
            return Id;
        }
    }

}
