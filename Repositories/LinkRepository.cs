using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Repositories
{
    public class LinkRepository : GenericRepository<Link>, ILinkRepository
    {
        private readonly AppDbContext _context;

        public LinkRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Link>> GetLinksByInterestIdAsync(int interestId)
        {
            return await _context.Links
                .Where(l => l.InterestId == interestId)
                .ToListAsync();
        }
        public async Task AddLinkToInterestAsync(int interestId, Link link)
        {
            link.InterestId = interestId;
            await AddAsync(link);
            await SaveAsync();
        }
    }
}

