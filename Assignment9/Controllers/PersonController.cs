using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment9.Services;
using Assignment9.Models;
namespace Assignment9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPerson _iperson;
        
        public PersonController(ILogger<PersonController> logger, IPerson iperson)
        {
            _logger = logger;
            _iperson = iperson;

        }
        [HttpGet]
        public List<PersonModel> GetAll(){
           
            return _iperson.GetAll();
        }

        [HttpPost]
        public void Add(PersonModel PersonModel)
        {         
             _iperson.Add(PersonModel);
            
        }
        [HttpPut]
        public void Update(int id,PersonModel person)
        {
            
            _iperson.Update(id, person);
        }
        [HttpDelete]
        public void Delete(int id)
        {
           _iperson.Delete(id);
        }
        
       [HttpPost("searchName")]
        public List<PersonModel> FilterName(string name) {
            return _iperson.FilterName(name);
        }
          
       [HttpPost("searchPlace")]
        public List<PersonModel> FilterPlace(string birthplace) {
            return _iperson.FilterPlace(birthplace);
        }
         [HttpPost("searchGender")]
        public List<PersonModel> FilterGender(Gender gender) {
            
            return _iperson.FilterGender(gender);
        }

    }
}