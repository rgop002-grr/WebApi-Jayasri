using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Jayasri.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("All products");
        }
        [HttpGet("{id}")]
         public IActionResult GetById(int id)
        {
            return Ok($"Product {id}");
        }
    }
}
