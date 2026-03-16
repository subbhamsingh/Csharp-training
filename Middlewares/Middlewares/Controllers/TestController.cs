using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Middlewares.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
   
        public IActionResult Get()
        {
            return Ok("api working");
        }
    }
}

