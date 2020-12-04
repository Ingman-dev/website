using IngmanDevelopment.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngmanDevelopment.Controllers
{
    public class CovidController : Controller
    {
        private ICovidRepository covidRepository;

        public CovidController(ICovidRepository covidRepository)
        {
            this.covidRepository = covidRepository;
        }

        [Route("")]

        public async Task<IActionResult> Index()
        {
            var countries = await covidRepository.GetCountries();
            return View(countries);
        }

        public async Task<IActionResult> Summary()
        {
            var summary = await covidRepository.GetSummary();
            return View(summary);
        }
    }
}
