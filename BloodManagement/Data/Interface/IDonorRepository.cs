using BloodManagement.Models.Domain;

namespace BloodManagement.Data.Interface
{
    public interface IDonorRepository: IBaseRepository<Donor>
    {
        Task<List<Donor>> SearchByName(string name);
    }
}
