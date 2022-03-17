using Microsoft.EntityFrameworkCore;
using Back_end.Entities;
using Microsoft.EntityFrameworkCore;
namespace Back_end.DBContext
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected LibraryDbContext()
        {
        }
         public DbSet<User> User { get; set; }
         public DbSet<Book> Book {get;set; }
         public DbSet<BookBorrowingRequest> Request { get; set; }
         public DbSet<BookBorrowingRequestDetails> RequestDetails { get; set; }
         public DbSet<Category> Category { get; set; }
    }
}