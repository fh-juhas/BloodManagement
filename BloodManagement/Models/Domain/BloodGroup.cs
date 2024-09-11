using System.ComponentModel.DataAnnotations;

namespace BloodManagement.Models.Domain
{
    public class BloodGroup
    {
        [Key]
        public string BloodGroupId { get; set; }=Guid.NewGuid().ToString();
        public string GroupName { get; set; }

        public virtual ICollection<Donor> Donors { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }


    }
}
