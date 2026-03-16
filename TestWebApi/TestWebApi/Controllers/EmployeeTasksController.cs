
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeTasksController : ControllerBase
    {
        private readonly IEmployeeTaskService _service;
        public EmployeeTasksController(IEmployeeTaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null)
                return NotFound($"Task with Id {id} not found.");

            return Ok(task);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeTask task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeTask task)
        {
            if (!ModelState.IsValid)
                    return BadRequest(ModelState);

            if (id != task.Id)
                return BadRequest("Id mismatch.");

            try
            {
                await _service.UpdateAsync(task);

                var updatedTask = await _service.GetByIdAsync(task.Id);
                return Ok(updatedTask);
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

       
    }

    //public class TaskImplemntaion
    //{
    //    public async Task GetAllApi(EmployeeTask tasks)
    //    {
    //        return Task.CompletedTask(tasks);
    //    }
    //}
}
