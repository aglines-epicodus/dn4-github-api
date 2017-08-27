using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dn4GithubAPI.Models;
using Newtonsoft.Json.Linq;

namespace dn4GithubAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About page.";
            return View();
        }

        public IActionResult Projects()
        {
            JObject starredRepos = Github.GetStarredRepos();
            ViewData["Message"] = "Your projects page.";
            return View(starredRepos);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
