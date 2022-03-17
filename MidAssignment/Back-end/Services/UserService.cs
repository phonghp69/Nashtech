using Back_end.Entities;
using Back_end.Models;
using Back_end.DBContext;

namespace Back_end.Services
{
    public class UserService : IService<User>
    {
        private readonly LibraryDbContext _dbContext;
        
         public UserService(LibraryDbContext dbContext)
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
        public void Add(User user)
        {
            TransactionManager(()=>{
                _dbContext.User.Add(user);
               
            });
        }

       

        public ICollection<User> GetAll()
        {
           return _dbContext.User.ToList<User>();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, User user)
        {
           TransactionManager(()=>{
                var userUpdate = _dbContext.User.Find(id);
                
                userUpdate.Username = user.Username;
                userUpdate.Gender = user.Gender;
                userUpdate.Password = user.Password;
                userUpdate.Phone= user.Phone;
                userUpdate.Address= user.Address;
              //  userUpdate.DateOfBirth= user.DateOfBirth;
               
            });
        }
    }
}