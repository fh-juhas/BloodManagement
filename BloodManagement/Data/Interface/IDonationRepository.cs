using BloodManagement.Models.Domain;

namespace BloodManagement.Data.Interface
{
    public interface IDonationRepository: IBaseRepository<Donation>
    {
        Task<List<Donation>> SearchByName(string name);
    }
}
