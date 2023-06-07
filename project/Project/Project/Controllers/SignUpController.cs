using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Project.Controllers
{
    public class SignUpController : Controller
    {
       
        private readonly ApplicationDBcontext _dbcontext;
      //  private readonly IWebHostEnvironment _environment;
        public SignUpController(ApplicationDBcontext context)
        {
            _dbcontext = context;
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    if (HttpContext.Session.GetString("Signedin") == "1")
        //    {
        //        TempData["Signed"] = "1";
        //    }
        //    return RedirectToAction("Register");
        //}


        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["Signed"] = "1";
            }
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Register(Customer customer, IFormFile img_file)
        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["Signed"] = "1";
            }
   
            string path = "wwwroot/img/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName); 
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img_file.CopyToAsync(stream);
                    ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                }
                customer.ImageUser = img_file.FileName;
            }
            else
            {
                customer.ImageUser = "default.png"; 
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _dbcontext.Customers.Add(customer);
                    _dbcontext.SaveChanges();
                    return RedirectToAction("Login", "SignUp");
                }
                
            }
            catch (Exception ex) { ViewBag.exc = ex.Message; }

          return View(customer);

        }


        /*

              [HttpPost]
              [ValidateAntiForgeryToken]
              public IActionResult Register(Customer user)
              {
                  if (ModelState.IsValid)
                  {

                      _dbcontext.Customers.Add(user);
                      _dbcontext.SaveChanges();
                      return RedirectToAction("Login", "SignUp");
                  }

                  return View(user);
              }*/

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["Signed"] = "1";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(user model)
        {
            if (ModelState.IsValid)
            {
                var user = _dbcontext.Customers.FirstOrDefault(u => u.Email == model.Email);
                if (user != null && user.Password == model.Password)
                {
                    HttpContext.Session.SetString("Name",user.Email);
                    HttpContext.Session.SetString("Id",user.CustomerID.ToString());
                    HttpContext.Session.SetString("Signedin","1");
                    if (HttpContext.Session.GetString("Signedin") == "1")
                    {
                        TempData["Signed"] = "1";
                    }
                    if (model.Email == "tota@gmail.com" && model.Password=="123")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or password");
                    ViewBag.ErrorMessage = "Invalid email or password. Please try again.";

                }
            }
            return View(model);
        }
        

        public IActionResult Logout ()
        {
      
            HttpContext.Session.SetString("Signedin", "0");
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");
        }

    }
}
