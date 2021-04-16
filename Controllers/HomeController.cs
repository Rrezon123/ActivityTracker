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

        public HomeController(ILogger<HomeController> logger, ToDoContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Route("Dashboard")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            if (loggedInUser == null)
                return RedirectToAction("Index", "SignIn");
            ViewBag.User = _context.Users.FirstOrDefault(u => u.UserId == loggedInUser.UserId);
            return View();
        }
        [HttpGet("ToDo")]
        public IActionResult ToDo()
        {
            if (loggedInUser == null)
                return RedirectToAction("Index", "SignIn");
            ViewBag.User = _context.Users.FirstOrDefault(u => u.UserId == loggedInUser.UserId);
            ViewBag.Todos = _context.ToDos;
            var ToDo = _context.ToDos.Include(u => u.UserOfTask);
            return View(ToDo.ToList());
        }
        [HttpGet("Teams")]
        public IActionResult Teams()
        {
            if (loggedInUser == null)
                return RedirectToAction("Index", "SignIn");
            ViewBag.User = _context.Users.FirstOrDefault(u => u.UserId == loggedInUser.UserId);
            return View();
        }

        [HttpGet("{todoid}")]
        public IActionResult ShowToDo(int todoid)
        {
            ViewBag.ShowToDo = _context.ToDos.FirstOrDefault(todo => todo.ToDoId == todoid);
            return RedirectToAction("ToDo");
        }
        [HttpPost("AddToDo")]
        public IActionResult AddToDo(ToDo newTodo)
        {
            ViewBag.User = _context.Users.FirstOrDefault(u => u.UserId == loggedInUser.UserId);
            if (ModelState.IsValid)
            {
                newTodo.UserId = loggedInUser.UserId;
                _context.ToDos.Add(newTodo);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("todoId", newTodo.ToDoId);
                return RedirectToAction("ToDo");
            }
            return View("AddPartial");

        }
        [HttpPost("Update/{todoid}")]
        public IActionResult UpdateToDo(int todoid)
        {
            ToDo editedToDo = _context.ToDos.FirstOrDefault(todo => todo.ToDoId == todoid);
            if (editedToDo.Status == 1)
            {
                editedToDo.Status = 2;
            }
            else
            {
                editedToDo.Status = 3;
            }

            editedToDo.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ToDo");
        }
        [HttpPost("TeamAdd")]
        public IActionResult TeamAdd(Team newTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(newTeam);
                _context.SaveChanges();
                return RedirectToAction("Teams");
            }
            return View("");
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
