using BloodManagement.Data.Interface;
using BloodManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloodManagement.Data.Implementation
{
    public class DonationRepository : BaseRepository<Donation>, IDonationRepository
    {
        private ApplicationDbContext _context;
        public DonationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            
        }

        public async Task<List<Donation>> SearchByName(string name)
        {
            return await _context.Donations
                           .Where(d => d.ReceiverName.ToLower().Contains(name.ToLower()))
                           .ToListAsync();
        }
    }
}
