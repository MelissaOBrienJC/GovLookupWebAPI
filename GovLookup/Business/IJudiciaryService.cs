using GovLookup.Models;

namespace GovLookup.Business
{
    public interface IJudiciaryService
    {

        Task<IEnumerable<JudiciarySummaryDto>> GetJudiciary();
        Task<JudiciaryDetailDto> GetJudiciaryById(string id);
    }
}
