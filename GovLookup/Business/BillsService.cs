using GovLookup.Models;
using GovLookup.Business.Contract;
using AutoMapper;


using GovLookup.DataAccess.Repository;

namespace GovLookup.Business
{
    public class BillsService : IBillsService
    {

        public required IGovLookupRepository _govLookupRepository { get; set; }
        public IMapper _mapper { get; set; }


        public BillsService(IGovLookupRepository GovLookupRepository, IMapper Mapper)
        {
            _govLookupRepository = GovLookupRepository;
            _mapper = Mapper;
        }

        public async Task<IEnumerable<CurrentBillsDto>> GetCurrentBills()
        {

            List<CurrentBills> currentBillFromDb;
            currentBillFromDb = await _govLookupRepository.GetCurrentBills();
            return _mapper.Map<IEnumerable<CurrentBillsDto>>(currentBillFromDb);

        }
             
    }

}