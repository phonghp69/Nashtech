using Microsoft.AspNetCore.Mvc;
using System.Net;
using Back_end.Models;
using Back_end.Entities;
using Back_end.Services;
using AutoMapper;
namespace Back_end.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : Controller
{
    private readonly IService<Book> _bookService;
    private readonly IMapper _mapper;
    public BookController(IService<Book> bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet("")]
    public ActionResult<IEnumerable<BookModel>> GetAll()
    {
        var book = _mapper.Map<List<BookModel>>(_bookService.GetAll());
        if (!ModelState.IsValid) return BadRequest(book);
        return Ok(book);
    }
    [HttpPost]
    public IActionResult PostBook(BookModel bookModel)
    {
        var book = _mapper.Map<Book>(bookModel);

        if (ModelState.IsValid)
        {
            _bookService.Add(book);
            return Ok(book);
        }

        return BadRequest(ModelState);

    }
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, BookModel bookModel)
    {
        var book = _mapper.Map<Book>(bookModel);
        if (ModelState.IsValid)
        {
            _bookService.Update(id, book);
            return Ok(book);
        }
        return BadRequest(ModelState);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        _bookService.Remove(id);
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok("Thanh cong");
    }

}
