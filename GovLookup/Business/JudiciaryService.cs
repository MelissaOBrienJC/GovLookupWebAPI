using GovLookup.Models;
using GovLookup.DataAccess.Repository;
using GovLookup.DataAccess;
using System.Data;
using AutoMapper;

namespace GovLookup.Business
{
    public class JudiciaryService : IJudiciaryService
    {

        public IGovLookupRepository _govLookupRepository { get; set; }
        public IMapper _mapper { get; set; }

        public JudiciaryService(IGovLookupRepository GovLookupRepository, IMapper Mapper)
        {
            _govLookupRepository = GovLookupRepository;
            _mapper = Mapper;
        }
   

        public async Task<IEnumerable<JudiciarySummaryDto>> GetJudiciary()
        {
            List<Judiciary> judiciarysFromDb;
            judiciarysFromDb = await _govLookupRepository.GetAllJudiciary();
            return 
                _mapper.Map<IEnumerable<JudiciarySummaryDto>>(judiciarysFromDb);
        }

        public async Task<JudiciaryDetailDto> GetJudiciaryById(string id)
        {
            var judiciaryFromDb = await _govLookupRepository.GetJudiciaryById(id);
            judiciaryFromDb = await AddJudiciaryData(judiciaryFromDb);
            if (judiciaryFromDb == null) return null;
            return _mapper.Map<JudiciaryDetailDto>(judiciaryFromDb);
        }


        private async Task<Judiciary> AddJudiciaryData(Judiciary judiciary)
        {
            if (judiciary == null) return judiciary;


            judiciary.KeyDecisions = await _govLookupRepository.GetJudiciaryKeyDecisions(judiciary.Id);
            if (judiciary.KeyDecisions != null)
            {
                foreach (KeyDecisions decision in judiciary.KeyDecisions)
                {
                    decision.RollCallDecision = await _govLookupRepository.GetJudiciaryRollCallDecision(decision.Docket);
                }
            }
            judiciary.KeyDecisionsOpinions = await _govLookupRepository.GetJudiciaryKeyDecisionsOpinions(judiciary.Id);

            return judiciary;
        }

    }
}
