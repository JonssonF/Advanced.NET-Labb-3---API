using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interest>> GetPersonInterestsAsync(int personId)
        {
            var person = await _context.Persons
                .Include(p => p.PersonInterests)
                    .ThenInclude(pi => pi.Interest)
                .FirstOrDefaultAsync(p => p.Id == personId);

            return person?.PersonInterests.Select(pi => pi.Interest) ?? new List<Interest>();
        }

        public async Task<IEnumerable<Link>> GetPersonLinksAsync(int personId)
        {
            var person = await _context.Persons
                .Include(p => p.PersonInterests)
                    .ThenInclude(pi => pi.Links)
                .FirstOrDefaultAsync(p => p.Id == personId);

            return person?.PersonInterests.SelectMany(pi => pi.Links) ?? new List<Link>();
        }

        public async Task AddInterestToPersonAsync(int personId, int interestId)
        {
            var exists = await _context.PersonInterests.AnyAsync(pi =>
                pi.PersonId == personId && pi.InterestId == interestId);

            if (!exists)
            {
                _context.PersonInterests.Add(new PersonInterest
                {
                    PersonId = personId,
                    InterestId = interestId
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
