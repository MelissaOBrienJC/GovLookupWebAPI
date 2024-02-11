using GovLookup.Models;
using GovLookup.Models;

namespace GovLookup.Business
{
    public interface ICabinetService
    {

        Task<IEnumerable<CabinetSummaryDto>> GetCabinet();
        Task<CabinetDetailDto> GetCabinetById(string id);
    }
}
