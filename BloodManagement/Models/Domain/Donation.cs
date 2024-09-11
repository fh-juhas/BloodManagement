using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BloodManagement.Models.Domain
{
    public class Donation
    {
        public string DonationId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey("DonorInfo")]
        public string DonorId { get; set; }
        public virtual Donor Donor { get; set; }
        [Required]
        public string ReceiverName { get; set; }

        [Required]
        [Phone]
        public string ReceiverPhone { get; set; }
        [Required]
        public string ReceiverAddress { get; set; }

        public string? ReceiverEmail { get; set; }

        [Required]
        [ForeignKey("BloodGroup")]
        public string BloodGroupId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }

        public DateOnly DonationTime { get; set; }
        public virtual ICollection<Donor> Donors { get; set; }
        public virtual ICollection<BloodGroup> BloodGroups { get; set; }
    }
}
