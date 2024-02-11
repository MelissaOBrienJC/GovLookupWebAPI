using AutoMapper;
using GovLookup.Business;
using GovLookup.Models;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace GovLookup.Controllers
{
    [ApiController]
    [Route("api/cabinet")]
    public class CabinetController : ControllerBase
    {

        private readonly ILogger<CabinetController> _logger;
        private readonly ICabinetService _cabinetService;
        private readonly IMapper _mapper;
        public CabinetController(ILogger<CabinetController> logger, ICabinetService cabinetService, IMapper mapper)
        {
            _logger = logger;
            _cabinetService = cabinetService;
            _mapper = mapper;
        }


        [HttpGet()]
        [EnableCors("GovLookupPolicy")]
        [Produces("application/json")]
        [ProducesResponseType<IEnumerable<CabinetSummaryDto>> (StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCabinet()
        {

            return Ok(await _cabinetService.GetCabinet());

        }

        [HttpGet("{cabinetId}")]
        [EnableCors("GovLookupPolicy")]
        [Produces("application/json")]
        [ProducesResponseType<CabinetDetailDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetCabinet(string cabinetId)
        {
            var cabinet = await _cabinetService.GetCabinetById(cabinetId);

            if (cabinet == null)
            {
                return NotFound();
            }
            return Ok(cabinet);
        }
    }
}
