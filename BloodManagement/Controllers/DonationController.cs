using BloodManagement.Data.Implementation;
using BloodManagement.Data.Interface;
using BloodManagement.Models.Domain;
using BloodManagement.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DonationController(IUnitOfWork unitofwork)
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

        [HttpPost("CreateDonation")]
        public async Task<ActionResult<Donation>> CreateDonation(CreateDonoationDto donationdto)
        {
            if (donationdto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var donor = new Donation
                {
                    DonorId = donationdto.DonorId,
                    ReceiverName = donationdto.ReceiverName,
                    ReceiverPhone = donationdto.ReceiverPhone,
                    ReceiverAddress = donationdto.ReceiverAddress,
                    ReceiverEmail = donationdto.ReceiverEmail,
                    BloodGroupId = donationdto.BloodGroupId,
                    DonationTime = donationdto.DonationTime,
                };
                await _unitOfWork.Donations.CreateAsync(donor);
                await _unitOfWork.SaveAsync();
                return Ok();
            }


            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the donor.");
            }
        }

        [HttpGet("GetAllDonations")]
        public async Task<ActionResult<Donor>> GetDonation()
        {
            try
            
            {
                List<string> includes = ["Donor", "BloodGroup"];
                var donation = await _unitOfWork.Donations.GetAllAsync(includes:includes);
                if (donation == null)
                {
                    return NotFound();
                }
                return Ok(donation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting the donor.");
            }
        }

        [HttpGet("GetDonationbyId/{id}")]
        public async Task<ActionResult<Donation>> GetDonationbyId(string id)
        {
            try
            {
                var donor = await _unitOfWork.Donations.GetAsync(x=>x.DonationId==id);
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

        [HttpGet("GetDonationbydonorID/{id}")]
        public async Task<ActionResult<Donor>> GetDonationByDonor(string id)
        {
            try
            {
                var donor = await _unitOfWork.Donations.GetAsync(x=>x.DonorId ==id);
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

        [HttpGet("GetDonationByRecieverName/{name}")]
        public async Task<ActionResult<Donor>> FindDonationByName(string name)
        {
            try
            {
                var donor = await _unitOfWork.Donations.SearchByColumnAsync(name, "ReceiverName");
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

        [HttpDelete("DeleteDonation/{id}")]

        public async Task<ActionResult> DeleteDonation(string id)
        {
            try
            {
                var donor = await _unitOfWork.Donations.GetAsync(x=>x.DonorId==id);
                if (donor == null)
                {
                    return NotFound();
                }
                _unitOfWork.Donations.DeleteAsync(donor);
                await _unitOfWork.SaveAsync();
                return Ok($"Donor with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the donor.");
            }
        }

        [HttpPut("UpdateDonation/{id}")]

        public async Task<ActionResult<Donor>> UpdateDonation(string id,UpdateDonationDto updateddonation)
        {
            if (id!= updateddonation.DonationId)
            {
                return BadRequest("id mismatched");
            }

            try
            {
                var donor = await _unitOfWork.Donations.GetAsync(e=>e.DonationId==id);
                if (donor == null)
                {
                    return NotFound($"employee with {id} not found");
                }
                donor.DonationId = updateddonation.DonationId;
                donor.DonorId = updateddonation.DonorId;
                donor.ReceiverName = updateddonation.ReceiverName;
                donor.ReceiverPhone = updateddonation.ReceiverPhone;
                donor.ReceiverAddress = updateddonation.ReceiverAddress;
                donor.ReceiverEmail = updateddonation.ReceiverEmail;
                donor.BloodGroupId = updateddonation.BloodGroupId;
                donor.DonationTime = updateddonation.DonationTime;

                await _unitOfWork.Donations.UpdateAsync(donor);
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
