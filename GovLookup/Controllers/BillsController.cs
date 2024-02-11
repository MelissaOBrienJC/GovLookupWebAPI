using AutoMapper;
using GovLookup.Business;
using GovLookup.Business.Contract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GovLookup.Controllers
{
   
    [ApiController]
    [Route("api/Bills")]

    public class BillsController : ControllerBase
    {
        private readonly ILogger<CabinetController> _logger;
        private readonly IBillsService _billsService;
        private readonly IMapper _mapper;
        public BillsController(ILogger<CabinetController> logger, IBillsService billsService, IMapper mapper) {
            _logger = logger;
            _billsService = billsService;
            _mapper = mapper;
        }

        [HttpGet()]
        [EnableCors("GovLookupPolicy")]
        public async Task<IActionResult> GetCurrentBills()
        {
            var response = await _billsService.GetCurrentBills();

            if (response != null)
                return Ok(response);
            else
                return NotFound("Unable to find any current bills");


        }
    }
}
