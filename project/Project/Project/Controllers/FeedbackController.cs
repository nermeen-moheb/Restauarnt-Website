using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class FeedbackController : Controller
    {
       private readonly ApplicationDBcontext dbcontext;
        public FeedbackController(ApplicationDBcontext context)
        {
            dbcontext = context;
        }




        [HttpGet]
     
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View(new Survey());
        }

        [HttpPost]
        public IActionResult Index(Survey feedback )
        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            if (ModelState.IsValid)
            {

                var user = dbcontext.Customers.Where(u => u.Email == feedback.Email).FirstOrDefault();
                string customerIdString = HttpContext.Session.GetString("Id");
                if (!string.IsNullOrEmpty(customerIdString))
                {
                    feedback.CustomerID = int.Parse(customerIdString);
                    dbcontext.Surveys.Add(feedback);
                    dbcontext.SaveChanges();
                    return RedirectToAction("FeedbackConfirmation");
                }
                else
                {
                    return View(feedback);
                }
            }
            return View(feedback);
        }


        public IActionResult FeedbackConfirmation()
        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View("FeedbackConfirmation");
        }
    }
  
}
