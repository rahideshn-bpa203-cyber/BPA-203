using _35_ServiceLifeTimeAppSettingProductn.DAL;
using Microsoft.AspNetCore.Mvc;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class DashboardController : Controller
    {
        AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
      
    }
}
