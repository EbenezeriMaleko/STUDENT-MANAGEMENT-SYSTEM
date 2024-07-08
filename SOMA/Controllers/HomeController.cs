using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SOMA.Models;

namespace SOMA.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        if(HttpContext.Session.GetString("UserEmail")== null)
        {
            return RedirectToAction("Login", "User");
        }
        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
 
    public IActionResult Profile()
    {
      var UserEmail = HttpContext.Session.GetString("UserEmail");

      var user = _context.Users.FirstOrDefault(u => u.Email == UserEmail);

      if(user == null){
        _logger.LogError($"User with Email {UserEmail} not found");
        return RedirectToAction("Index");
      }

      var applicationmodel = new ApplicationTable
      {
        UserId = user.Id,
        User = user
      };
      return View(applicationmodel);
    }

    [HttpPost]
    public IActionResult Profile(ApplicationTable model)
    {
        if (ModelState.IsValid)
        {
            try{
                _context.Applications.Add(model);
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving application data:");
                ModelState.AddModelError("", "An error occured while saving data");
            }
        }

        return View(model);
    }

    public IActionResult Views_status()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
