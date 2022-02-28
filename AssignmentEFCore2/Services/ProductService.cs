using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentEFCore2.Models;
using AssignmentEFCore2.Responsitory;
namespace AssignmentEFCore2.Services
{
    public class ProductService : IProductService
    {private IProductResponsitory _productsResponsitory;

        public ProductService(IProductResponsitory productsResponsitory)
        {
            _productsResponsitory = productsResponsitory;
        }

        public void Add(Product product)
        {
            _productsResponsitory.Add(product);
        }

        public void Delete(int id)
        {
            _productsResponsitory.Delete(id);
        }

        public List<Product> GetProducts()
        {
            return _productsResponsitory.GetProducts();
        }

        public void Update(int id, Product product)
        {
            _productsResponsitory.Update(id, product);
        }
    }
}