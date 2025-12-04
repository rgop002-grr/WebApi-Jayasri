using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Jayasri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/orders
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok("All orders list");
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            return Ok($"Order with ID = {id}");
        }

        // POST: api/orders
        [HttpPost]
        public IActionResult CreateOrder()
        {
            return Ok("Order created");
        }

        // PUT: api/orders/5
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id)
        {
            return Ok($"Order {id} updated");
        }

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            return Ok($"Order {id} deleted");
        }
    }
}
