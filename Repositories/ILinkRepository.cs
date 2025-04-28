using Labb3_API.Models;

namespace Labb3_API.Repositories
{
    public interface ILinkRepository : IGenericRepository<Link>
    {
        Task AddLinkAsync(int personId, int interestId, string url);
    }
}
