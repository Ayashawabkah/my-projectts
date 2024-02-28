using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {



        private readonly ISharedRespository<Products> _productRespository;

        private readonly ISharedRespository<Category> _categoryRespository;

        public ProductController(ISharedRespository<Products> productRespository, ISharedRespository<Category> categoryRespository)
        {
            _productRespository = productRespository;
            _categoryRespository = categoryRespository;
        }



        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
                ViewBag.DropDownListData = new SelectList(_categoryRespository.List(), "Id", "Name");
          

            return View();
        }


        ////[HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            return View(_productRespository.FindBy(id));
        }





    }
}
