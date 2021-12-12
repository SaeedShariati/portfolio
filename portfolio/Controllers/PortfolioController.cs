using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public IActionResult Resume()
        {
            string filepath = @"\files\Resume.pdf";
            return File(filepath, "application/pdf", Path.GetFileName(filepath));
        }
    }
}
