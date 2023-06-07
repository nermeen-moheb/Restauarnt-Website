using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
namespace Project.Controllers
      
{
    public class CartController : Controller
    {
        ApplicationDBcontext db;
        public CartController(ApplicationDBcontext db)
        {
            this.db = db;
        }
        public IActionResult AddToCart([FromQuery] int itemId)
        {
           

            if (HttpContext.Session.GetString("Id") == null)

            {
                return RedirectToAction("Login", "SignUp");
            }
            var CustomerID = int.Parse(HttpContext.Session.GetString("Id"));
            var tst = new Cart();
           tst =  db.CartItems.FirstOrDefault(u => u.ItemId == itemId);

            if (tst == null)
            {
                var cartItem = new Cart();
                cartItem.CustomerID = CustomerID;
                cartItem.ItemId = itemId;
                cartItem.quantity = 1;
                db.CartItems.Add(cartItem);
                db.SaveChanges();
            }
            
            return RedirectToAction("showCart");

        }
        public IActionResult showCart() {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Login", "SignUp");
            }
            var CustomerID = int.Parse(HttpContext.Session.GetString("Id"));
         var items =  db.CartItems.Include(c=>c.Item).Where(c => c.CustomerID == CustomerID).ToList();
            if (HttpContext.Session.GetString("Signedin") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View(items);

        }
         
        public IActionResult PlusCartItem(int cartItemId)
        {
      
            var cartItem = db.CartItems.Find(cartItemId);


            if (cartItem != null)
            {
                
                cartItem.quantity++;
                db.SaveChanges();
             

            }

          return RedirectToAction("showCart");
        }


        public IActionResult MinusCartItem(int cartItemId)
        {
      
            var cartItem = db.CartItems.Find(cartItemId);
       

            if (cartItem != null)
            {

                cartItem.quantity--;
                db.SaveChanges();


            }
            return RedirectToAction("showCart");
        }

        public IActionResult DeleteCartItem(int cartItemId)
        {
            var cartItem = db.CartItems.Find(cartItemId);
        
            if (cartItem != null)
            {
                db.CartItems.Remove(cartItem);
                db.SaveChanges();

            }

            return RedirectToAction("showCart");
        }

      
        public IActionResult Order()
        {
            var orderitem = new Order();
            var CustomerID = int.Parse(HttpContext.Session.GetString("Id"));
            orderitem.CustomerID = CustomerID;
            decimal Tprice = 0;

            foreach (var itemm  in db.CartItems.Include(c => c.Item).Where(c => c.CustomerID == CustomerID).ToList()) { 
              
                Tprice += itemm.quantity* itemm.Item.ItemPrice;

            }
            orderitem.Total_price = Tprice;
            db.Orders.Add(orderitem);
            db.SaveChanges();
           
            foreach (var itemm in db.CartItems.Include(c => c.Item).Where(c => c.CustomerID == CustomerID).ToList())
            {
                var itemOrderr = new Order_Item();
                itemOrderr.OrderID = orderitem.OrderID;
                itemOrderr.ItemID = itemm.ItemId;
                itemOrderr.ItemName = itemm.Item.ItemName;
                itemOrderr.Quantity = itemm.quantity;
                db.Items.Add(itemOrderr);
                db.CartItems.Remove(itemm);

            }
            
            db.SaveChanges();
       
            return RedirectToAction("index","Home");
        }
    }
    
    }
