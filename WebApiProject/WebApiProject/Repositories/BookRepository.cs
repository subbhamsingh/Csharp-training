//using WebApiProject.Models;
//using WebApiProject.Repositories;

//namespace WebApiProject.Repositories
//{
//    public class BookRepository : IBookRepository
//    {

//        private readonly List<Book> _books;


//        public BookRepository()
//        {
//            _books = new List<Book>();
//        }

//        public IEnumerable<Book> GetAll()
//        {
//            return _books;
//        }

//        public Book GetById(int id)
//        {
//            return _books.FirstOrDefault(b => b.Id == id);
//        }

//        public void Add(Book book)
//        {
//            _books.Add(book);
//        }

//        public void Update(Book book)
//        {
//            var existing = GetById(book.Id);
//            if (existing == null) throw new Exception($"Id:{book.Id} not found");

//            existing.Title = book.Title;
//            existing.Author = book.Author;
//            existing.Isbn = book.Isbn;
//        }

//        public void Delete(int id)
//        {
//            var existing = GetById(id);
//            if (existing == null) throw new Exception($"Id:{id} not found");

//            _books.Remove(existing);
//        }

//    }
//}



using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            var existing = _context.Books.FirstOrDefault(b => b.Id == book.Id);
            if (existing == null)
                throw new Exception($"Id:{book.Id} not found");

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Isbn = book.Isbn;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existing = _context.Books.FirstOrDefault(b => b.Id == id);
            if (existing == null)
                throw new Exception($"Id:{id} not found");

            _context.Books.Remove(existing);
            _context.SaveChanges();
        }
    }
}