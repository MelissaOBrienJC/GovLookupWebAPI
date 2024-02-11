using GovLookup.Models;

namespace GovLookup.Business
{
    public interface ILegislatorService
    {

        Task<IEnumerable<LegislatorSummaryDto>> GetLegislators(string searchValue);
        Task<LegislatorDetailDto> GetLegislatorById(string id);
    }
}
