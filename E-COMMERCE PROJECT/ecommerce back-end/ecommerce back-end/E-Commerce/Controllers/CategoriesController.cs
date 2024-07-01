using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class CategoriesController : Controller
    {




        private readonly ISharedRespository<Category> _categoryRespository;

        public CategoriesController(ISharedRespository<Category> categoryRespository)
        {
            _categoryRespository = categoryRespository;
        }




        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create() 
        {
            return View();
        }


        ////[HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            return View(_categoryRespository.FindBy(id));
        }






    }
}
