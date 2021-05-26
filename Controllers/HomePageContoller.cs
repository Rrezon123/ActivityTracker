using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ActivityTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace ActivityTracker.Controllers
{
    public class HomePageController : Controller
    {
        private User loggedInUser
        {
            get { return _context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId")); }
        }
        private readonly ILogger<HomePageController> _logger;

        private ToDoContext _context;

        public HomePageController(ILogger<HomePageController> logger, ToDoContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Route("")]
        [HttpGet("HomePage")]
        public IActionResult HomePage(){
            return View();
        }
    }
}