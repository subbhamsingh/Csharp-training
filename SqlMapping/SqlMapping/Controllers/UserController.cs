

using Microsoft.AspNetCore.Mvc;
using SqlMapping.Logic;

namespace SqlMapping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserLogic _logic;

        public UsersController(UserLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var data = _logic.GetUsers();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsersByDepartment(int id)
        {
            var data = _logic.GetUsersByDepartment(id);
            return Ok(data);
        }

        [HttpGet("function/{id}")]
        public IActionResult GetUsersByDepartmentFunction(int id)
        {
            var data = _logic.GetUsersByDepartment(id);
            return Ok(data);
        }
    }
}