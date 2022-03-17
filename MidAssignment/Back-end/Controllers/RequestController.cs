using Microsoft.AspNetCore.Mvc;
using System.Net;
using Back_end.Models;
using Back_end.Entities;
using Back_end.Services;
using AutoMapper;
namespace Back_end.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestController : Controller
{
    private readonly IService<BookBorrowingRequest> _requestService;
    private readonly IMapper _mapper;
    public RequestController(IService<BookBorrowingRequest> requestService, IMapper mapper)
    {
        _requestService = requestService;
        _mapper = mapper;
    }
    
    [HttpGet("")]
    public ActionResult<IEnumerable<BookBorrowingRequestModel>> GetRequest()
    {
        var request = _mapper.Map<List<BookBorrowingRequestModel>>(_requestService.GetAll());
        if (!ModelState.IsValid) return BadRequest(request);
        return Ok(request);
    }
    [HttpPost]
    public IActionResult PostRequest(BookBorrowingRequestModel requestmodel)
    {
        var request = _mapper.Map<BookBorrowingRequest>(requestmodel);
        if(ModelState.IsValid){
        _requestService.Add(request);
        return Ok(request);
        }
        return BadRequest(ModelState);
       
    }
    [HttpPut("")]
    public IActionResult UpdateRequest(int id,BookBorrowingRequestModel requestModel)
    {
       var request = _mapper.Map<BookBorrowingRequest>(requestModel);
       if(ModelState.IsValid){        
         _requestService.Update(id,request);
         return Ok(request);
         } 
      return BadRequest(ModelState);
    }
 [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        _requestService.Remove(id);
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok("Thanh cong");
    }

}
