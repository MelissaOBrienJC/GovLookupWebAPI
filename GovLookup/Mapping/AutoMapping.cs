using AutoMapper;
using GovLookup.Models;

namespace GovLookup.Mapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {

            #region legislators
            CreateMap<Legislator, LegislatorSummaryDto>();
            CreateMap<Legislator, LegislatorDetailDto>()
                 .ForMember(m => m.VoteStat, o => o.MapFrom(m => new VoteStatDto()
                 {
                     MissedVotesPct = m.MissedVotesPct,
                     VotesWithPartyPct = m.VotesWithPartyPct
                 }));
            CreateMap<Rating, RatingDto>();
            CreateMap<RollCallDecision, RollCallDecisionDto>();
            CreateMap<Bill, BillDto>();
            CreateMap<Committee, CommiteeDto>();
            CreateMap<IndustryFinance, IndustryFinanceDto>();
            CreateMap<KeyVote, KeyVoteDto>();
            #endregion

            #region cabinet
            CreateMap<Cabinet, CabinetSummaryDto>();
            CreateMap<Cabinet, CabinetDetailDto>();
            CreateMap<School, SchoolDto>();
            CreateMap<JobPosition, JobPositionDto>();
            #endregion

            #region judiciary
            CreateMap<Judiciary, JudiciarySummaryDto>();
            CreateMap<Judiciary, JudiciaryDetailDto>();
            CreateMap<KeyDecisions, KeyDecisionsDto>();
            CreateMap<KeyDecisionsOpinions, KeyDecisionsOpinionsDto>();
            #endregion

            #region bills
            CreateMap<CurrentBills, CurrentBillsDto>()
                   .ForMember(dest => dest.TimePeriod, opt => opt.MapFrom(src => src.time_period));
            #endregion
        }
    }
}
