using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentEFCore2.Models;
using AssignmentEFCore2.Responsitory;
namespace AssignmentEFCore2.Services
{
    public class CategoryService : ICategoryService
    { private ICategoryResponsitory _categoriesRepository;

        public CategoryService(ICategoryResponsitory categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public void Add(Category category)
        {
            _categoriesRepository.Add(category);
        }

        public void Delete(int id)
        {
            _categoriesRepository.Delete(id);
        }

        public List<Category> GetCategories()
        {
            return _categoriesRepository.GetCategories();
        }

        public void Update(int id, Category category)
        {
            _categoriesRepository.Update(id, category);
        }
    }
}