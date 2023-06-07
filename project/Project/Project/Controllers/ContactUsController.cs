using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
namespace Project.Controllers
{
	public class ContactUsController : Controller
	{
        private readonly ApplicationDBcontext dbcontext;
        public ContactUsController(ApplicationDBcontext context)
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
            return View(new ContactUs());
		}

        [HttpPost]
        public IActionResult Index(ContactUs inquiry)
        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            if (ModelState.IsValid)
            {
                var user = dbcontext.Customers.Where(u => u.Email == inquiry.Email).FirstOrDefault();
                string customerIdString = HttpContext.Session.GetString("Id");
                if (!string.IsNullOrEmpty(customerIdString))
                {
                    inquiry.CustomerID = int.Parse(customerIdString);
                    dbcontext.Inqiries.Add(inquiry);
                    dbcontext.SaveChanges();
                    return RedirectToAction("ContactConfirmation");
                }
                else
                {
                    return View(inquiry);
                }


            }
            return View(inquiry);
        }

        public IActionResult ContactConfirmation()
        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View("ContactConfirmation");
        }
    }
}
