using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Activity_Center.Models;
//using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Activity_Center.Controllers
{
    [Route("")]
    public class SignInController : Controller
    {
        private readonly ILogger<SignInController> _logger;
       // private ActContext _context;

        public SignInController(ILogger<SignInController> logger)
        {
            _logger = logger;
           // _context=context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        // [HttpPost("Register")]
        // public IActionResult Register(User newUser)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         if(_context.Users.Any(o => o.Email == newUser.Email))
        //         {
        //             ModelState.AddModelError("Email", "Email already in use");
        //             return View("Index");
        //         }
        //          if(newUser.Password!=newUser.ConfirmPassword)
        //         {
        //             ModelState.AddModelError("ConfirmPassword", "Confirm password not the same");
        //             return View("Index");
        //         }

        //         PasswordHasher<User> hasher = new PasswordHasher<User>();
        //         newUser.Password = hasher.HashPassword(newUser, newUser.Password);

        //         var newUserr = _context.Users.Add(newUser).Entity;
        //         _context.SaveChanges();

        //         HttpContext.Session.SetInt32("userId", newUserr.UserId);

        //         return RedirectToAction("Index","Home");
        //     }
            
        //     return View("Index");

        // }
        // [HttpPost("Login")]
        // public IActionResult Login(LoginUser check)
        // {
        //     if (ModelState.IsValid)
        //     {

        //         User checkUser = _context.Users.FirstOrDefault(user => user.Email == check.EmailLogin);
        //         if (checkUser == null)
        //         {
        //             ModelState.AddModelError("EmailLogin", "Invalid Email/Password");
        //             return View("Index", checkUser);
        //         }
        //         PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
        //         var res = Hasher.VerifyHashedPassword(check, checkUser.Password, check.PasswordLogin);
        //         if (res == PasswordVerificationResult.Failed)
        //         {
        //             ModelState.AddModelError("PasswordLogin", "InvalidPassword");
        //             return View("Index");
        //         }
        //         HttpContext.Session.SetInt32("userId", checkUser.UserId);
        //         return RedirectToAction("Index", "Home");
        //     }

        //     return View("Index");
        // }
        // public IActionResult Logout()
        // {
        //     HttpContext.Session.Clear();
        //     return RedirectToAction("Index");
        // }
    }
}