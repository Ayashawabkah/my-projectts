using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext db;

        public UserController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]  // which is the default if i dont write its ok
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login( User user )
        {
            var usr = db.Users.SingleOrDefault(u=> u.Email == user.Email &&
                                           u.Password == user.Password);

            if (usr != null)
            {
                HttpContext.Session.SetInt32("UserId", usr.UserId);

                if (usr.UserType == "Admin")
                {
                    return RedirectToAction("Index", "Categories");
                }

                else if (usr.UserType == "Company")
                {
                    return RedirectToAction("Index", "Product");
                }

                else if (usr.UserType == "User")
                {
                    return RedirectToAction("Index", "Home");
                }


            }
            return View(user); // the user inside means if its null stay at the same page
        }

        [HttpGet]
        public IActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Register (User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return View();
        }


    }
}
