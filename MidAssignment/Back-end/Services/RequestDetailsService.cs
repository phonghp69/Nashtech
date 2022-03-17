using Back_end.Entities;
using Back_end.Models;
using Back_end.DBContext;

namespace Back_end.Services
{
    public class RequestDetailsService : IService<BookBorrowingRequestDetails>
    {
         private readonly LibraryDbContext _dbContext;
        
         public RequestDetailsService(LibraryDbContext dbContext)
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
        public void Add(BookBorrowingRequestDetails item)
        {
          TransactionManager(()=>{
                _dbContext.RequestDetails.Add(item);
                
            });
        }

        public ICollection<BookBorrowingRequestDetails> GetAll()
        {
           return _dbContext.RequestDetails.ToList<BookBorrowingRequestDetails>();
        }

        public BookBorrowingRequestDetails GetById(int id)
        {
             return GetAll().FirstOrDefault(requestdetails=>requestdetails.Id == id);
        }

        public void Remove(int id)
        {
           TransactionManager(()=>{       
               var detailsDelete = _dbContext.Book.Find(id);        
                _dbContext.Book.Remove(detailsDelete);              
           });
        }

        public void Update(int id, BookBorrowingRequestDetails item)
        {
            throw new NotImplementedException();
        }
    }
}