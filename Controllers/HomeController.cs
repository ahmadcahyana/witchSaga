using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using witchSaga.Models;

namespace witchSaga.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SolveProblemView(List<Person> persons)
        {
            int sumKilled = 0;
            foreach (var person in persons)
            {
                if (person.YearofDeath < 1 | person.YearofDeath <= person.AgeofDeath)
                {
                    persons = null;
                    break;
                }
                else
                {
                    Witch witch = new Witch
                    {
                        Year = person.YearofDeath - person.AgeofDeath
                    };
                    person.Killed = witch.Kill();
                    sumKilled += person.Killed;
                }
                
            }
            dynamic result = new ExpandoObject();
            result.data = persons;
            if (result.data != null)
                result.average = (double)sumKilled / persons.Count;
            else
                result.average = null;
            return PartialView("_SolveProblem", result);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
