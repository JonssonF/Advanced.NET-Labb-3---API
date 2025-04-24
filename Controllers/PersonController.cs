using Labb3_API.Models;
using Labb3_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        

        [HttpGet("Get All Personssss")]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            var persons = await _personRepository.GetAllAsync();
            return Ok(persons);
        }

    }
}
