using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;
namespace WebApiProject.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
    }
}
