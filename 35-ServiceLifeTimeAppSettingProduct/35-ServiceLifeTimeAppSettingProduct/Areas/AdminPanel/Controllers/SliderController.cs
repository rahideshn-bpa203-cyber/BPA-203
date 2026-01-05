using _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels;
using _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels.Sliders;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Enums;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Extensions;
using _35_ServiceLifeTimeAppSettingProductn.DAL;
using _35_ServiceLifeTimeAppSettingProductn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("Adminpanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context= context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<GetSliderVM> getSliderVMs = await _context.Sliders
                .Select(s => new GetSliderVM
                {
                    Id = s.Id,
                    ImageURL = s.ImageURL
                })
                .ToListAsync();

            return View(getSliderVMs);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
        {
          if (!ModelState.IsValid)  return View(); 

            if (!sliderCreateVM.Photo.CheckFileType("Image/"))
            {
                ModelState.AddModelError("Photo", "File type is incorrect!");
                return View();
            }

            if (!sliderCreateVM.Photo.CheckFileSize(FileSize.MB,2))
            {
                ModelState.AddModelError("Photo", "File size must be less than 2mb!");
                return View();
            }
            Slider slider = new Slider
            {
                Title = sliderCreateVM.Title,
                SubTitle = sliderCreateVM.SubTitle,
                Order = sliderCreateVM.Order,
                Description = sliderCreateVM.Description,
                ImageURL= await sliderCreateVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "image", "website-image")
            };


     


            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1) return BadRequest();
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();

            string filePath = Path.Combine(_env.WebRootPath, "assets", "image", "website-image", slider.ImageURL);
           
            
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }   

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();

            SliderUpdateVM sliderUpdateVM = new SliderUpdateVM
            {
                Title = slider.Title,
                SubTitle = slider.SubTitle,
                Order = slider.Order,
                Description = slider.Description,
                ImageURL = slider.ImageURL
            };
            return View(sliderUpdateVM);

      
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM sliderUpdateVM)
        {
            if (id == null || id < 1) return BadRequest();
          

            if (!ModelState.IsValid) return View(sliderUpdateVM);

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();

            if (sliderUpdateVM.Photo is not null)
            {
                if (!sliderUpdateVM.Photo.CheckFileType("Image/"))
                {
                    ModelState.AddModelError(nameof(sliderUpdateVM.Photo), "File type is incorrect!");
                    return View();
                }
                if (!sliderUpdateVM.Photo.CheckFileSize(FileSize.MB, 2))
                {
                    ModelState.AddModelError(nameof(sliderUpdateVM.Photo), "File size must be less than 2mb!");
                    return View();
                }
                string FileName = await sliderUpdateVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "image", "website-image");
                slider.ImageURL.DeleteFile(_env.WebRootPath, "assets", "image", "website-image");
                slider.ImageURL = FileName;
            }
            slider.Title = sliderUpdateVM.Title;
            slider.SubTitle = sliderUpdateVM.SubTitle;
            slider.Order = sliderUpdateVM.Order;
            slider.Description = sliderUpdateVM.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null || id < 1) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null) return NotFound();
          
            return View(slider);

        }

    }
}
