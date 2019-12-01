using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    [Route("Dashboard")]
    public class DashboardController : Controller
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

        public DashboardController (MyContext context)
        {
            DbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if (UserSession == null) {
                return RedirectToAction("Index","Home");
            }
            List<Wedding> AllWeddings = DbContext.Weddings.Include(wedding => wedding.Reservations).ToList();
            ViewBag.UserId = UserSession;
            ViewBag.Test = 1;
            return View(AllWeddings);
        }

        [HttpGet("wedding/new")]
        public IActionResult NewWedding()
        {
            if (UserSession == null) {
                return RedirectToAction("Index","Home");
            }
            ViewBag.CurrentUser = DbContext.Users.SingleOrDefault(u => u.UserId == UserSession);
            return View();
        }

        [HttpGet("wedding/{WedId}")]
        public IActionResult Wedding(int WedId)
        {
            Wedding currWedding = DbContext.Weddings.Include(wed => wed.Reservations)
            .ThenInclude(res => res.User).SingleOrDefault(wed => wed.WeddingId == WedId);
            return View(currWedding);
        }

        [HttpGet("Reserve/{WedId}")]
        public IActionResult Reserve(int WedId)
        {
            if (UserSession == null) {
                return RedirectToAction("Index","Home");
            }
            RSVP NewReservation = new RSVP
            {
                WeddingId = WedId,
                UserId = (int)UserSession
            };
            DbContext.Add(NewReservation);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("unreserve/{WedId}")]
        public IActionResult Unreserve(int WedId)
        {
            if (UserSession == null) {
                return RedirectToAction("Index","Home");
            }
            RSVP removal = DbContext.Reservations.Where(res => res.UserId == (int)UserSession).SingleOrDefault(res => res.WeddingId == WedId);
            DbContext.Reservations.Remove(removal);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{WedId}")]
        public IActionResult RemoveWedding(int WedId)
        {
            Wedding removal = DbContext.Weddings.SingleOrDefault(wed => wed.WeddingId == WedId);
            DbContext.Weddings.Remove(removal);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //POST Requests
        [HttpPost("wedding/add")]
        public IActionResult AddWedding(Wedding NewWedding)
        {
            if (ModelState.IsValid)
            {
                DbContext.Add(NewWedding);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("NewWedding");
        }
    }
}
