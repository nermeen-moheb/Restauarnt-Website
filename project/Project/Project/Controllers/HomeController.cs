using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBcontext _dbcontext;
      //  private readonly ILogger<HomeController> _logger;
        public HomeController(ApplicationDBcontext context)
        {
            _dbcontext = context;
        }

        /*   public HomeController(ILogger<HomeController> logger)
           {
               _logger = logger;
           }*/

       /* public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View();
        }*/

        public IActionResult Index()
        {
            var customerEmail = HttpContext.Session.GetString("Name");
            var customer = _dbcontext.Customers.Where(s => s.Email == customerEmail).FirstOrDefault();
            if (customer != null)
            {
                TempData["img"] = customer.ImageUser;
                TempData["Name"] = customer.UserName;
            }
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View();
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