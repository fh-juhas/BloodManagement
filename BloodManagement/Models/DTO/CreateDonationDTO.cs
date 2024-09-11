using BloodManagement.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodManagement.Models.DTO
{
    public class CreateDonoationDto
    {


        public string DonorId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverAddress { get; set; }

        public string? ReceiverEmail { get; set; }

        public string BloodGroupId { get; set; }

        public DateOnly DonationTime { get; set; }


    }
}
