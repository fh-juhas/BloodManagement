using BloodManagement.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodManagement.Models.DTO
{
    public class CreateDonorDto
    {

        public string DonorName { get; set; }
        public string BloodGroupId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public DateOnly? LastDonationDate { get; set; }

        public string Gender { get; set; }

        public string DistrictId { get; set; }

        public string? PoliceStation { get; set; }
        public string? Remarks { get; set; }


    }
}
