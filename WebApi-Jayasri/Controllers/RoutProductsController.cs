using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Jayasri.Controllers
{
    //Attribute routing Ovveride the conventional routing so  Conventional Routing without Work Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class RoutProductsController : ControllerBase
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

