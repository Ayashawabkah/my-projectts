using E_Commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ISharedRespository<Category> _categoryRespository;

        public CategoryController(ISharedRespository<Category> categoryRespository)
        {
            _categoryRespository = categoryRespository;
        }

        [HttpGet]   // // must be here always with APIs
        public async Task<IEnumerable<Category>> GetCategories()// //async → to increase performance
                       // //let everything work at the same time and who ends first show the results   
        {
           return _categoryRespository.List(null);
        }


        // // when run without creating a view ... it will run as a json file(shown as array) →
        // // which means an object understand all programming langueges

        [HttpDelete("{id}")] // to understand that he will recieved a paramete from the ajax
        public IActionResult DeleteCategories(int id)
        {
            try { 
            _categoryRespository.delete(id);
            return NoContent();
                }
            catch (Exception ex)
            {  // 500→interal server error  ///  200→ success /// 404→not found /// 400→ validation
                return StatusCode(500, new { error = $"Error deleting activity: (ex.Message)" });
            }
        }

        [HttpPost("create1")]
        public IActionResult Create (Category category)
        {

            try
            {
                _categoryRespository.Add(category);
                return NoContent();
            }
            catch (Exception ex)
            {  // 500→interal server error  ///  200→ success /// 404→not found /// 400→ validation
                return StatusCode(500, new { error = $"Error deleting activity: (ex.Message)" });
            }



            
            return Ok();
        }






        [HttpPut]
        public IActionResult Edit(Category category)
        {
            
            try
            {
                _categoryRespository.Update(category);
                return NoContent();
            }
            catch (Exception ex)
            {  // 500→interal server error  ///  200→ success /// 404→not found /// 400→ validation
                return StatusCode(500, new { error = $"Error activity: (ex.Message)" });
            }

        }




    }
}
