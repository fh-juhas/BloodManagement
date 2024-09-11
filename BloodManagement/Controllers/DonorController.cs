using BloodManagement.Data.Implementation;
using BloodManagement.Data.Interface;
using BloodManagement.Models.Domain;
using BloodManagement.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DonorController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }


        [HttpGet("test")]
        public async Task<IActionResult> TestConnection()
        {
            return Ok(new
            {
                Code = "200",
                Message = "Connected with the API project."
            });
        }

        [HttpGet("GetAllDonors")]
        public async Task<ActionResult<Donor>> GetDonors()
        {
            try

            {
                List<string> includes = ["BloodGroup", "District" ];
                var donor = await _unitOfWork.Donors.GetAllAsync(includes: includes);
                //var donor = await _unitOfWork.Donors.GetAllAsync();
                if (donor == null)
                {
                    return NotFound();
                }
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting the donor.");
            }
        }

        [HttpPost("CreateDonor")]
        public async Task<ActionResult<Donor>> CreateDonor(CreateDonorDto donordto)
        {
            if (donordto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var donor = new Donor
                {
                    DonorName = donordto.DonorName,
                    BloodGroupId = donordto.BloodGroupId,
                    PhoneNumber = donordto.PhoneNumber,
                    Email = donordto.Email,
                    Address = donordto.Address,
                    DateOfBirth = donordto.DateOfBirth,
                    LastDonationDate = donordto.LastDonationDate,
                    Gender = donordto.Gender,
                    DistrictId = donordto.DistrictId,
                    PoliceStation = donordto.PoliceStation,
                    Remarks = donordto.Remarks,
                };
                await _unitOfWork.Donors.CreateAsync(donor);
                await _unitOfWork.SaveAsync();
                return Ok();
            }


            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the donor.");
            }
        }

        

        [HttpGet("GetDonorbyId/{id}")]
        public async Task<ActionResult<Donor>> GetDonorbyId(string id)
        {
            try
            {
                var donor = await _unitOfWork.Donors.GetAsync(x=>x.DonorId==id);
                if (donor == null)
                {
                    return NotFound();
                }
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting the donor.");
            }
        }

        [HttpGet("GetDonorbyBlood/{id}")]
        public async Task<ActionResult<Donor>> GetDonorbyBloodId(string id)
        {
            try
            {
                var donor = await _unitOfWork.Donors.GetAsync(x=>x.DonorId==id);
                if (donor == null)
                {
                    return NotFound();
                }
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting the donor.");
            }
        }

        [HttpGet("GetDonorbyName/{name}")]
        public async Task<ActionResult<IEnumerable<Donor>>> GetDonorbyName(string name)
        {
            try
            {
                var donors = await _unitOfWork.Donors.SearchByColumnAsync(name,"DonorName");
                if (donors == null || !donors.Any())
                {
                    return NotFound();
                }
                return Ok(donors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting the donor.");
            }
        }



        [HttpDelete("DeleteDonor/{id}")]
        public async Task<ActionResult> DeleteDonor(string id)
        {
            try
            {
                var donor = await _unitOfWork.Donors.GetAsync(x=>x.DonorId==id);
                if (donor == null)
                {
                    return NotFound();
                }
                _unitOfWork.Donors.DeleteAsync(donor);
                await _unitOfWork.SaveAsync();
                return Ok($"Donor with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the donor.");
            }
        }

        [HttpPut("UpdateDonor/{id}")]

        public async Task<ActionResult<Donor>> UpdateDonor(string id, UpdateDonorDto updateddonor)
        {
            if (id!=updateddonor.DonorId)
            {
                return BadRequest("id mismatched");
            }

            try
            {
                var donor = await _unitOfWork.Donors.GetAsync(e=>e.DonorId==id);
                if (donor == null)
                {
                    return NotFound($"employee with {id} not found");
                }
                donor.DonorId = updateddonor.DonorId;
                donor.DonorName = updateddonor.DonorName;
                donor.BloodGroupId = updateddonor.BloodGroupId;
                donor.PhoneNumber = updateddonor.PhoneNumber;
                donor.Email = updateddonor.Email;
                donor.Address = updateddonor.Address;
                donor.DateOfBirth = updateddonor.DateOfBirth;
                donor.LastDonationDate = updateddonor.LastDonationDate;
                donor.Gender = updateddonor.Gender;
                donor.DistrictId = updateddonor.DistrictId;
                donor.PoliceStation = updateddonor.PoliceStation;
                donor.Remarks = updateddonor.Remarks;

                await _unitOfWork.Donors.UpdateAsync(donor);
                await _unitOfWork.SaveAsync();

                return Ok($"Donor with ID {id} updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the donor.");
            }
        }
    }
}
