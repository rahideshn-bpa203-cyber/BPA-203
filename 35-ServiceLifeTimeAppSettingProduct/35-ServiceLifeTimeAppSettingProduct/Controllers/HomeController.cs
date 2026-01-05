using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProductn.DAL;
using _35_ServiceLifeTimeAppSettingProductn.Models;
using _35_ServiceLifeTimeAppSettingProductn.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace _35_ServiceLifeTimeAppSettingProductn.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;


        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        //List<ServiceCard> serviceCards = new List<ServiceCard>
        //{
        //    new ServiceCard{
        //        Id = 1,
        //        IconUrl = "car.png",
        //Title = "Free Shipping",
        //Description = "Capped at $319 per order",
        //Created = DateTime.Now,
        //IsDeleted = false,
        //Order = 1,
        //},
        // new ServiceCard {
        //     Id= 2,
        //     IconUrl = "card.png",
        //Title = "Safe Payment",
        //Description = "With our payment gateway",
        //Created = DateTime.Now,
        //IsDeleted = false ,
        //Order = 2
        //},
        //new ServiceCard {
        //    Id= 3,
        //    IconUrl = "service.png",
        // Title = "Best Services",
        // Description = "Friendly & Super Services",
        //Created = DateTime.Now,
        // IsDeleted = false,
        //   Order = 3
        //     }
        //};


        //List<Slider> sliders = new List<Slider>
        //{
        //    new Slider{
        //        Id=1,
        //        Title="basliq 1",
        //        SubTitle="komekci basliq 1",
        //        Description="guller 1",
        //        ImageURL="1-1-524x617.png",
        //        Created=DateTime.Now,
        //        IsDeleted=false,
        //        Order=1
        //    },
        //new Slider{
        //        Id=2,
        //        Title="basliq 2",
        //        SubTitle="komekci basliq 2",
        //        Description="guller 2",
        //        ImageURL="1-2-524x617.png",
        //        Created=DateTime.Now,
        //        IsDeleted=false,
        //        Order=2 },
        //new Slider{
        //        Id=3,
        //        Title="basliq 3",
        //        SubTitle="komekci basliq 3",
        //        Description="guller eynisi 3",
        //        ImageURL="1-1-524x617.png",
        //        Created=DateTime.Now,
        //        IsDeleted=false,
        //        Order=3 }
        //};
        public async Task<IActionResult> Index()
        {
            //_context.Sliders.AddRange(sliders);
            //_context.SaveChanges();
            List<Slider> sliders = await _context.Sliders.OrderBy(s => s.Order).ToListAsync();
            List<Client> clients=await _context.Clients.OrderBy(s => s.Order).ToListAsync();
            List<ServiceCard> servicecards = await _context.ServiceCards.OrderBy(s => s.Order).ToListAsync();
            List<Product> products=await _context.Products.Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary!=null)).ToListAsync();
            
          _context.Clients.AddRange(clients);
            _context.ServiceCards.AddRange(servicecards);
            _context.Products.AddRange(products);
            _context.Sliders.AddRange(sliders);
            



            HomeVM homevm = new HomeVM
            {
                ServiceCards = servicecards,
                Clients= clients,
                Sliders = sliders,
                Products= products
            };


            return View(homevm);
        }
    }
}
