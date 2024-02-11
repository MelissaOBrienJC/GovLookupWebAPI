using GovLookup.Models;


namespace GovLookup.DataAccess.Repository
{
    public interface IGovLookupRepository
    {
        #region legislators

        Task<List<Legislator>> GetAllLegislators();
        Task<Legislator> GetLegislatorById(string id);
        Task<List<Legislator>> GetLegislatorsByName(string name);
        Task<List<Legislator>> GetLegislatorsByZipcode(string zipcode);
        Task<List<Legislator>> GetLegislatorsByLngLat(string lng, string lat);
        Task<List<KeyVote>> GetLegislatorKeyVotes(string id);
        Task<List<Rating>> GetLegislatorRatings(string id);
        Task<List<Bill>> GetLegislatorBills(string id);
        Task<List<IndustryFinance>> GetLegislatorIndustryFinance(string id);
        Task<List<Committee>> GetLegislatorCommittees(string id);
        #endregion

        #region cabinet
        Task<List<Cabinet>> GetAllCabinet();
        Task<Cabinet> GetCabinetById(string id);
        Task<List<JobPosition>> GetCabinetJobHistory(string id);
        Task<List<School>> GetCabinetEducation(string id);
        #endregion

        #region judiciary
        Task<List<Judiciary>> GetAllJudiciary();
        Task<Judiciary> GetJudiciaryById(string id);
        Task<List<KeyDecisions>> GetJudiciaryKeyDecisions(string id);
        Task<List<KeyDecisionsOpinions>> GetJudiciaryKeyDecisionsOpinions(string id);
        Task<List<RollCallDecision>> GetJudiciaryRollCallDecision(string docket);
        #endregion

        #region bills
        public Task<List<CurrentBills>> GetCurrentBills();
        #endregion
    }
}
