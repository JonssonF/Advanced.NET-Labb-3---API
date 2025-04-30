using Labb3_API.Models;
using Labb3_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {

        private readonly ILinkRepository _linkRepository;

        public LinksController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        /*---------------------------------------------------------------------------*/
        [HttpGet("/Retrieve all Links in the DataBase", Name = "Get All Links")]
        public async Task<ActionResult<IEnumerable<Link>>> GetAll()
        {
            var links = await _linkRepository.GetAllAsync();

            return Ok(links);
        }
        /*---------------------------------------------------------------------------*/


    }
}
