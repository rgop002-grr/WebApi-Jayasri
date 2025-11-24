using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Jayasri.Interfaces;

namespace WebApi_Jayasri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDIController : ControllerBase
    {

        private readonly ITransientGuidService _transient;
        private readonly IScopedGuidService _scoped;
        private readonly ISingletonGuidService _singleton;

        public TestDIController(
            ITransientGuidService transient,
            IScopedGuidService scoped,
            ISingletonGuidService singleton)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
        }

        
        [HttpGet]
        public IActionResult GetGuids()
        {
            return Ok(new
            {
                Transient = _transient.GetGuid(),
                Scoped = _scoped.GetGuid(),
                Singleton = _singleton.GetGuid()
            });
        }
    }
}
