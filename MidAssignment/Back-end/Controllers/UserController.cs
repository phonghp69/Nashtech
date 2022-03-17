using Microsoft.AspNetCore.Mvc;
using System.Net;
using Back_end.Models;
using Back_end.Entities;
using Back_end.Services;
using AutoMapper;
namespace Back_end.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IService<User> _userService;
    private readonly IMapper _mapper;
    public UserController(IService<User> userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpGet("")]
    public ActionResult<IEnumerable<UserModel>> GetUser()
    {
        var user = _mapper.Map<List<UserModel>>(_userService.GetAll());
        if (!ModelState.IsValid) return BadRequest(user);
        return Ok(user);
    }
    [HttpPost]
    public IActionResult PostUser(UserModel usermodel)
    {
        var user = _mapper.Map<User>(usermodel);
        if(ModelState.IsValid){
        _userService.Add(user);
        return Ok(user);
        }
        return BadRequest(ModelState);
       
    }
    [HttpPut("")]
    public IActionResult UpdateUser(int id,UserModel userModel)
    {
       var user = _mapper.Map<User>(userModel);
       if(ModelState.IsValid){        
         _userService.Update(id,user);
         return Ok(user);
         } 
      return BadRequest(ModelState);
    }


}
