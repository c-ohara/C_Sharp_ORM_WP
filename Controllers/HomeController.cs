using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private int? UserSession
        {
            get {
                return HttpContext.Session.GetInt32("UserId");
            }
            set {
                HttpContext.Session.SetInt32("UserId", (int)value);
            }
        }
        private MyContext DbContext;

        public HomeController (MyContext context)
        {
            DbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newguy)
        {
            if (ModelState.IsValid)
            {
                if (DbContext.Users.Any(u => u.Email == newguy.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newguy.Password = Hasher.HashPassword(newguy, newguy.Password);
                DbContext.Add(newguy);
                DbContext.SaveChanges();
                User CurrentUser = DbContext.Users.FirstOrDefault(u => u.Email == newguy.Email);
                UserSession = CurrentUser.UserId;
                return RedirectToAction("Index", "Dashboard");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(Login logger)
        {
            if (ModelState.IsValid)
            {
                User CurrentUser = DbContext.Users.SingleOrDefault(u => u.Email == logger.EmailAttempt);
                if (CurrentUser == null)
                {
                    ModelState.AddModelError("EmailAttempt", "Invalid Email/Password combination.");
                    return View("Index");
                }
                PasswordHasher<Login> Hasher = new PasswordHasher<Login>();
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(logger, CurrentUser.Password, logger.PasswordAttempt);
                if (result == 0) {
                    ModelState.AddModelError("EmailAttempt", "Invalid Email/Password combination.");
                    return View("Index");
                }
                UserSession = CurrentUser.UserId;
                return RedirectToAction("Index", "Dashboard");
            }
            return View("Index");
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
