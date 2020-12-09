using IngmanDevelopment.Data;
using IngmanDevelopment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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

        [Route("/Covid")]

        public async Task<IActionResult> Index()
        {
            var viewModel = await covidRepository.GetSummaryViewModel();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index(SummaryViewModel model)
        {
            var viewModel = await covidRepository.GetSummaryViewModel(model.SelectedCountry);
            return View(viewModel);
        }

        public async Task<IActionResult> Summary()
        {
            var summary = await covidRepository.GetSummary();
            return View(summary);
        }
    }
}
