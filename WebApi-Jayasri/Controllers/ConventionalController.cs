using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Jayasri.Controllers
{
    //Attribute routing Ovveride the conventional routing so  Conventional Routing without Work Attribute Routing
    
    
    public class ConventionalController : ControllerBase
    {
       

        public IActionResult GetAll()
        {
            return Ok("All products");
        }
        
        public IActionResult GetById(int id)
        {
            return Ok($"Product {id}");
        }
    }
}

