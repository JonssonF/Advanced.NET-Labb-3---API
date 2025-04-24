using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Repositories
{
    public class InterestRepository : GenericRepository<Interest>, IInterestRepository
    {
        public InterestRepository(AppDbContext context) : base(context)
        {

        }
    }
}
