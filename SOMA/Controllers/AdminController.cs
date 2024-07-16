using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SOMA.Models;
using System.Linq;

namespace SOMA.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _context;

        public AdminController(ILogger<AdminController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult View_applicant()
        {
            var applicants = _context.Applications.Include(a => a.User).ToList();
            return View(applicants);
        }

        public IActionResult Student_status()
        {
            return View();
        }

        public IActionResult Admin_profile()
        {
            return View();
        }

        public IActionResult Approve(int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.Id == id);
            if (application != null)
            {
                application.Status = "Approved";
                _context.SaveChanges();
            }
            return RedirectToAction("View_applicant");
        }

        public IActionResult Disapprove(int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.Id == id);
            if (application != null)
            {
                application.Status = "Disapproved";
                _context.SaveChanges();
            }
            return RedirectToAction("View_applicant");
        }
    }
}


