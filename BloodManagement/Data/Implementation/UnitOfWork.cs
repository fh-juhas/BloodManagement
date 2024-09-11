using BloodManagement.Data.Interface;
using BloodManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloodManagement.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        GenericRepository<Donor> _Donors;
        GenericRepository<BloodGroup> _BloodGroups;
        GenericRepository<District> _Districts;
        GenericRepository<Donation> _Donations;


        //IGenericRepository<Donor> _Donors { get; }
        //IGenericRepository<BloodGroup> _BloodGroups { get; }
        //IGenericRepository<District> _Districts { get; }
        //IGenericRepository<Donation> _Donations { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Donor> Donors => _Donors ??= new GenericRepository<Donor>(_context);
        public IGenericRepository<BloodGroup> BloodGroups => _BloodGroups ??= new GenericRepository<BloodGroup>(_context);
        public IGenericRepository<District> Districts => _Districts ??= new GenericRepository<District>(_context);
        public IGenericRepository<Donation> Donations => _Donations ??= new GenericRepository<Donation>(_context);
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task ExecuteProcedureWithoutResult(string query)
        {
            await _context.Database.ExecuteSqlRawAsync(query);
        }
    }
}
