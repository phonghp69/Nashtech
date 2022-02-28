using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentEFCore2.Models;
namespace AssignmentEFCore2.Services
{
    public interface IProductService
    {
         
        List<Product> GetProducts();
        public void Add(Product product);
        public void Update(int id, Product product);
        public void Delete(int id);
    }
}