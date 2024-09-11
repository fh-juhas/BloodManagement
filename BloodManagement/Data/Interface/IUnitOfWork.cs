using BloodManagement.Models.Domain;

namespace BloodManagement.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Donor> Donors { get; }
        IGenericRepository<BloodGroup> BloodGroups { get; }
        IGenericRepository<District> Districts { get; }
        IGenericRepository<Donation> Donations { get; }
       
        Task SaveAsync();
        Task ExecuteProcedureWithoutResult(string query);
    }
}
