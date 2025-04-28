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

        public async Task AddLinkAsync(int personId, int interestId, string url)
        {
            var personInterest = await _context.PersonInterests
                .FirstOrDefaultAsync(pi => pi.PersonId == personId && pi.InterestId == interestId);

            if (personInterest == null) 
            {
                throw new Exception("The person is not connected to the interest.");
            }

            var link = new Link
            {
                Url = url,
                PersonId = personId,
                InterestId = interestId,
                PersonInterest = personInterest
            };

            await _context.Links.AddAsync(link);
            await _context.SaveChangesAsync();
        }
    }
}

