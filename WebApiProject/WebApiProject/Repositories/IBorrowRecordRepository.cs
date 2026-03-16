using WebApiProject.Models;
namespace WebApiProject.Repositories
{
    public interface  IBorrowRecordRepository
    {
        public void BorrowBook(int BookId);
        public void ReturnBook(int BookId);

        public IEnumerable<BorrowRecord> GetHistory();
    }
}
