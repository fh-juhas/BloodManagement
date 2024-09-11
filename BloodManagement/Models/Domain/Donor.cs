using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodManagement.Models.Domain
{
    public class Donor
    {
        [Key]
        public string DonorId { get; set; } = Guid.NewGuid().ToString();
        public string DonorName { get; set; }
        [Required]
        [ForeignKey("BloodGroup")]
        public string BloodGroupId { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? LastDonationDate { get; set; }
        public string Gender { get; set; }
        [Required]
        [ForeignKey("District")]
        public string DistrictId { get; set; }
        public string? PoliceStation { get; set; }
        public string? Remarks { get; set; }

        public bool? IsEligibleToDonate
        {
            get
            {
                if (LastDonationDate == null)
                {
                    return true; // Eligible if they haven't donated before
                }

                DateOnly currentDateOnly = DateOnly.FromDateTime(DateTime.Now);

                int daysSinceLastDonation = currentDateOnly.DayNumber - LastDonationDate.Value.DayNumber;

                return daysSinceLastDonation >= 120;
            }
        }

        public virtual BloodGroup BloodGroup { get; set; }
        public virtual District District { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
    }


}
