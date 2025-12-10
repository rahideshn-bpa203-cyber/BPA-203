using DynamicProperty_VieModel.Models;
using DynamicProperty_VieModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DynamicProperty_VieModel.Controllers
{
    public class HomeController:Controller
    {
        List<Student> students = new List<Student>
        {
          new Student{Id=1,Name="Ilham",Age=19},
          new Student{Id=1,Name="Rehim",Age=19},
          new Student{Id=1,Name="Roya",Age=19}

        };
         
        List<Teacher> teachers =new List<Teacher>
        {
            new Teacher{Id=1,Name="Seid",Salary=1020.90m },
            new Teacher{Id=2,Name="Rashad",Salary=1200.90m },

        };


        public IActionResult Index()
        {
            //ViewBag.Students = students;
            //ViewData["Student"] = students;
            //TempData["Name"] = "Rahide";
            HomeVM homeVM = new HomeVM
            {
                Students = students,
                Teachers = teachers
            };
            return View(homeVM);
        }
        public IActionResult Details()
        {
            return View();
        }

        [Route("korporativ-satislar")]
        public IActionResult CorporativeSales()
        {
            return View();
        }

    }
}
