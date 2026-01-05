using _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels.Products;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Enums;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Extensions;
using _35_ServiceLifeTimeAppSettingProductn.DAL;
using _35_ServiceLifeTimeAppSettingProductn.Models;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("Adminpanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<GetProductVM> getProductVMs = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Select(p => new GetProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    ImageURL = p.ProductImages.FirstOrDefault(p=>p.IsPrimary==true).ImageURL
                })
                .ToListAsync();



            return View(getProductVMs);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || id < 1) return BadRequest();

            Product product = await _context.Products.Include(p => p.ProductImages.Where(pi => pi.IsPrimary == true)).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .FirstOrDefault(x => x.Id == id);




            return View(product);
        }
        public async Task<IActionResult> Create()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            List<Tag> tags = await _context.Tags.ToListAsync();


            CreateProductVM createProductVM = new()
            {
                Categories = categories,
                Tags = tags
            };
            return View(createProductVM);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            createProductVM.Categories = await _context.Categories.ToListAsync();
            createProductVM.Tags = await _context.Tags.ToListAsync();
            if (createProductVM.Price < 0)
            {
                ModelState.AddModelError(nameof(createProductVM.Price), "Price does not negative!");
                return View(createProductVM);
            }

            if (!ModelState.IsValid)
            {
                return View(createProductVM);
            }

            if (!createProductVM.MainPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(createProductVM.MainPhoto), "File type is incorrect");
                return View(createProductVM);
            }
            if (!createProductVM.MainPhoto.CheckFileSize(FileSize.MB, 1))
            {
                ModelState.AddModelError(nameof(createProductVM.MainPhoto), "File size must be less than 1mb");
                return View(createProductVM);
            }

            if (!createProductVM.HoverPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(createProductVM.HoverPhoto), "File type is incorrect");
                return View(createProductVM);
            }
            if (!createProductVM.HoverPhoto.CheckFileSize(FileSize.MB, 1))
            {
                ModelState.AddModelError(nameof(createProductVM.HoverPhoto), "File size must be less than 1mb");
                return View(createProductVM);
            }

            bool exsistCategory = createProductVM.Categories.Any(c => c.Id == createProductVM.CategoryId);
            if (!exsistCategory)
            {
                ModelState.AddModelError(nameof(createProductVM.CategoryId), "Category does not exsist");
                return View(createProductVM);
            }


            if (createProductVM.TagIds is not null)
            {
                bool exsistTag = createProductVM.TagIds.Any(tid => !createProductVM.Tags.Exists(t => t.Id == tid));

                if (exsistTag)
                {

                    ModelState.AddModelError(nameof(createProductVM.TagIds), "Tag does not exsist");
                    return View(createProductVM);
                }

            }

            //foreach(var tid in createProductVM.TagIds)
            //{

            //    bool exsistTag = createProductVM.Tags.Any(t => t.Id == tid);
            //    if (!exsistTag)
            //    {
            //        ModelState.AddModelError(nameof(createProductVM.TagIds), "Tag does not exsist");
            //        return View(createProductVM);
            //    }
            //}

            ProductImage mainImage = new()
            {
                ImageURL = await createProductVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = true
            };

            ProductImage hoverImage = new()
            {
                ImageURL = await createProductVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = false
            };


            Product product = new()
            {
                Name = createProductVM.Name,
                Price = createProductVM.Price.Value,
                Description = createProductVM.Description,
                SKU = createProductVM.SKU,
                CategoryId = createProductVM.CategoryId.Value,
                ProductImages = new List<ProductImage> { mainImage, hoverImage }
            };



            if (createProductVM.TagIds is not null)
            {
                product.ProductTags = createProductVM.TagIds.Select(tid => new ProductTag { TagId = tid }).ToList();
            }


            if (createProductVM.AdditionalPhotos is null)
            {
                string text = string.Empty;
                foreach (IFormFile file in createProductVM.AdditionalPhotos)
                {
                    if (!file.CheckFileType("image/"))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} type was not correct";
                        continue;
                    }
                    if (!file.CheckFileSize(FileSize.MB, 1))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} size was not correct";
                        continue;
                    }
                    product.ProductImages.Add(new ProductImage
                    {
                        ImageURL = await file.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = null
                    });
                    TempData["FileWarning"] = text;
                }
            }




            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Product product = await _context.Products.Include(p => p.ProductImages).Include(p => p.ProductTags).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            UpdateProductVM updateProduct = new()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                SKU = product.SKU,
                CategoryId = product.CategoryId,
                Categories = await _context.Categories.ToListAsync(),
                Tags = await _context.Tags.ToListAsync(),
                TagIds = product.ProductTags.Select(pt => pt.TagId).ToList(),
                ProductImages = product.ProductImages
            };
            return View(updateProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateProductVM updateProductVM)
        {
            if (id == null || id < 1) return BadRequest();
            Product exsistProduct = await _context.Products.Include(p=>p.ProductImages).Include(p => p.ProductTags).FirstOrDefaultAsync(p => p.Id == id);

            if (exsistProduct == null) return NotFound();


            updateProductVM.Categories = await _context.Categories.ToListAsync();
            updateProductVM.Tags = await _context.Tags.ToListAsync();
            updateProductVM.ProductImages=exsistProduct.ProductImages;



            if (!ModelState.IsValid)
            {
                return View(updateProductVM);
            }

            if (updateProductVM.TagIds is not null)
            {
                bool exsistTag = updateProductVM.TagIds.Any(tid => !updateProductVM.Tags.Exists(t => t.Id == tid));

                if (exsistTag)
                {

                    ModelState.AddModelError(nameof(updateProductVM.TagIds), "Tag does not exsist");
                    return View(updateProductVM);
                }

            }


          


            if (updateProductVM.MainPhoto is not null)
            {
                if (!updateProductVM.MainPhoto.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(updateProductVM.MainPhoto), "File type is incorrect");
                    return View(updateProductVM);
                }
                if (!updateProductVM.MainPhoto.CheckFileSize(FileSize.MB, 1))
                {
                    ModelState.AddModelError(nameof(updateProductVM.MainPhoto), "File size must be less than 1mb");
                    return View(updateProductVM);
                }

            }

            if (updateProductVM.HoverPhoto is not null)
            {
                if (!updateProductVM.HoverPhoto.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(updateProductVM.HoverPhoto), "File type is incorrect");
                    return View(updateProductVM);
                }
                if (!updateProductVM.HoverPhoto.CheckFileSize(FileSize.MB, 1))
                {
                    ModelState.AddModelError(nameof(updateProductVM.HoverPhoto), "File size must be less than 1mb");
                    return View(updateProductVM);
                }

            }

            if (exsistProduct.CategoryId != updateProductVM.CategoryId)
            {
                bool exsistCategory = updateProductVM.Categories.Any(c => c.Id == updateProductVM.CategoryId);

                if (!exsistCategory)
                {
                    ModelState.AddModelError(nameof(updateProductVM.CategoryId), "Category does not exsist");
                    return View(updateProductVM);
                }
            }

            // ptId                                      // tid                                      
            // 1 2 4                                    //1 3 5
            // exsistProduct.ProductTags                 //updateProductVM.TagIds

            //foreach (ProductTag pTag in exsistProduct.ProductTags)
            //{
            //    if(!updateProductVM.TagIds.Exists(tid=>tid==pTag.TagId))
            //    {
            //       deletedTag.Add(pTag);
            //    }
            //}

            if (updateProductVM.TagIds is null)
            {
                updateProductVM.TagIds = new();
            }
            else
            {
                updateProductVM.TagIds = updateProductVM.TagIds.Distinct().ToList();
            }


            if (updateProductVM.TagIds is null)
            {
                _context.ProductTags.RemoveRange(exsistProduct.ProductTags
                .Where(pTag => !updateProductVM.TagIds
                .Exists(tid => tid == pTag.TagId))
                .ToList());
                _context.ProductTags.AddRange(updateProductVM.TagIds
               .Where(tId => !exsistProduct.ProductTags
               .Exists(pTag => pTag.TagId == tId))
               .Select(tid => new ProductTag { TagId = tid, ProductId = exsistProduct.Id })
                   );
            }

            if (updateProductVM.MainPhoto is not null)
            {
                string fileName = await updateProductVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images");
                ProductImage mainImage = exsistProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == true);
                mainImage.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                exsistProduct.ProductImages.Remove(mainImage);
                exsistProduct.ProductImages.Add(new ProductImage
                {
                    ImageURL = fileName,
                    IsPrimary = true
                });
            }

            if (updateProductVM.HoverPhoto is not null)
            {
                string fileName = await updateProductVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images");
                ProductImage hoverImage = exsistProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == false);
                hoverImage.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                exsistProduct.ProductImages.Remove(hoverImage);
                exsistProduct.ProductImages.Add(new ProductImage
                {
                    ImageURL = fileName,
                    IsPrimary = false
                });
            }

      

            if(updateProductVM.ImageIds is null)
            {
                updateProductVM.ImageIds = new List<int>(); 
            }


            // 1 2         3 4 5      1 2 7 8 9

            var deletedImages = exsistProduct.ProductImages.Where(pi=> !updateProductVM.ImageIds.Exists(imgId=>imgId==pi.Id) && pi.IsPrimary==null).ToList();

            deletedImages.ForEach(di=>di.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images"));
            _context.ProductImages.RemoveRange(deletedImages);
            if (updateProductVM.AdditionalPhotos is null)
            {
                string text = string.Empty;
                foreach (IFormFile file in updateProductVM.AdditionalPhotos)
                {
                    if (!file.CheckFileType("image/"))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} type was not correct";
                        continue;
                    }
                    if (!file.CheckFileSize(FileSize.MB, 1))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} size was not correct";
                        continue;
                    }
                    exsistProduct.ProductImages.Add(new ProductImage
                    {
                        ImageURL = await file.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = null
                    });
                    TempData["FileWarning"] = text;
                }
            }


            exsistProduct.Name = updateProductVM.Name;
                exsistProduct.Price = updateProductVM.Price.Value;
                exsistProduct.Description = updateProductVM.Description;
                exsistProduct.SKU = updateProductVM.SKU;
                exsistProduct.CategoryId = updateProductVM.CategoryId.Value;
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
        
          public async Task<IActionResult> Delete(int? id)
              {

            if (id is null || id < 1) return BadRequest();

            Product exsistProduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);

            
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
               }

    }
}

