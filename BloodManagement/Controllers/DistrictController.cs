using BloodManagement.Data.Interface;
using BloodManagement.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistrictController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistrictController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllDistricts")]
        public async Task<ActionResult<List<District>>> GetAllDistricts()
        {
            var district = await _unitOfWork.Districts.GetAllAsync();
            return Ok(district);
        }
    }
}
