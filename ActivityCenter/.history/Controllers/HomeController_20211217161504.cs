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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

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
                return HttpContext.Session.GetInt32("UserID");
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
            return RedirectToAction("AllActividades");

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
            return RedirectToAction("AllActividades");
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("/AllActividades")]
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
                    _context.Actividades.Remove(activity);
                    _context.SaveChanges();
                }
            }
            
            List<Actividad> newActivities = _context.Actividades.OrderBy(date => date.ActivityDate).Include(c => c.ActiveUser).ThenInclude(user => user.User).ToList();
            return View("AllActividades", newActivities);
        }

        [HttpGet("/NewActivity")]
        public IActionResult CreateActivity()
        {
            return View("NewActivity");
        }

        [HttpPost("/NewActivity")]
        public IActionResult NewActivity(Actividad newActivity)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid == false)
            {
                Console.WriteLine("Fail");
                return View("NewActivity");
            }
            if (newActivity.ActivityDate < DateTime.Now)
            {
                ModelState.AddModelError("Date", "Must be in the future!");
                return View("NewActivity");
            }

            User NewActivityCreater = _context.Users.FirstOrDefault(u => u.UserID == (int)uid);
            newActivity.User = NewActivityCreater;
            _context.Add(newActivity);
            _context.SaveChanges();
            return RedirectToAction("AllActividades");
        }

        [HttpGet("/ActivityDetails/{ActividadID}")]
        public IActionResult ActivityDetails(int ActividadID)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index");
            }

            Actividad Activity = _context.Actividades.Include(a => a.ActiveUser).ThenInclude(ActiveUser => ActiveUser.User).Include(b => b.User).FirstOrDefault(w => w.UserID == ActividadID);

            if (Activity == null)
            {
                return RedirectToAction("AllActividades");
            }

            return View("ActivityDetails", Activity);

        }

        [HttpPost("/Activity/Join/{ActividadID}")]
        public IActionResult Join(int ActividadID)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index");
            }

            ActivityUser ActiveUser = db.ActiveUser
            .FirstOrDefault(r => r.UserId == (int)uid && r.ActivityId == ActivityId);

            if (ActiveUser == null)
            {
                ActivityUser activeUser = new ActivityUser()
                {
                    ActivityId = ActivityId,
                    UserId = (int)uid
                };
                db.ActiveUser.Add(activeUser);
            }
            else
            {
                db.ActiveUser.Remove(ActiveUser);
            }

            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpPost("Activity/Delete/{ActividadID}")]
        public IActionResult Delete(int ActividadID)
        {
            Actividad Activity = _context.Actividades.FirstOrDefault(w => w.ActividadID == ActividadID);

            if (Activity == null)
            {
                return RedirectToAction("AllActividades");
            }

            _context.Actividades.Remove(Activity);
            _context.SaveChanges();
            return RedirectToAction("AllActividades");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
