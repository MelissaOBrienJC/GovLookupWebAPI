using GovLookup.Models;

using System.Data;

namespace GovLookup.DataAccess.Repository
{
    public class GovLookupRepository: BaseRepository, IGovLookupRepository

    {
        private readonly GovLookupDBContext _dbContext;

        public GovLookupRepository(GovLookupDBContext context)
        {
            _dbContext = context;
        }

        #region legislators
        public async Task<List<Legislator>> GetAllLegislators()
        {

            var results = await _dbContext.ExecStoredProcedure<Legislator>("usp_GetLegislatorsAll", null);

            return results.ToList();
        }

        public async Task<Legislator> GetLegislatorById(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var result = await _dbContext.ExecStoredProcedure<Legislator>("usp_GetLegislatorById", inputParameters);

            return result.FirstOrDefault();
        }
        public async Task<List<Legislator>> GetLegislatorsByName(string name)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Name", name }

            };

            var results = await _dbContext.ExecStoredProcedure<Legislator>("usp_GetLegislatorsByName", inputParameters);

            return results.ToList();
        }
        public async Task<List<Legislator>> GetLegislatorsByZipcode(string zipcode)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Zipcode", zipcode }

            };

            var results = await _dbContext.ExecStoredProcedure<Legislator>("usp_GetLegislatorsByZipcode", inputParameters);

            return results.ToList();
        }
        public async Task<List<Legislator>> GetLegislatorsByLngLat(string lng, string lat)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Lng", lng },
                { "@Lat", lat }

            };

            var results = await _dbContext.ExecStoredProcedure<Legislator>("usp_GetLegislatorsByLngLat", inputParameters);

            return results.ToList();
        }

        public async Task<List<IndustryFinance>> GetLegislatorIndustryFinance(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = await _dbContext.ExecStoredProcedure<IndustryFinance>("usp_GetLegislatorIndustryFinance", inputParameters);

            return results.ToList();
        }

        public async Task<List<Rating>> GetLegislatorRatings(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = await _dbContext.ExecStoredProcedure<Rating>("usp_GetLegislatorRatings", inputParameters);

            return results.ToList();
        }
        public async Task<List<KeyVote>> GetLegislatorKeyVotes(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = await _dbContext.ExecStoredProcedure<KeyVote>("usp_GetLegislatorKeyVotes", inputParameters);

            return results.ToList();
        }

        public async Task<List<Bill>> GetLegislatorBills(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                    { "@Id", id}
             };

            var results = await _dbContext.ExecStoredProcedure<Bill>("usp_GetLegislatorBills", inputParameters);

            return results.ToList();
        }

        public async Task<List<Committee>> GetLegislatorCommittees(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                    { "@Id", id}
             };

            var results = await _dbContext.ExecStoredProcedure<Committee>("usp_GetLegislatorCommittees", inputParameters);

            return results.ToList();
        }

        #endregion

        #region cabinet

        public async Task<List<Cabinet>> GetAllCabinet()
        {

            var results = await _dbContext.ExecStoredProcedure<Cabinet>("usp_GetCabinetAll", null);

            return results.ToList();
        }


        public async Task<Cabinet> GetCabinetById(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var result = await _dbContext.ExecStoredProcedure<Cabinet>("usp_GetCabinetById", inputParameters);

            return result.FirstOrDefault();
        }



        public async Task<List<School>> GetCabinetEducation(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var results = await _dbContext.ExecStoredProcedure<School>("usp_GetCabinetEducation", inputParameters);

            return results.ToList();
        }

        public async Task<List<JobPosition>> GetCabinetJobHistory(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var results = await _dbContext.ExecStoredProcedure<JobPosition>("usp_GetCabinetJobHistory", inputParameters);

            return results.ToList();
        }

        #endregion

        #region judiciary

        public async Task<List<Judiciary>> GetAllJudiciary()
        {

            var results = await _dbContext.ExecStoredProcedure<Judiciary>("usp_GetJudiciaryAll", null);

            return results.ToList();
        }

        public async Task<Judiciary> GetJudiciaryById(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            var result = await _dbContext.ExecStoredProcedure<Judiciary>("usp_GetJudiciaryById", inputParameters);

            return result.FirstOrDefault();
        }




        public async Task<List<KeyDecisions>> GetJudiciaryKeyDecisions(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = await _dbContext.ExecStoredProcedure<KeyDecisions>("usp_GetJudiciaryKeyDecisions", inputParameters);

            return results.ToList();
        }
        public async Task<List<KeyDecisionsOpinions>> GetJudiciaryKeyDecisionsOpinions(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = await _dbContext.ExecStoredProcedure<KeyDecisionsOpinions>("usp_GetJudiciaryKeyDecisionsOpinions", inputParameters);

            return results.ToList();
        }


        public async Task<List<RollCallDecision>> GetJudiciaryRollCallDecision(string docket)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Docket", docket}

            };

            var results = await _dbContext.ExecStoredProcedure<RollCallDecision>("usp_GetJudiciaryRollCallDecision", inputParameters);

            return results.ToList();
        }

        #endregion

        #region bills

        public async Task<List<CurrentBills>> GetCurrentBills()
        {
            var results = await _dbContext.ExecStoredProcedure<CurrentBills>("usp_GetCurrentBills", null);

            return results.ToList();
        }

        #endregion




    }

}
