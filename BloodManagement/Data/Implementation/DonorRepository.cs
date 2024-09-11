using BloodManagement.Data.Interface;
using BloodManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloodManagement.Data.Implementation
{
    public class DonorRepository : BaseRepository<Donor>, IDonorRepository
    {
        private ApplicationDbContext _context;
        public DonorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            
        }

        public async Task<List<Donor>> SearchByName(string name)
        {
            return await _context.Donors
                           .Where(d => d.DonorName.ToLower().Contains(name.ToLower()))
                           .ToListAsync();
        }
    }
}
