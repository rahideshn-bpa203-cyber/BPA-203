using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProduct.ViewModels;
using _35_ServiceLifeTimeAppSettingProductn.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _35_ServiceLifeTimeAppSettingProduct.Controllers
{
   
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async  Task<ActionResult> Detail(int? id)
        {
            //throw new Exception();
            if (id == null || id < 1) {return BadRequest(); }


            Product?  product =await _context.Products
                .Include(p=>p.ProductImages.OrderByDescending(pi=>pi.IsPrimary))
                .Include(p=>p.Category)
                .Include(p=>p.ProductTags)
                .ThenInclude(pt=>pt.Tag)
                .FirstOrDefaultAsync(p => p.Id == id);



            if (product == null) return NotFound();

            List<Product> relatedProducts = await _context.Products.Where(rp=>rp.CategoryId==product.CategoryId && rp.Id!=product.Id).
                Include(p=>p.ProductImages.Where(pi => pi.IsPrimary!=null)).ToListAsync();



            ShopVM shopVM= new ShopVM
            {
              
                Products = product,
                RelatedProducts= relatedProducts

            }
            ;
            return View(shopVM);
        }
    }


}
