using Microsoft.AspNetCore.Mvc;
using System.Net;
using Back_end.Models;
using Back_end.Entities;
using Back_end.Services;
using AutoMapper;
namespace Back_end.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly IService<Category> _categoryService;
    private readonly IMapper _mapper;
    public CategoryController(IService<Category> CategoryService, IMapper mapper)
    {
        _categoryService = CategoryService;
        _mapper = mapper;
    }
    
    [HttpGet("")]
    public ActionResult<IEnumerable<CategoryModel>> GetCategory()
    {
        var category = _mapper.Map<List<CategoryModel>>(_categoryService.GetAll());
        if (!ModelState.IsValid) return BadRequest(category);
        return Ok(category);
    }
    [HttpPost]
    public IActionResult PostCategory(CategoryModel categorymodel)
    {
        var category = _mapper.Map<Category>(categorymodel);
        if(ModelState.IsValid){
        _categoryService.Add(category);
        return Ok(category);
        }
        return BadRequest(ModelState);
       
    }
    [HttpPut("")]
    public IActionResult UpdateCategory(int id,CategoryModel categoryModel)
    {
       var category = _mapper.Map<Category>(categoryModel);
       if(ModelState.IsValid){        
         _categoryService.Update(id,category);
         return Ok(category);
         } 
      return BadRequest(ModelState);
    }
 [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        _categoryService.Remove(id);
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok("Thanh cong");
    }

}
