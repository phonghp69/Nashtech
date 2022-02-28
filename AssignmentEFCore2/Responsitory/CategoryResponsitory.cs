using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentEFCore2.Models;

namespace AssignmentEFCore2.Responsitory
{
    public class CategoryResponsitory : ICategoryResponsitory
    {
        private ProductContext _productDbContext;
        public CategoryResponsitory(ProductContext dbContext)
        {
            _productDbContext = dbContext;
        }
 private void TransactionManager (Action function){
            var transaction = _productDbContext.Database.BeginTransaction();
            try{
                function();
                transaction.Commit();
            }catch(Exception e){
                transaction.Rollback();
            }
        }

        public void Add(Category category)
        {
            TransactionManager(()=>{
                _productDbContext.Categories.Add(category);
                _productDbContext.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            TransactionManager(()=>{
                var category = _productDbContext.Categories.Find(id);
                _productDbContext.Categories.Remove(category);
                _productDbContext.SaveChanges();
            });
        }

        public List<Category> GetCategories()
        {
            return _productDbContext.Categories.ToList();
        }

        public void Update(int id, Category category)
        {
            TransactionManager(()=>{
                var updatedCategory = _productDbContext.Categories.Find(id);
                
                updatedCategory.cName = category.cName;

                _productDbContext.SaveChanges();
            });
        }
    }
}