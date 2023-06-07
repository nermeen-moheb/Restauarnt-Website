using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System;

namespace Project.Controllers
{
    public class MenuController : Controller
    {
        ApplicationDBcontext db;
        public MenuController(ApplicationDBcontext db)
        {
            this.db = db;
        }
        [HttpGet]
        public  IActionResult Index(string SearchString)
        {
            ViewData["currentFilter"]=SearchString;
            var items = from i in db.Menus
                        select i;
            if (!String.IsNullOrEmpty(SearchString) )
            {
                items=items.Where(i=> i.ItemName.Contains(SearchString));   
            }
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View(items);
        }
        public IActionResult Index(int id)
        {
            Menu item = db.Menus.Find(id);
            List<Menu> Menus= db.Menus.ToList();
            return View(Menus);
        }
        [HttpGet]
        public IActionResult breakfast( string SearchString)
        {
            ViewData["currentFilter"] = SearchString;
            var items = from i in db.Menus
                        select i;
            if (!String.IsNullOrEmpty(SearchString))
            {
                items = items.Where(i => i.ItemName.Contains(SearchString));
            }
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View(items);
        }
        public IActionResult breakfast(int id)
        {
            Menu item = db.Menus.Find(id);
            List<Menu> Menus = db.Menus.ToList();
            return View(Menus);
        }
        [HttpGet]
        public IActionResult lunch(string SearchString)
        {
            ViewData["currentFilter"] = SearchString;
            var items = from i in db.Menus
                        select i;
            if (!String.IsNullOrEmpty(SearchString))
            {
                items = items.Where(i => i.ItemName.Contains(SearchString));
            }
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View(items);
        }
        public IActionResult lunch(int id)
        {
            Menu item = db.Menus.Find(id);
            List<Menu> Menus = db.Menus.ToList();
            return View(Menus);
        }


    }
}
