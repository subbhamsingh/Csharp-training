using WebApiProject.Models;
namespace WebApiProject.Repositories
{
    public interface IBookRepository
    {

        public IEnumerable<Book> GetAll();


        public Book GetById(int id);

        public void Add(Book book);

        public void Update(Book book);

        public void Delete(int id);

    }

}


