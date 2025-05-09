﻿using Labb3_API.Data;
using Labb3_API.Models;
using Labb3_API.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Labb3_API.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        /*---------------------------------------------------------------------------*/

        public async Task<IEnumerable<Interest>> GetPersonInterestsAsync(int personId)
        {
            var person = await _context.Persons
                .Include(p => p.PersonInterests)
                    .ThenInclude(pi => pi.Interest)
                .FirstOrDefaultAsync(p => p.Id == personId);

            return person?.PersonInterests.Select(pi => pi.Interest) ?? new List<Interest>();
        }
        /*---------------------------------------------------------------------------*/

        public async Task<IEnumerable<Link>> GetPersonLinksAsync(int personId)
        {
            var person = await _context.Persons
                .Include(p => p.PersonInterests)
                    .ThenInclude(pi => pi.Links)
                .FirstOrDefaultAsync(p => p.Id == personId);
            if (person == null)
            {
                return Enumerable.Empty<Link>();
            }

            var links = person.PersonInterests
                .SelectMany(pi => pi.Links)
                .ToList();

            return links;
        }
        /*---------------------------------------------------------------------------*/
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
        /*---------------------------------------------------------------------------*/
        //Gets a body with persondetails, interest and related links.
        public async Task<PersonDetailsDTO> GetDetailedPersonByIdAsync(int id)
        {
            var person = await _context.Persons
                .Include(p => p.PersonInterests)
                    .ThenInclude(pi => pi.Interest)
                .Include(p => p.PersonInterests)
                    .ThenInclude(pi => pi.Links)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                return null;
            }
            var personDto = new PersonDetailsDTO
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                Interests = person.PersonInterests.Select(pi => new InterestDetailsDTO
                {
                    Title = pi.Interest.Title,
                    Description = pi.Interest.Description,
                    Links = pi.Links.Select(l => l.Url).ToList()
                }).ToList(),
            };
            return personDto;
        }
        /*---------------------------------------------------------------------------*/

        public async Task UpdatePersonNameAsync(int personId, string newName)
        {
            var person = await _context.Persons.FindAsync(personId);

            if (person == null) 
            {
                throw new Exception("Could not find a person with matching ID, try again");
            }

            person.Name =newName;

            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }
        /*---------------------------------------------------------------------------*/
    }
}
