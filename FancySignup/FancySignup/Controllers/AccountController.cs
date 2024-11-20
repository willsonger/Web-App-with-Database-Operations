using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FancySignup.Models;
using FancySignup.Data;
using System.Linq;

namespace FancySignup.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Signup GET Action
        [HttpGet]
        public IActionResult Signup()
        {
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");
            return View(new UserSignupModel());
        }

        // Signup POST Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(UserSignupModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_context.Users.Any(u => u.Email == model.Email))
                    {
                        ModelState.AddModelError("Email", "This email is already registered.");
                        ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");
                        return View(model);
                    }

                    if (model.CountryId <= 0)
                    {
                        ModelState.AddModelError("CountryId", "Please select a valid country.");
                        ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");
                        return View(model);
                    }

                    // Map UserSignupModel to Users entity
                    var user = new Users
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        CountryId = model.CountryId,
                        Password = model.Password
                    };

                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("SignupSuccess");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while processing your request.");
                    Console.WriteLine($"Error during signup: {ex.Message}");
                }
            }

            ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");
            return View(model);
        }

        // Signup Success GET Action
        [HttpGet]
        public IActionResult SignupSuccess()
        {
            return View();
        }

        // Login GET Action
        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }

        // Login POST Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    return RedirectToAction("LoginSuccess");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }

        // Login Success GET Action
        [HttpGet]
        public IActionResult LoginSuccess()
        {
            return View();
        }
    }
}