using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
namespace Project.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ApplicationDBcontext dbcontext;
        public ReservationController (ApplicationDBcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult ReservationForm()
        {

            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Login", "SignUp");
            }
            var list = dbcontext.Tables.ToList();

            ViewBag.Tables = list;
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }

            return View(new Reservation());
            }
        [HttpPost]
        public async Task<IActionResult> ReservationForm(Reservation reserve)
        {
            var list = dbcontext.Tables.ToList();

            ViewBag.Tables = list;

            var table  = dbcontext.Tables.Where(t => t.TableID==reserve.TableID).FirstOrDefault();

            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            if (ModelState.IsValid)
                {
          
                    if (table?.IsAvailable == true)
                    {
                reserve.CustomerID = int.Parse(HttpContext.Session.GetString("Id"));
                dbcontext.Reservations.Add(reserve);
                  
                         table.IsAvailable = false;
                          dbcontext.SaveChanges();
                 //   ViewBag.confitmation = "We have confirmed your reservation";
                     return RedirectToAction("Confirmation");

                    //await Task.Delay(TimeSpan.FromHours(24)).ContinueWith(_ =>
                    //{
                    //    foreach (var t in dbcontext.Tables)
                    //    {
                    //        table.IsAvailable = true;
                    //    }
                    //    dbcontext.SaveChanges();
                    //    return RedirectToAction("index", "Home");
                    //});


                }
                else
                    {
                    ModelState.AddModelError("", "This table already reserved");
                    ViewBag.ErrorMessage = "This table already reserved";
                    return View(reserve);
                    }

              }
                return View(reserve);
            
        }


        public async Task<IActionResult> Confirmation()
        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }

       
            return View("Confirmation");
        }
    }
}
