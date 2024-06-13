// namespace v2;

// public class
// {
    
//      public IActionResult Index()
//     {
//         return View();
//     }
// }


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SOMA.Models;

namespace SOMA.Controllers;

public class  AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult View_applicant()
    {
        return View();
    }
    public IActionResult Student_status()
    {
        return View();
    }
     public IActionResult Admin_profile()
    {
        return View();
    }

   

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}


