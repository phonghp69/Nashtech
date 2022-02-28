using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentEFCore2.Models;
namespace AssignmentEFCore2.Services
{
    public interface ICategoryService
    { 
        List<Category> GetCategories();
         public void Add(Category category);
        public void Update(int id, Category category);
        public void Delete(int id);
    }
}