using AutoMapper;
using GovLookup.Business;
using GovLookup.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GovLookup.Controllers
{
    [ApiController]
    [Route("api/judiciary")]
    public class JudiciaryController : ControllerBase
    {


        private readonly ILogger<JudiciaryController> _logger;
        private readonly IJudiciaryService _judiciaryService;
        private readonly IMapper _mapper;
        public JudiciaryController(ILogger<JudiciaryController> logger, IJudiciaryService judiciaryService, IMapper mapper)
        {
            _logger = logger;
            _judiciaryService = judiciaryService;
            _mapper = mapper;
        }


        [HttpGet()]
        [EnableCors("GovLookupPolicy")]
        [Produces("application/json")]
        [ProducesResponseType<JudiciarySummaryDto>(StatusCodes.Status200OK)]
                
         
        public async Task<IActionResult> GetJudiciary()
        {
            return Ok(await _judiciaryService.GetJudiciary());
        }
        

        [HttpGet("{judiciaryId}")]
        [EnableCors("GovLookupPolicy")]
        [ProducesResponseType<JudiciaryDetailDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetJudiciary(string judiciaryId)
        {
            var judiciary = await _judiciaryService.GetJudiciaryById(judiciaryId);

            if (judiciary == null)
            {
                return NotFound();
            }
            return Ok(judiciary);
        }

    }
}
