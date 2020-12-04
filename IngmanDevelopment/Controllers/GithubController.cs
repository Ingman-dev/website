using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngmanDevelopment.Controllers
{
    public class GithubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
