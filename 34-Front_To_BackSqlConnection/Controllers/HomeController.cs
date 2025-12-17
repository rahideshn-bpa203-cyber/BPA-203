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
        //List<Cards> card = new List<Cards>
        //{
        //    new Cards{
        //        Id = 1,
        //        IconUrl = "card.png", 
        //        //Title = "Free Shipping",
        //        //Description = "Capped at $319 per order",
        //        //Created = DateTime.Now, 
        //        //IsDeleted = false,
        //        //Order = 1,  
        //    },
        //     new Cards {
        //         Id= 2,
        //         IconUrl = "card.png",
        //         //Title = "Safe Payment", 
        //         //Description = "With our payment gateway", 
        //         //Created = DateTime.Now,
        //         //IsDeleted = false ,
        //         //Order = 2
        //     },
        //     new Cards {
        //         Id= 3,
        //         IconUrl = "service.png",
        //        // Title = "Best Services", 
        //        // Description = "Friendly & Super Services",
        //        //Created = DateTime.Now,
        //        // IsDeleted = false,
        //        //   Order = 3
        //     }
        //};
        //private Cards cards;

        public IActionResult Index()
        {

          List<Slider>sliders=_context.Sliders.OrderBy(s=>s.Order).ToList();
            //List <Slider> selectSlider =sliders.Take(2).OrderBy(s=>s.Order).ToList();
            //List<Cards> card = _context.Cards.OrderBy(c => c.Order).ToList();

            HomeVM homeVm = new HomeVM()
            {
                //Cards = cards,
                Sliders = sliders,
            };


            return View(homeVm);
        }

    }
}
