using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment6.Controllers
{

    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        public static List<PersonModel> People = new List<PersonModel>()
        {
            new PersonModel
            {
                Id = 1,
                BirthPlace = "Ha Noi", DateOfBirth = new DateTime(2000, 1, 20), FirstName = "Tuan ",
                Gender = Gender.Male, LastName = "Phong", IsGraduated = true, PhoneNumber = "0111222333"
            },
            new PersonModel
            {
                Id = 2,
                BirthPlace = "HCM", DateOfBirth = new DateTime(1999, 1, 20), FirstName = "Van",
                Gender = Gender.Female, LastName = "Phuc", IsGraduated = false, PhoneNumber = "0111422333"
            },
            new PersonModel
            {
                Id = 3,
                BirthPlace = "Da Nang", DateOfBirth = new DateTime(2000, 11, 11), FirstName = "Dinh",
                Gender = Gender.Other, LastName = "Khoi", IsGraduated = true, PhoneNumber = "0111522333"
            },
        };

        public IActionResult Index()
        {
           
            return View(People);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonModel person )
        {
            if (ModelState.IsValid)
            {
                if (person.Id == 0)
                {
                    var newId = People.Max(x => x.Id);
                    person.Id = newId + 1;
                    People.Add(person);
                }
                else
                {
                    People.RemoveAll(x => x.Id == person.Id);
                    People.Add(person);
                }
            }

            return RedirectToAction("");
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult EditPerson([FromQuery] int personId)
        {
            var person = People.Find(p => p.Id == personId);
            if (person == null)
            {
                return RedirectToAction("PersonNotFound");
            }
            return View(person);
        }
        [HttpPost]
        public IActionResult SavePerson(PersonModel person)
        {
            //Add new person to list of person
            //No handle for invalid ModelState, because we have server & client side validation
            if (ModelState.IsValid)
            {
                if (person.Id == 0)
                {
                    var newId = People.Max(x => x.Id);
                   
                    People.Add(person);
                }
                else
                {
                    People.RemoveAll(x => x.Id == person.Id);
                   
                    People.Add(person);
                }
            }

            return RedirectToAction("");
        }
        public IActionResult PersonNotFound()
        {
            return View();
        }
       // [HttpPost]
        public IActionResult DeletePerson(int personId)
        {
            if(personId <=0 && personId >People.Count){
                return RedirectToAction("");
            }
            
            People.RemoveAt(personId);
            return RedirectToAction("");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}