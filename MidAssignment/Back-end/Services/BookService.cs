using Back_end.Entities;
using Back_end.Models;
using Back_end.DBContext;

namespace Back_end.Services
{
    public class BookService : IService<Book>
    {
        private readonly LibraryDbContext _dbContext;
        
         public BookService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }
        private void TransactionManager (Action function) {
            var transaction = _dbContext.Database.BeginTransaction();
            try{
                function();
                _dbContext.SaveChanges();
                transaction.Commit();
            }catch (Exception e) {
                transaction.Rollback();
            }
        }

        public void Add(Book book)
        {
           TransactionManager(()=>{
                _dbContext.Book.Add(book);
                
            });
            
        }

        public ICollection<Book> GetAll()
        {
             return _dbContext.Book.ToList<Book>();
        }

        public Book GetById(int id)
        {
            return GetAll().FirstOrDefault(book => book.Id == id);
        }

        public void Remove(int id)
        {
           TransactionManager(()=>{       
               var bookDelete = _dbContext.Book.Find(id);        
                _dbContext.Book.Remove(bookDelete);              
           });
        }

        public void Update(int id, Book book)
        {
            TransactionManager(()=>{
                var bookUpdate = _dbContext.Book.Find(id);
                bookUpdate.Name = book.Name;
                bookUpdate.Author = book.Author;
                bookUpdate.Description= book.Description;
                bookUpdate.CategoryId= book.CategoryId;
            });
        }

        
    }
}