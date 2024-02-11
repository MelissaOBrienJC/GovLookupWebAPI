using AutoMapper;
using GovLookup.Business;
using GovLookup.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GovLookup.Controllers
{
   
    [ApiController]
    [Route("api/legislators")]



    public class LegislatorController : ControllerBase
    {

        private readonly ILogger<LegislatorController> _logger;
        private readonly ILegislatorService _legislatorService;
        private readonly IMapper _mapper;
        public LegislatorController(ILogger<LegislatorController> logger, ILegislatorService legislatorService, IMapper mapper)
        {
            _logger = logger;
            _legislatorService = legislatorService;
            _mapper = mapper;
        }
       
        [HttpGet()]
        [EnableCors("GovLookupPolicy")]
        [Produces("application/json")]
        [ProducesResponseType<IEnumerable<LegislatorSummaryDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLegislators([FromQuery] string? searchValue)
        {
            if (searchValue == null )  searchValue = "";
            return Ok(await _legislatorService.GetLegislators(searchValue));

        }

        [HttpGet("{legislatorId}")]
        [EnableCors("GovLookupPolicy")]
        [Produces("application/json")]
        [ProducesResponseType<LegislatorDetailDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLegislator(string legislatorId)
        {
            var legislator = await _legislatorService.GetLegislatorById(legislatorId);

            if (legislator == null)
            {
                return NotFound();
            }
            return Ok(legislator);
        }


    }
}
