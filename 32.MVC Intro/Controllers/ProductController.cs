using Microsoft.AspNetCore.Mvc;

namespace MVCIntro32.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}