using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISharedRespository<Category> _categoryRepository;
        private readonly ISharedRespository<Products> _productsRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger,
            ISharedRespository<Category> categoryRepository,
            ISharedRespository<Products> productsRepository,                           
            ApplicationDbContext db)
        {
            _categoryRepository = categoryRepository;
            _productsRepository = productsRepository;
            _logger = logger;
            this.db = db;
        }









        //public HomeController(ISharedRespository<Category> categoryRepository, 
        //    ILogger<HomeController> logger,
        //    ISharedRespository<Products> productsRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //    _logger = logger;
        //    _productsRepository = productsRepository;
        //}




        public IActionResult GetProductByCategory(int id)
        {
            return View(_productsRepository.List(id));      
        }


        public IActionResult Index()
        {
            return View(_categoryRepository.List(null));
        }

        public IActionResult Details(int id)
        {
            return View(_productsRepository.FindBy(id));
        }



        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var usrId = HttpContext.Session.GetInt32("UserId");
            var cart = db.Carts.SingleOrDefault(c => c.ProductId == productId
                && c.UserId == usrId); //means one data but where more than one data


            if (usrId == 0 || usrId != null)  // means that there is a login action
            {            
               
                if(cart == null)
                {
                    var addCart = new Cart();
                    addCart.ProductId = productId;
                    addCart.UserId = Convert.ToInt32(usrId);
                    addCart.Quantity = 1;
                    db.SaveChanges();
                }
                else
                {
                    cart.Quantity++;
                    db.SaveChanges();
                }
               
                return View();
            }
            else
            {
                return RedirectToAction("Login" , "User");
            }
        
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}