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
            ViewBag.ToDos = _context.ToDos.Where(t => t.UserId == loggedInUser.UserId && t.Status == 1).ToList();
            return View();
        }

        public ActionResult StatsData()
        {

            var data = _context.ToDos.Include(u => u.UserOfTask)
            .Where(u => u.UserId == loggedInUser.UserId)
            .GroupBy(d => new { d.CreatedAt.Date, d.Status})
            .Select(g => new { name = g.Key, count = g.Count() ,status=g.Key}).ToList();

            return Json(data, new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpGet("ToDo")]
        public IActionResult ToDo()
        {
            if (loggedInUser == null)
                return RedirectToAction("Index", "SignIn");
            ViewBag.User = _context.Users.FirstOrDefault(u => u.UserId == loggedInUser.UserId);
            ViewBag.Todos = _context.ToDos;
            var ToDos = _context.ToDos.Include(u => u.UserOfTask).ToList();
            var model = new ViewModelToDo();
            model.ListOfToDos = ToDos;
            model.ToDo = new ToDo();

            return View(model);
        }
        [HttpGet("Teams")]
        public IActionResult Teams()
        {
            if (loggedInUser == null)
                return RedirectToAction("Index", "SignIn");
            ViewBag.User = _context.Users.FirstOrDefault(u => u.UserId == loggedInUser.UserId);
            List<Team> Teams = _context.Teams.ToList();
            var model = new ViewModelTeam();
            model.ListOfTeams = Teams;
            model.Team = new Team();
            return View(model);
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
        [HttpGet("UpdateToDo/{todoid}")]
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
        [HttpGet("UpdateBackToDo/{todoid}")]
        public IActionResult UpdateBackToDo(int todoid)
        {
            ToDo editedToDo = _context.ToDos.FirstOrDefault(todo => todo.ToDoId == todoid);
            if (editedToDo.Status == 3)
            {
                editedToDo.Status = 2;
            }
            else
            {
                editedToDo.Status = 1;
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
                newTeam.UserId = loggedInUser.UserId;
                _context.Teams.Add(newTeam);
                _context.SaveChanges();
                return RedirectToAction("Teams");
            }
            return View("");
        }
        [HttpGet("Join/{teamId}/{status}")]
        public IActionResult Join(int teamId, string status)
        {
            if (loggedInUser == null)
                return RedirectToAction("Index", "SignIn");

            if (!_context.Teams.Any(w => w.TeamId == teamId))
                return RedirectToAction("Index");

            if (status == "add")
                JoinTeam(teamId);
            else
                LeaveTeam(teamId);

            return RedirectToAction("Index");
        }
        private void JoinTeam(int teamId)
        {
            User currUser = _context.Users.FirstOrDefault(u => u.UserId == loggedInUser.UserId);

            Team getTeam = _context.Teams.FirstOrDefault(w => w.TeamId == teamId);
            currUser.CurrentTeam = getTeam;
            getTeam.AllUsers.Add(currUser);

        }
        private void LeaveTeam(int teamId)
        {
            Team leave = _context.Teams.FirstOrDefault(w => w.TeamId == teamId);

            User currUser = _context.Users.FirstOrDefault(u => u.UserId == loggedInUser.UserId);
            if (leave.AllUsers.Any(u => u.UserId == loggedInUser.UserId))
            {
                leave.AllUsers.Remove(currUser);
            }

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
