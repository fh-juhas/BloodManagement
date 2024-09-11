using BloodManagement.Data.Interface;
using BloodManagement.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BloodController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllBloodGroups")]
        public async Task<ActionResult<List<BloodGroup>>> GetAllBlood()
        {
            var blood = await _unitOfWork.BloodGroups.GetAllAsync();
            return Ok(blood);
        }
    }
}
