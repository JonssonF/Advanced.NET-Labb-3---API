using Labb3_API.Models;
using Labb3_API.Models.DTOs;
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
        [HttpPost(Name = "Add a new Interest")]
        public async Task<ActionResult<Interest>> CreateInterest([FromQuery]Interest interest)
        {
            await _interestRepository.AddAsync(interest);
            await _interestRepository.SaveAsync();
            return CreatedAtAction(nameof(GetAllInterests), new { id = interest.Id }, interest);
        }
        /*---------------------------------------------------------------------------*/
    }
}
