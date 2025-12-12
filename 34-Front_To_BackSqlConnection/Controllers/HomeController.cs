using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _34_Front_To_BackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _34_Front_To_BackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context) 
        { 
          _context = context;
        
        
        }

      

        public IActionResult Index()
        {

          List<Slider>sliders=_context.Sliders.OrderBy(s=>s.Order).ToList();
            //List <Slider> selectSlider =sliders.Take(2).OrderBy(s=>s.Order).ToList();


            HomeVM homeVm = new HomeVM()
            {
                Sliders = sliders,
            };


            return View(homeVm);
        }

    }
}
