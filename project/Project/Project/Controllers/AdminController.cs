using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDBcontext db;
        public AdminController(ApplicationDBcontext db)
        {
            this.db = db;
        }
        public IActionResult Index()

        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View();
        }

        public IActionResult showSurvey(int id)

        {

            List<Survey> Surveys = db.Surveys.ToList();
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View(Surveys);

        }

        public IActionResult showReservation(int id)

        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            List<Reservation> Reservations = db.Reservations
       .Include(r => r.Customer)
       .Include(r => r.Table)
       .ToList();


            return View(Reservations);

        }
        public IActionResult showProblem(int id)

        {

            List<ContactUs> inquiries = db.Inqiries.ToList();
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View(inquiries);


        }
        public IActionResult showMenu(int id)

        {

            List<Menu> menus = db.Menus.ToList();
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View(menus);

        }
        public IActionResult Delete(int id)
        {
            var entity = db.Menus.FirstOrDefault(c => c.ItemID == id);
            if (entity != null)
            {
                db.Menus.Remove(entity);
                db.SaveChanges();
                return RedirectToAction("showMenu");

            }
            return RedirectToAction("showMenu");

        }

        [HttpGet]
        public IActionResult Add()
        {

            return View(new Menu());

        }
        [HttpPost]
        public IActionResult Add(Menu item)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(item);
                db.SaveChanges();
                return Redirect("showMenu");
            }
            return View(item);
        }

        public IActionResult showOrder(int id)

        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            List<Order_Item> orders = db.Items
           .Include(r => r.Menu)
           .Include(r => r.Order.Customer)
           .Include(r => r.Order)
           .ToList();


            return View(orders);


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var m = db.Menus.Where(x => x.ItemID == id).FirstOrDefault();
            if (m == null)
            {
                return new NotFoundResult();
            }
            return View(m);
        }

        [HttpPost]
        public IActionResult Edit(Menu item)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Update(item);
                db.SaveChanges();
                return RedirectToAction("showMenu");
            }
            return View("Edit");

        }


    }
}