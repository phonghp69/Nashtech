using Microsoft.AspNetCore.Mvc;
using System.Net;
using Back_end.Models;
using Back_end.Entities;
using Back_end.Services;
using AutoMapper;
namespace Back_end.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestDetailsController : Controller
{
    private readonly IService<BookBorrowingRequestDetails> _detailsService;
    private readonly IMapper _mapper;
    public RequestDetailsController(IService<BookBorrowingRequestDetails> detailsService, IMapper mapper)
    {
        _detailsService = detailsService;
        _mapper = mapper;
    }

    [HttpGet("")]
    public ActionResult<IEnumerable<BookBorrowingRequestDetailsModel>> GetDetails()
    {
        var details = _mapper.Map<List<BookBorrowingRequestDetailsModel>>(_detailsService.GetAll());
        if (!ModelState.IsValid) return BadRequest(details);
        return Ok(details);
    }
    [HttpPost]
    public IActionResult PostDetails(BookBorrowingRequestDetailsModel detailsmodel)
    {
        var details = _mapper.Map<BookBorrowingRequestDetails>(detailsmodel);
        if (ModelState.IsValid)
        {
            _detailsService.Add(details);
            return Ok(details);
        }
        return BadRequest(ModelState);

    }
    [HttpPut("")]
    public IActionResult UpdateDetails(int id, BookBorrowingRequestDetailsModel detailsModel)
    {
        var details = _mapper.Map<BookBorrowingRequestDetails>(detailsModel);
        if (ModelState.IsValid)
        {
            _detailsService.Update(id, details);
            return Ok(details);
        }
        return BadRequest(ModelState);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        _detailsService.Remove(id);
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok("Thanh cong");
    }

}
