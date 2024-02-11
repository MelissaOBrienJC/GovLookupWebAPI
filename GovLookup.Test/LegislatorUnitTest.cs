using AutoMapper;
using GovLookup.Business;
using GovLookup.Controllers;
using GovLookup.DataAccess;
using GovLookup.DataAccess.Repository;
using GovLookup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GovLookup.Mapping;

namespace GovLookup.Test
{

   
    public class LegislatorControllerTest
    {

        LegislatorController _controller;
        public LegislatorControllerTest()
        {

            GovLookupDBContext context;
            ILegislatorService service;
            IGovLookupRepository repository;

            IConfiguration configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            var _mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMappingProfile>();
            });

            var mapper = _mapConfig.CreateMapper();

            context = new GovLookupDBContext(configuration);
            repository = new GovLookupRepository(context);
            service = new LegislatorService(repository, mapper);
            _controller = new LegislatorController(null, service, mapper);
        }



        [Fact]
        public async Task GetLegislatorById()
        {

          
            //Arrange
            var valid_legislatorSearchValue = "S000033";
            var invalid_legislatorSearchValue = "1000";

            
            //Act
            var errorResult = await _controller.GetLegislator(invalid_legislatorSearchValue);
            var successResult = await _controller.GetLegislator(valid_legislatorSearchValue);
            var detail = (successResult as ObjectResult).Value as LegislatorDetailDto;

            //Assert
            Assert.IsType<OkObjectResult>(successResult);
            Assert.Equal("S000033", detail?.Id);
        }



        [Fact]
        public async Task GetLegislators()
        {

            //Act
            var valid_SearchValue = "Schumer";

            //Act
            IActionResult result = await _controller.GetLegislators(valid_SearchValue);
            var okObjectResult = result as OkObjectResult;           
            var legislators = okObjectResult?.Value as IEnumerable<LegislatorSummaryDto>;
            var legislator = legislators?.FirstOrDefault();

            //Assert
            Assert.Equal("S000148", legislator?.Id);
        }




    }
}