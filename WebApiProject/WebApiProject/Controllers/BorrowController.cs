using Microsoft.AspNetCore.Mvc;
using WebApiProject.Services;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowRecordService _borrowService;

        public BorrowController(IBorrowRecordService borrowService)
        {
            _borrowService = borrowService;
        }

        [HttpPost("{bookId:int}")]
        public IActionResult Borrow(int bookId)
        {
            _borrowService.BorrowBook(bookId);  
            return Ok();         
        }

        [HttpPost("return/{bookId:int}")]
        public IActionResult Return(int bookId)
        {
            _borrowService.ReturnBook(bookId); 
            return Ok();
        }
        [HttpGet("history")]
        public IActionResult History()
        {
            var history = _borrowService.GetHistory();
            return Ok(history);
        }
    }

}
