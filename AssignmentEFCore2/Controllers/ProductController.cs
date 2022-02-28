using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssignmentEFCore2.Services;
using AssignmentEFCore2.Models;
using System.Net;
namespace AssignmentEFCore2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
      private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Product>> GetTModels()
        {
            return _productService.GetProducts();
        }

        [HttpPost]
        public HttpStatusCode PostTModel(Product product)
        {
            _productService.Add(product);
            return HttpStatusCode.OK;
        }

        [HttpPut("{id}")]
        public IActionResult PutTModel(int id, Product product)
        {
            _productService.Update(id, product);
            return Ok("Thanh cong");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTModelById(int id)
        {
            _productService.Delete(id);
            return Ok("Thanh cong");
        }
    }
}
   