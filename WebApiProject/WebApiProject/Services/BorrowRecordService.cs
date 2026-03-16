using WebApiProject.Exceptions;
using WebApiProject.Models;
using WebApiProject.Repositories;

namespace WebApiProject.Services
{
    public class BorrowRecordService:IBorrowRecordService
    {
        private readonly IBorrowRecordRepository _borrowRepository;
        private readonly IBookRepository _bookRepository; 

        public BorrowRecordService(IBorrowRecordRepository borrowRepository, IBookRepository bookRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
        }

  
        public void BorrowBook(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            if (book == null)
                throw new NotFoundException(); 

            if (!book.IsAvailable)
                throw new BookAlreadyBorrowedException(); 

            _borrowRepository.BorrowBook(bookId); 
        }

   
        public void ReturnBook(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            if (book == null)
                throw new NotFoundException(); 

            bool isBorrowed = false;
            foreach (var record in _borrowRepository.GetHistory())
            {
                if (record.BookId == bookId && record.ReturnedAt == null)
                {
                    isBorrowed = true;
                    break; 
                }
            }

            if (!isBorrowed)
            {

                return;
            }

            _borrowRepository.ReturnBook(bookId); 
        }

        public IEnumerable<BorrowRecord> GetHistory()
            {
                return _borrowRepository.GetHistory();
            }
        }
    }

