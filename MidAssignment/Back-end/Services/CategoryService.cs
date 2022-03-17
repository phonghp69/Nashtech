using Back_end.Entities;
using Back_end.Models;
using Back_end.DBContext;

namespace Back_end.Services
{
    
    public class CategoryService : IService<Category>
    {
        private readonly LibraryDbContext _dbContext;
        public CategoryService(LibraryDbContext dbContext){
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
        public void Add(Category category)
        {
             TransactionManager(()=>{
                _dbContext.Category.Add(category);
                
            });
        }

        public ICollection<Category> GetAll()
        {
             return _dbContext.Category.ToList<Category>();
        }

        public Category GetById(int id)
        {
           return GetAll().FirstOrDefault(category => category.Id == id);
        }

        public void Remove(int id)
        {
            TransactionManager(()=>{       
               var CategoryDelete = _dbContext.Category.Find(id);        
                _dbContext.Category.Remove(CategoryDelete);              
           });
        }

        public void Update(int id, Category category)
        {
             TransactionManager(()=>{
                var categoryUpdate = _dbContext.Category.Find(id);
                categoryUpdate.Type = category.Type;
               
            });
        }
    }
}