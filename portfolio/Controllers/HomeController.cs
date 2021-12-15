using Microsoft.AspNetCore.Mvc;
using portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using portfolio.Infrastructure.Filters;

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
        public IActionResult Post(int postId)
        {
            Post post = Repository.Posts.Include(p=>p.Comments).FirstOrDefault(p => p.Id == postId);
            if (post == null)
                return NotFound();
            return View(post);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
