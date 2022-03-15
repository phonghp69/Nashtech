using Microsoft.EntityFrameworkCore;
using Back_end.Models;
using Microsoft.EntityFrameworkCore;
namespace Back_end.Responsitory
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected LibraryDbContext()
        {
        }
         public DbSet<User> Users { get; set; }
         public DbSet<Book> Book {get;set; }
         public DbSet<BookBorrowingRequest> Request { get; set; }
         public DbSet<BookBorrowingRequestDetails> RequestDetails { get; set; }
         public DbSet<Category> Categories { get; set; }
    }
}