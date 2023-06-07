using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class PrivacyPolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
