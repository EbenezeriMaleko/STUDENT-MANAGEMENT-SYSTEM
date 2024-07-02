using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOMA.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SOMA.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string lname)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(lname))
            {
                ViewBag.Error = "Please enter both email and last name.";
                return View();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Lname == lname);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or last name.";
                return View();
            }
            
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", user.Fname);
            // Logic for successful login (e.g., setting session variables) goes here

            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Apply(UsersTable user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }

            return View(user);
        }
    }
}
