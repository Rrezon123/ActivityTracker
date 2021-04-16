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
namespace ActivityTracker.Controllers
{
    public class HomeController : Controller
    {
        private User loggedInUser
        {
            get { return _context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId")); }
        }
        private readonly ILogger<HomeController> _logger;

       private ToDoContext _context;

        public HomeController(ILogger<HomeController> logger,ToDoContext context)
        {
            _logger = logger;
           _context=context;
        }
        [Route("Dashboard")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            //  if (loggedInUser == null)
            //     return RedirectToAction("Index", "SignIn");

            return View();
        }
        [HttpGet("ToDo")]
        public IActionResult ToDo()
        {
            //  if (loggedInUser == null)
            //     return RedirectToAction("Index", "SignIn");
            return View();
        }
        [HttpGet("Teams")]
        public IActionResult Teams()
        {
            //  if (loggedInUser == null)
            //     return RedirectToAction("Index", "SignIn");
            return View();
        }


        [HttpPost("AddToDo")]
        public IActionResult AddToDo(ToDo newTodo){
            if(ModelState.IsValid){
                _context.ToDos.Add(newTodo);
                _context.SaveChanges();
                return RedirectToAction("ToDo");   
            }
            return View("AddPartial");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
