using GovLookup.Models;
using GovLookup.DataAccess.Repository;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using AutoMapper;

namespace GovLookup.Business
{
    public class LegislatorService : ILegislatorService
    {

        public  IGovLookupRepository _govLookupRepository { get; set; }
        public IMapper _mapper { get; set; }
        public LegislatorService(IGovLookupRepository GovLookupRepository, IMapper Mapper)
        {
            _govLookupRepository  = GovLookupRepository;
            _mapper = Mapper;
        }

        
        private string _geocodeUrl = "https://geocoding.geo.census.gov/geocoder/locations/onelineaddress";

        #region legislatorFind
        public async Task<IEnumerable<LegislatorSummaryDto>> GetLegislators(string searchValue)
        {

            List<Legislator> legislatorsFromDb;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                legislatorsFromDb = await _govLookupRepository.GetAllLegislators();
            }
            else
            {
                legislatorsFromDb = await GetLegislatorsBySearchValue(searchValue);
            }
            return _mapper.Map<IEnumerable<LegislatorSummaryDto>>(legislatorsFromDb);

        }
        public async Task<LegislatorDetailDto> GetLegislatorById(string id)
        {
            var legislatorFromDb = await _govLookupRepository.GetLegislatorById(id);
            legislatorFromDb = await AddLegislatorData(legislatorFromDb);
            return _mapper.Map<LegislatorDetailDto>(legislatorFromDb);
        }


        // serach value could be a name, address or zipcode.
        public async Task<List<Legislator>> GetLegislatorsBySearchValue(string searchValue)
        {

            if (IsValidZip(ref searchValue))
            {
                return await _govLookupRepository.GetLegislatorsByZipcode(searchValue);
            }
            else
            {
                var legislatorsFromDb = await GetLegislatorsByAddress(searchValue);

                if (legislatorsFromDb != null)
                {
                    return legislatorsFromDb;
                }
                else
                {
                    return await _govLookupRepository.GetLegislatorsByName(searchValue);
                }
            }

        }

        private async Task<Legislator> AddLegislatorData(Legislator legislator)
        {
            if (legislator == null) return legislator;

            legislator.Ratings = await _govLookupRepository.GetLegislatorRatings(legislator.Id);
            legislator.KeyVotes = await _govLookupRepository.GetLegislatorKeyVotes(legislator.Id);
            legislator.Bills = await _govLookupRepository.GetLegislatorBills(legislator.Id);
            legislator.Committees = await _govLookupRepository.GetLegislatorCommittees(legislator.Id);
            legislator.IndustryFinance = await _govLookupRepository.GetLegislatorIndustryFinance(legislator.Id);
            var industryFinanceData = await _govLookupRepository.GetLegislatorIndustryFinance(legislator.Id);
            legislator.IndustryFinanceChart = MapToPieChart(industryFinanceData);
            legislator.IndustryFinanceChartOptions = GetIndustryFinanceChartOptions();
            return legislator;

        }
        #endregion
        #region legislatorAddress

        public async Task<List<Legislator>> GetLegislatorsByAddress(string searchValue)
        {

            AddressDetails ar = await GetAddressDetails(searchValue);
            if (ar != null)
            {
                if (ar.result.addressMatches.Count == 0) return null;
                AddressCorrdinates ac = GetAddressCoordinates(ar);
                if (ac != null)
                {
                    return await _govLookupRepository.GetLegislatorsByLngLat(ac.longitude, ac.latitude);
                }
            }
            return null;
        }



        public async Task<AddressDetails> GetAddressDetails(string searchValue)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri(_geocodeUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("?address=" + searchValue + "&benchmark=4&format=json").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    if (responseString.ToLower().Contains("unavailable")) return null;

                    AddressDetails data = JsonConvert.DeserializeObject<AddressDetails>(responseString);
                    return data;
                }
            }
            return null;
        }

        public AddressCorrdinates GetAddressCoordinates(AddressDetails ar)
        {
            AddressCorrdinates ac = new AddressCorrdinates();
            if (ar != null)
            {
                ac.latitude = ar.result.addressMatches[0].coordinates.y.ToString();
                ac.longitude = ar.result.addressMatches[0].coordinates.x.ToString();
                return ac;
            }
            return null;

        }

        private bool IsValidZip(ref string val)
        {
            bool isNumeric = false;

            if ((val.Length >= 5) && (val.Length <= 10))
            {
                string zip = val.Substring(0, 5);
                int n;
                isNumeric = int.TryParse(zip, out n);
                if (isNumeric) val = zip;

            }
            return isNumeric;
        }

        #endregion

        #region legislatorIndustry

        private PieChartOptions GetIndustryFinanceChartOptions()
        {
            var options = new PieChartOptions();
            options.title = new PieChartTitle();
            options.title.text = "Industry Finance";
            options.title.display = true;
            options.title.fontsize = 22;
            options.legend = new PieChartLegend();
            options.legend.position = "bottom";
            return options;

        }

        public PieChart MapToPieChart(List<IndustryFinance> listIndustryFinance)
        {
            var chart = new PieChart();
            chart.datasets = new List<PieChartDataset>();
            chart.labels = new List<string>();
            var pcd = new PieChartDataset();
            pcd.data = new List<int>();
            pcd.backgroundColor = new List<string>();
            pcd.hoverBackgroundColor = new List<string>();

            foreach (IndustryFinance detail in listIndustryFinance)
            {
                pcd.data.Add(detail.Total);
                pcd.backgroundColor.Add(detail.ChartColor);
                pcd.hoverBackgroundColor.Add(detail.HoverColor);
                chart.labels.Add(detail.IndustryName);
            }
            chart.datasets.Add(pcd);
            return chart;
        }

        #endregion


    }
}
