using System;
using System.Collections.Generic;
using WebApiProject.Exceptions;
using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {
        private List<BorrowRecord> _borrowRecords = new List<BorrowRecord>();
        private IBookRepository _bookRepository;

     
        public BorrowRecordRepository(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

     
        public void BorrowBook(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            if (book == null)
                throw new NotFoundException(); 

            book.IsAvailable = false;
            _bookRepository.Update(book);

            var record = new BorrowRecord
            {
                Id = _borrowRecords.Count + 1,
                BookId = bookId,
                BorrowedAt = DateTime.Now,
                ReturnedAt = null
            };

            _borrowRecords.Add(record);
        }


     
        public void ReturnBook(int bookId)
        {
            Book book = _bookRepository.GetById(bookId);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            book.IsAvailable = true;
            _bookRepository.Update(book);

           
            for (int i = 0; i < _borrowRecords.Count; i++)
            {
                if (_borrowRecords[i].BookId == bookId && _borrowRecords[i].ReturnedAt == null)
                {
                    _borrowRecords[i].ReturnedAt = DateTime.Now;
                    break;
                }
            }
        }

  
        public IEnumerable<BorrowRecord> GetHistory()
        {
            return _borrowRecords;
        }
    }
}
