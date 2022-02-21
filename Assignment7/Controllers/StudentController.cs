using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment7.Implement;
using Assignment7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment7.Controllers
{

    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IPerson _iperson;
        public StudentController(ILogger<StudentController> logger, IPerson iperson)
        {
            _logger = logger;
            _iperson = iperson;
        }



        public IActionResult Index()
        {

            return View(_iperson.List());
        }
       
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonModel person)
        {
             if(!ModelState.IsValid) return View();
            _iperson.Create(person);
           
            return RedirectToAction("Index");


        }
        public IActionResult Edit( int id)
        {
            var person = _iperson.Details(id);
        return View(person);
        }
        [HttpPost]
        public IActionResult Edit(PersonModel person)
        {
           if(!ModelState.IsValid) return View();
                _iperson.Update(person);
                
                return RedirectToAction("Index");
            

        }
        public IActionResult Details(int id){
            var detail= _iperson.Details(id);
            return View(detail);
        }
      
        // [HttpPost]
        public IActionResult DeletePerson(int id)
        {
           _iperson.Delete(id);
             return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}