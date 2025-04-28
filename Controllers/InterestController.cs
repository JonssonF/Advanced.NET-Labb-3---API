using Labb3_API.Models;
using Labb3_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly IInterestRepository _interestRepository;

        public InterestController(IInterestRepository interestRepository)
        {
            _interestRepository = interestRepository;
        }

        /*---------------------------------------------------------------------------*/
        [HttpGet(Name = "Get All Interests")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetAllInterests()
        {
            var interests = await _interestRepository.GetAllInterestsAsync();

            return Ok(interests);
        }
        /*---------------------------------------------------------------------------*/

       
    }
}
