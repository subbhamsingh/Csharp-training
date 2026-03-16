using WebApiProject.Models;

namespace WebApiProject.Services
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAllBook();

        public Book GetBookById(int id);

        public void AddBook(Book book);

        public  void UpdateBook(Book book);

        public void DeleteBook(int id);
    }
}
