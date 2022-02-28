using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentEFCore2.Models;

namespace AssignmentEFCore2.Responsitory
{
    public class ProductResponsitory : IProductResponsitory
    {
        private ProductContext _productDbContext; 
        public ProductResponsitory(ProductContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
         private void TransactionManager (Action function) {
            var transaction = _productDbContext.Database.BeginTransaction();
            try{
                function();
                transaction.Commit();
            }catch (Exception e) {
                transaction.Rollback();
            }
        }
        public void Add(Product product)
        {
            TransactionManager(()=>{
                _productDbContext.Products.Add(product);
                _productDbContext.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            TransactionManager(()=>{
                var product = _productDbContext.Products.Find(id);
                _productDbContext.Products.Remove(product);
                _productDbContext.SaveChanges();
            });
        }

        public List<Product> GetProducts()
        {
            return _productDbContext.Products.ToList<Product>();
        }

        public void Update(int id, Product product)
        {
            TransactionManager(()=>{
                var updatedProduct = _productDbContext.Products.Find(id);
                
                updatedProduct.pName = product.pName;
                updatedProduct.Category = product.Category;
                updatedProduct.Manufacture = product.Manufacture;

                _productDbContext.SaveChanges();
            });
        }
    }
}