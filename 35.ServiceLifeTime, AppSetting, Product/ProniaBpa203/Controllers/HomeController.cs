using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBpa203.DAL;
using ProniaBpa203.Models;
using ProniaBpa203.ViewModels;



namespace ProniaBpa203.Controllers
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

            List<Slider> sliders = _context.Sliders.OrderBy(s => s.Order).ToList();
            List<Product>products=_context.Products.Include(p=>p.ProductImages).ToList();
            //List <Slider> selectSlider =sliders.Take(2).OrderBy(s=>s.Order).ToList();
            //Product product=_context.Products.Include(p=>p.Category).FirstOrDefault();

            //Category category=_context.Categories.FirstOrDefault(c=>c.Id==product.Id);

            HomeVM homeVm = new HomeVM()
            {
                Sliders = sliders,
                Products = products,

            };


            return View(homeVm);
        }

    }
}
