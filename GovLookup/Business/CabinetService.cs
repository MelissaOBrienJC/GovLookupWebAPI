using GovLookup.Models;
using GovLookup.DataAccess.Repository;
using AutoMapper;

namespace GovLookup.Business
{
    public class CabinetService : ICabinetService
    {

        public IGovLookupRepository _govLookupRepository { get; set; }
        public IMapper _mapper { get; set; }

        public CabinetService(IGovLookupRepository GovLookupRepository, IMapper Mapper)
        {
            _govLookupRepository  = GovLookupRepository;
            _mapper = Mapper;
        }



        public async Task<IEnumerable<CabinetSummaryDto>> GetCabinet()
        {

            List<Cabinet> cabinetsFromDb;
            cabinetsFromDb = await _govLookupRepository.GetAllCabinet();
            if (cabinetsFromDb == null) return null;
            return _mapper.Map<IEnumerable<CabinetSummaryDto>>(cabinetsFromDb);

        }
        public async Task<CabinetDetailDto> GetCabinetById(string id)
        {
            var cabinetFromDb = await _govLookupRepository.GetCabinetById(id);
            cabinetFromDb = await AddCabinetData(cabinetFromDb);
            if (cabinetFromDb == null) return null;
            return _mapper.Map<CabinetDetailDto>(cabinetFromDb);
        }

        private async Task<Cabinet> AddCabinetData(Cabinet cabinet)
        {
            if (cabinet == null) return cabinet;

            cabinet.Education = await _govLookupRepository.GetCabinetEducation(cabinet.Id);
            cabinet.JobHistory = await _govLookupRepository.GetCabinetJobHistory(cabinet.Id);
            return cabinet;

        }


    }
}
