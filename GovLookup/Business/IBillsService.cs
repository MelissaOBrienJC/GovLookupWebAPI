using GovLookup.Models;


namespace GovLookup.Business.Contract
{
    public interface IBillsService
    {
        Task<IEnumerable<CurrentBillsDto>> GetCurrentBills();
    }
}