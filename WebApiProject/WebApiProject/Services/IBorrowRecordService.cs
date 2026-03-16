using WebApiProject.Models;

namespace WebApiProject.Services
{
    public interface IBorrowRecordService
    {
        public void BorrowBook(int BookId);
        public void ReturnBook(int BookId);

        public IEnumerable<BorrowRecord> GetHistory();
    }
}
