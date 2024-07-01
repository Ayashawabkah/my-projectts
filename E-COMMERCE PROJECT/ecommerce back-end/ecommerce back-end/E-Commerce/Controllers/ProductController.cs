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
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                return View(_productRespository.List(null));
            }
                return RedirectToAction("Login","User");

        }


        [HttpGet]
        public IActionResult Create()
        {
           
                ViewBag.CategoryId = new SelectList(_categoryRespository.List(null), "Id", "Name");

                return View();
            
        }


        [HttpPost]
        public IActionResult Create(Products product)
        {
            product.UserId = (int)HttpContext.Session.GetInt32("UserId");

            _productRespository.Add(product);

            ViewBag.CategoryId = new SelectList(_categoryRespository.List(null), "Id", "Name");
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRespository.FindBy(id);

            ViewBag.CategoryId = new SelectList(_categoryRespository.List(null), "Id", "Name", product.CategoryId);
            return View(_productRespository.FindBy(id));
        }

        [HttpPost]
        public IActionResult Edit(Products product)
        {
            ViewBag.CategoryId = new SelectList(_categoryRespository.List(null), "Id", "Name");
            _productRespository.Update(product);
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_productRespository.FindBy(id));
        }

        [HttpPost]
        [ActionName("Delete")]

        public IActionResult ConfirmDelete (int id)
        {
        _productRespository.delete(id);
            return RedirectToAction("Index");
           
        }




            
           





    }
}
