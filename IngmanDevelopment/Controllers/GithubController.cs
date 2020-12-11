using IngmanDevelopment.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngmanDevelopment.Controllers
{
    public class GithubController : Controller
    {
        //private IGithubRepository githubRepository;

        //public GithubController(IGithubRepository githubRepository)
        //{
        //    this.githubRepository = githubRepository;
        //}

        [Route("/Github")]

        public IActionResult Index()
        {
            //var repos = await githubRepository.GetRepos();
            return View();
        }
    }
}
