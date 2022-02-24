using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssignmentEFCore1.Models;
using AssignmentEFCore1.Responsitory;
using AssignmentEFCore1.Services;
using System.Net;

namespace AssignmentEFCore1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IServices _iservices;

        public StudentController(IServices iservices)
        {
            _iservices = iservices;
        }

        [HttpGet]
        public List<Student> GetStudents()
        {
            return _iservices.GetStudents();
        }
        [HttpPost]
        public HttpStatusCode Create(Student student)
        {
            _iservices.Create(student);
            return HttpStatusCode.OK;
        }
        [HttpPut]
        public HttpStatusCode Update(Student student)
        {
            _iservices.Update(student);
            return HttpStatusCode.OK;
        }
        [HttpDelete]
        public HttpStatusCode Delete(int Id)
        {
            _iservices.Delete(Id);
            return HttpStatusCode.OK;
        }
    }
}
