using E_Commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {




        private readonly ISharedRespository<Products> _productRespository;

        public ProductsController(ISharedRespository<Products> productRespository)
        {
            _productRespository = productRespository;
        }

        [HttpGet]   // // must be here always with APIs
        public async Task<IEnumerable<Products>> GetProducts()// //async → to increase performance
                       // //let everything work at the same time and who ends first show the results   
        {
           return _productRespository.List();
        }


        // // when run without creating a view ... it will run as a json file(shown as array) →
        // // which means an object understand all programming langueges

        [HttpDelete("{id}")] // to understand that he will recieved a paramete from the ajax
        public IActionResult DeleteProducts(int id)
        {
            try {
                _productRespository.delete(id);
            return NoContent();
                }
            catch (Exception ex)
            {  // 500→interal server error  ///  200→ success /// 404→not found /// 400→ validation
                return StatusCode(500, new { error = $"Error deleting activity: (ex.Message)" });
            }
        }

        [HttpPost]
        public IActionResult Create (Products products)
        {

            try
            {
                _productRespository.Add(products);
                return NoContent();
            }
            catch (Exception ex)
            {  // 500→interal server error  ///  200→ success /// 404→not found /// 400→ validation
                return StatusCode(500, new { error = $"Error deleting activity: (ex.Message)" });
            }



            
            return Ok();
        }






        [HttpPut]
        public IActionResult Edit(Products products)
        {
            
            try
            {
                _productRespository.Update(products);
                return NoContent();
            }
            catch (Exception ex)
            {  // 500→interal server error  ///  200→ success /// 404→not found /// 400→ validation
                return StatusCode(500, new { error = $"Error activity: (ex.Message)" });
            }

        }





    }
}
