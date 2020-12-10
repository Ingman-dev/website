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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var viewModel = await covidRepository.GetSummaryViewModel();
            watch.Stop();
            var time = watch.ElapsedMilliseconds;
            return View(viewModel);
        }

        [HttpGet("covid/index")]
        public async Task<IActionResult> Index(SummaryViewModel model)
        {
            ModelState.Clear();
            var viewModel = await covidRepository.GetSummaryViewModel(model.SelectedCountry);
            viewModel.SelectedCountry = model.SelectedCountry;
            return View("Index", viewModel);
        }

        public async Task<IActionResult> Summary()
        {
            var summary = await covidRepository.GetSummary();
            return View(summary);
        }
    }
}
