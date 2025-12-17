using Microsoft.AspNetCore.Mvc;

namespace ProniaBpa203.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
