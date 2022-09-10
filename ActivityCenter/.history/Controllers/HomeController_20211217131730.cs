using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ActivityCenter.Models;
//ADDED
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace ActivityCenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Is taken");
                }
            }
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            _context.Users.Add(newUser);
            _context.SaveChanges();

            HttpContext.Session.SetInt32("UserID", newUser.UserID);
            HttpContext.Session.SetString("Nme", newUser.Name);
            return RedirectToAction("All");

        }

        [HttpPost("/Login")]
        public IActionResult Login(LoginUser loginUser)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            User dbUser = _context.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

            if (dbUser == null)
            {
                ModelState.AddModelError("LoginError", "Email not found.");
                return View("Index");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var pwCompareResult = hasher.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

            if (pwCompareResult == 0)
            {
                ModelState.AddModelError("LoginPassword", "Invalid Password.");
                return View("Index");
            }
            HttpContext.Session.SetInt32("UserID", dbUser.UserID);
            HttpContext.Session.SetString("Name", dbUser.Name);
            return RedirectToAction("All");
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("/All")]
        public IActionResult AllActividades()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index");
            }

            List<Actividad> allActvities = _context.Actividades.ToList();

            //BLACK BELT FEATURE
            foreach (var activity in allActvities)
            {
                if (activity.ActivityDate <= DateTime.Now)
                {
                    _context.Actividad.Remove(activity);
                    _context.SaveChanges();
                }
            }
            
            List<Actividad> newActivities = _context.Actividad.OrderBy(date => date.ActivityDate).Include(c => c.ActiveUser).ThenInclude(user => user.User).ToList();
            return View("All", newActivities);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
