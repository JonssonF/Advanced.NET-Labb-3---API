using Labb3_API.Models;
using Labb3_API.Models.DTOs;
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
        /*---------------------------------------------------------------------------*/
        [HttpGet("Get All Info From Persons")]
        public async Task<ActionResult<IEnumerable<PersonDetailsDTO>>> GetAll()
        {
            var persons = await _personRepository.GetAllAsync();
            return Ok(persons);
        }
        /*---------------------------------------------------------------------------*/
        [HttpGet("{id}")]
        [ActionName("Get details by ID")]
        public async Task<ActionResult<PersonDetailsDTO>> GetById(int id)
        {
            var personDto = await _personRepository.GetDetailedPersonByIdAsync(id);

            if (personDto == null)
            {
                return NotFound();
            }
            return Ok(personDto);
        }
        /*---------------------------------------------------------------------------*/
    }
}
