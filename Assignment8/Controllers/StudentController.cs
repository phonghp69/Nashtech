using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment8.Models;
using Assignment8.Implement;
namespace Assignment8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        private readonly IPerson _iperson;
        public StudentController(ILogger<StudentController> logger, IPerson iperson)
        {
            _logger = logger;
            _iperson = iperson;

        }
        [HttpGet]
        public IEnumerable<PersonModel> GetAll()
        {
            return _iperson.GetAll();
        }

        [HttpPost]
        public PersonModel Create(PersonModel PersonModel)
        {
            var rs = new PersonModel
            {
                Id = Guid.NewGuid(),
                Title = PersonModel.Title,
                IsCompleted = PersonModel.IsCompleted,
            };
            return _iperson.Add(rs);
        }
        [HttpPut]
        public IActionResult Edit(Guid id, PersonModel PersonModel)
        {
            var rs = _iperson.GetOne(id);
            if (rs == null) return NotFound();
            rs.Title = PersonModel.Title;
            rs.IsCompleted = PersonModel.IsCompleted;
            return new JsonResult(_iperson.Update(rs));
        }
        [HttpDelete]
        public IActionResult Delete(Guid id, PersonModel PersonModel)
        {
            var rs = _iperson.GetOne(id);
            if (rs == null) return NotFound();
            _iperson.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("multiple")]
        public List<PersonModel> AddMul(List<PersonModel> models)
        {
            var rs = new List<PersonModel>();
            foreach (var model in models)
            {
                rs.Add(new PersonModel
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,
                    IsCompleted = model.IsCompleted
                });
            }
            return _iperson.Add(models);
        }
        [HttpPost]
        [Route("multiple-delete")]
        public IActionResult DelMul(List<Guid> ids)
        {
            _iperson.Delete(ids);
            return Ok();
        }

    }
}