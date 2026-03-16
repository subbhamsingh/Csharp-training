using WebApiProject.Models;
using WebApiProject.Repositories;
using WebApiProject.Exceptions; 

namespace WebApiProject.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Book> GetAllBook()
        {
            return _repository.GetAll();
        }

        public Book GetBookById(int id)
        {
            var book = _repository.GetById(id);
            if (book == null)
                throw new NotFoundException(); 

            return book;
        }

        public void AddBook(Book book)
        {
            var existing = _repository.GetAll();
            foreach (var b in existing)
            {
                if (b.Isbn == book.Isbn)
                    throw new BookAlreadyBorrowedException(); 
            }

            _repository.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existing = _repository.GetById(book.Id);
            if (existing == null)
                throw new NotFoundException();

            existing.Title = book.Title;
            existing.Author = book.Author;

            _repository.Update(existing);
        }

        public void DeleteBook(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                throw new NotFoundException();

            if (!existing.IsAvailable)
                throw new BookAlreadyBorrowedException();

            _repository.Delete(id);
        }
    }
}
