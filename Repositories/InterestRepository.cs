using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Labb3_API.Repositories
{
    public class InterestRepository : GenericRepository<Interest>, IInterestRepository
    {
        private readonly AppDbContext _context;

        public InterestRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Interest>> GetAllInterestsAsync()
        {
            return await _context.Interests.ToListAsync();
        }
    }
}
