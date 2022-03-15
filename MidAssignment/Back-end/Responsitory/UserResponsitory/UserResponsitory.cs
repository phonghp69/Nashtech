using Back_end.Models;

namespace Back_end.Responsitory.UserResponsitory
{
    public class UserResponsitory : IUserResponsitory
    {
        private LibraryDbContext _dbContext;
         public UserResponsitory(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
         private void TransactionManager (Action function) {
            var transaction = _dbContext.Database.BeginTransaction();
            try{
                function();
                transaction.Commit();
            }catch (Exception e) {
                transaction.Rollback();
            }
        }
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList<User>();
        }

        public void Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}