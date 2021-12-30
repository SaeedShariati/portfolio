using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text.Encodings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using portfolio.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mime;
using portfolio.Models.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace portfolio.Controllers
{
    [Authorize("Admin")]
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserApiController:ControllerBase
    {
        private readonly ApplicationIdentityDbContext IdentityDb;
        private readonly UserManager<User> userManager;
        const int pageSize = 20;

        public UserApiController(ApplicationIdentityDbContext context,UserManager<User> um)
        {
            IdentityDb = context;
            userManager = um;
        }
        [Route("")]
        public string Index()
        {
            return "Welome to the api";
        }
        [HttpGet]
        [Route("users/{page:int?}")]
        public JsonResult GetUsers(int page = 1)
        {
            if (page < 1)
                page = 1;
            List<User> users = userManager.Users.AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return new JsonResult(users);
        }
        [HttpPost]
        [Route("promote/{id?}")]
        public async Task<IActionResult> PromoteUser(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            Claim author = new Claim("Author", "Author");
            await userManager.AddClaimAsync(user, author);
            return Ok();
        }
    }
}
