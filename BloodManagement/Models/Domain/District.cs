namespace BloodManagement.Models.Domain
{
    public class District
    {
        public string districtId { get; set; }=Guid.NewGuid().ToString();
        public string districtName { get; set; }

        public virtual ICollection<Donor> Donors { get; set; }
    }
}
