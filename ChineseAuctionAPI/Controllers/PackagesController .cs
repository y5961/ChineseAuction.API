//using ChineseAuctionAPI.DTOs;
//using ChineseAuctionAPI.Models;
//using ChineseAuctionAPI.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace ChineseAuctionAPI.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class PackagesController : ControllerBase
//    {
//        private readonly PackageService _packageService;
//        public PackagesController(PackageService packageService) => _packageService = packageService;

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<PackageDTO>>> GetAll()
//        {
//            var packages = await _packageService.GetAllAsync();
//            return Ok(packages);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<PackageDTO>> GetById(int id)
//        {
//            var package = await _packageService.GetByIdAsync(id);
//            if (package == null) return NotFound();
//            return Ok(package);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(Package package)
//        {
//            await _packageService.AddAsync(package);
//            return CreatedAtAction(nameof(GetById), new { id = package.IdPackage }, package);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, Package package)
//        {
//            if (id != package.IdPackage) return BadRequest();
//            await _packageService.UpdateAsync(package);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _packageService.DeleteAsync(id);
//            return NoContent();
//        }
//    }
//}
