using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.Controllers
{
    public class PortfolioController:Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
