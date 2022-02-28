using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssignmentEFCore2.Services;
using AssignmentEFCore2.Models;
namespace AssignmentEFCore2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
    private ICategoryService _categoryServices;
        public CategoryController(ICategoryService categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Category>> GetCategorys()
        {
            return _categoryServices.GetCategories();
        }

        [HttpPost("")]
        public IActionResult PostCategory(Category category)
        {
            _categoryServices.Add(category);
            return Ok("Thanh cong");
        }

        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            _categoryServices.Update(id, category);
            return Ok("Thanh cong");
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategoryById(int id)
        {
            _categoryServices.Delete(id);
            return Ok("Thanh cong");
        }
    }
}