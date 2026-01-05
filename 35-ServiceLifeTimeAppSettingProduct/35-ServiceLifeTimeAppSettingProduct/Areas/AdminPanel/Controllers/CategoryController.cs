using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProductn.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
           
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.
                Include(c=>c.Products).
                Where(c=>c.IsDeleted==false).
                ToListAsync();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            //if (category.Name == null) 
            //{ 
            //    return View();
            //}
            if (!ModelState.IsValid) 
            {
                return View();
            }
            //Category category1=await _context.Categories.FirstOrDefaultAsync(c=>c.Name.ToLower()==category.Name.Trim());
         bool exsistCategory=await _context.Categories.
                AnyAsync(c=>c.Name.Trim()==category.Name.Trim());



            if (exsistCategory)
            {
                ModelState.AddModelError("Name", "Category already exists");
                return View();
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Category existCategory=await _context.Categories.FirstOrDefaultAsync(c=>c.Id==id);

            if (existCategory is null) return NotFound();

            return View(existCategory);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id ,Category category) 
        {
            if (id is null || id < 1) return BadRequest();

            Category existCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (existCategory is null) return NotFound();

            if (!ModelState.IsValid) { return View(); }

            bool isExistCategory=await _context.Categories.AnyAsync(c=>c.Name.Trim()==category.Name.Trim() && c.Id!=id);


            if (isExistCategory) 
            {
                ModelState.AddModelError(nameof(category.Name), "Category already exist!");
            }
                existCategory.Name = category.Name;

            //_context.Categories.Update(existCategory);
            await _context.SaveChangesAsync();




                return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id is null || id < 1) return BadRequest();

            Category existCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            //if (existCategory is null) return NotFound();

            //if (existCategory.IsDeleted == false)
            //{
            //    existCategory.IsDeleted = true;
            //}
            //else
            //{
            //    existCategory.IsDeleted = false;
            //}
               

            //_context.Categories.Update(existCategory);
           
            //_context.Categories.Remove(existCategory);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        }
}
