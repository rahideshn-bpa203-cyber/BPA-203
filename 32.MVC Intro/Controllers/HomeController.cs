using Microsoft.AspNetCore.Mvc;

namespace MVCIntro32.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var student = new JsonResult(
            //new
            //{
            //    Id = 1,
            //    Name = "Rahide",
            //    Surname = "Aliyev"
            //}
            //);
            return View();
        }
        public IActionResult Detail(int? id)
        {
            if (id is null || id < 1)
            {
                return RedirectToAction(nameof(Error));
            }
            return View();

        }
        public IActionResult Error()
        {
            return View();

        }
    }
}