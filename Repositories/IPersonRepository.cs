using Labb3_API.Models;
using Labb3_API.Models.DTOs;

namespace Labb3_API.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<IEnumerable<Interest>> GetPersonInterestsAsync(int personId);
        Task<IEnumerable<Link>> GetPersonLinksAsync(int personId);
        Task AddInterestToPersonAsync(int personId, int interestId);
        Task<PersonDetailsDTO> GetDetailedPersonByIdAsync(int id);
        Task UpdatePersonNameAsync(int personId, string name);

    }
}

