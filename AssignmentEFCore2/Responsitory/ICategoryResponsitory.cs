using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentEFCore2.Models;
namespace AssignmentEFCore2.Responsitory
{
    public interface ICategoryResponsitory
    {
          public List<Category> GetCategories();
        public void Add(Category product);
        public void Update(int id, Category product);
        public void Delete(int id);
    }
}