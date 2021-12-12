using Microsoft.AspNetCore.Mvc;
using portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace portfolio.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepository Repository;
        public HomeController(IPostRepository repo)
        {
            Repository = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index",Repository.Posts.Take(5));
        }
    }
}
