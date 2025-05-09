﻿using Labb3_API.Models;
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
        private readonly ILinkRepository _linkRepository;

        public PersonController(IPersonRepository personRepository, ILinkRepository linkRepository)
        {
            _personRepository = personRepository;
            _linkRepository = linkRepository;

        }
        /*---------------------------------------------------------------------------*/
        [HttpGet("/Retrieve all Persons from database", Name = "Get All Persons")]
        public async Task<ActionResult<IEnumerable<PersonDetailsDTO>>> GetAll()
        {
            var persons = await _personRepository.GetAllAsync();
            
            return Ok(persons);
        }

        /*---------------------------------------------------------------------------*/
        [HttpGet("{id}/ Retrieve all information about a Person by ID", Name = "Get details by ID")]
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
        [HttpGet("{id}/Retrieve all Interests for a person by ID", Name = "Get Interest by person ID")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetPersonInterests(int id)
        {
            var interests = await _personRepository.GetPersonInterestsAsync(id);
            if (interests == null || !interests.Any())
            {
                return NotFound();
            }
            return Ok(interests);
        }

        /*---------------------------------------------------------------------------*/
        [HttpGet("{id}/Retrieves all links for a person by ID", Name = "Get Links by person ID")]
        public async Task<ActionResult<IEnumerable<Link>>> GetPersonLinks(int id)
        {
            var links = await _personRepository.GetPersonLinksAsync(id);
            if (links == null || !links.Any())
            {
                return NotFound();
            }
            return Ok(links);
        }

        /*---------------------------------------------------------------------------*/
        [HttpPost("{personId}/{interestId}/ Add interests", Name = "Add Interest to Person")]
        public async Task<IActionResult> AddInterestToPerson(int personId, int interestId)
        {
            await _personRepository.AddInterestToPersonAsync(personId, interestId);
            return NoContent();
        }

        /*---------------------------------------------------------------------------*/
        [HttpPost("{id}/{interestId}/Add Interest URL to Person", Name = "Add Link to Person & interest")]
        public async Task<IActionResult> AddLinkToPersonInterest(int id, int interestId, [FromBody] CreateLinkDTO dto)
        {
            try
            { 
                await _linkRepository.AddLinkAsync(id, interestId,dto.Url);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /*---------------------------------------------------------------------------*/
        [HttpPut("{id}/ Update name by ID", Name = "Update name of Person")]
        public async Task<IActionResult> UpdatePersonName(int id, [FromQuery] UpdateNameDTO dto)
        {
            try
            {
                await _personRepository.UpdatePersonNameAsync(id, dto.Name);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound($"{ex.Message}");
            }
        }
        /*---------------------------------------------------------------------------*/
        [HttpPost("Add a new Person", Name = "Add Person")]
        public async Task<IActionResult> AddPerson([FromBody]Person person)
        {
            await _personRepository.AddAsync(person);
            await _personRepository.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }
        /*---------------------------------------------------------------------------*/
    }
}
