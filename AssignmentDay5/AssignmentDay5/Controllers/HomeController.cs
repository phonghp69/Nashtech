using AssignmentDay5.Models;
using AssignmentDay5.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDay5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly IListMem _list;
        private readonly List<Person> _people;

        public HomeController(ILogger<HomeController> logger, IListMem listz)
        {
            _logger = logger;
            _list = listz;
            _people = _list.CreatePeople();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MembersByGender()
        {
            var malePeople = _list.GetPeopleByGender(_people, Gender.Male);
            return View(malePeople);
        }
        public IActionResult ListFullName()
        {
            var lst = _list.GetPeopleFullName(_people);
            return View(lst);
        }

        public IActionResult OldestPeople()
        {
            var get_member_oldest = (from Person in _people orderby Person.DateOfBirth ascending select Person).FirstOrDefault();


            Console.WriteLine(get_member_oldest.Show());
            

            return View(get_member_oldest);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
