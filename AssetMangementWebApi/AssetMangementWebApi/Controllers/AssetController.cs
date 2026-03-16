using AssetMangementWebApi.Models;
using AssetMangementWebApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace AssetMangementWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly AssetService _service; 


        // constructor of this AssetController class
        public AssetController(AssetService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var assets = _service.GetALL();
            return Ok(assets);
        }

      
        //add route constraint
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var asset = _service.GetById(id);
            if (asset == null)
                return NotFound();
            return Ok(asset);
        }


        [HttpPost]
        public IActionResult Add(Asset asset)
        {
            _service.Add(asset);
            return Ok("Asset Created");
         
        }


        //  added put also 

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Asset updatedAsset)
        {
            var result = _service.Update(id, updatedAsset);

            if (!result)
                return NotFound();

            return Ok("Asset updated successfully");
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Asset Deleted");
       
        }


        // assign api
        [HttpPut("{id:int}/assign")]
        public IActionResult Assign(int id, string userName)
        {
            var asset = _service.GetById(id);
            if (asset == null) 
                return NotFound("Asset Not Found");

            if (!string.IsNullOrEmpty(asset.AssignedTo))
                return BadRequest("Asset already present");
            asset.AssignedTo = userName;
            return Ok("Asset Assigned successfuly");
        }


        // unassign api
        [HttpPut("{id:int}/unassign")]
        public IActionResult Unassign(int id)
        {
            var asset = _service.GetById(id);

            if (asset == null)
                return NotFound("Asset not found");

            if (string.IsNullOrEmpty(asset.AssignedTo))
                return BadRequest("Asset is not assigned");

            asset.AssignedTo = null;

            return Ok("Asset unassigned successfully");
        }

    }

}
