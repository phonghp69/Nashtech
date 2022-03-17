using Back_end.Entities;
using Back_end.Models;
using Back_end.DBContext;

namespace Back_end.Services
{
    public class RequestService : IService<BookBorrowingRequest>
    {
         private readonly LibraryDbContext _dbContext;
        
         public RequestService(LibraryDbContext dbContext)
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
        public void Add(BookBorrowingRequest item)
        {
          TransactionManager(()=>{
                _dbContext.Request.Add(item);
                
            });
            
        }

        public ICollection<BookBorrowingRequest> GetAll()
        {
             return _dbContext.Request.ToList<BookBorrowingRequest>();
        }

        public BookBorrowingRequest GetById(int id)
        {
            return GetAll().FirstOrDefault(request => request.Id == id);
        }

        public void Remove(int id)
        {
           TransactionManager(()=>{       
               var requestDelete = _dbContext.Book.Find(id);        
                _dbContext.Book.Remove(requestDelete);              
           });
        }

        public void Update(int id, BookBorrowingRequest item)
        {
            throw new NotImplementedException();
        }
    }
}