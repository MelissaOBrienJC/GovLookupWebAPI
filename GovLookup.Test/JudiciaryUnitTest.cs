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
    public class JudiciaryControllerTest
    {
        JudiciaryController _controller;



        public JudiciaryControllerTest()
        {
            GovLookupDBContext context;
            IJudiciaryService service;
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
            service = new JudiciaryService(repository, mapper);
            _controller = new JudiciaryController(null, service, mapper);


        }


        [Fact]
        public async void GetJudiciaryById()
        {
            //Arrange
            var valid_SearchValue = "6";
            var invalid_SearchValue = "1000";

            //Act
            var errorResult = await _controller.GetJudiciary(invalid_SearchValue);
            var successResult = await _controller.GetJudiciary(valid_SearchValue);
            var detail = (successResult as ObjectResult).Value as JudiciaryDetailDto;

            //Assert
            Assert.IsType<OkObjectResult>(successResult);
            Assert.IsType<NotFoundResult>(errorResult);
            Assert.Equal("6", detail?.Id);
        }



        [Fact]
        public async void GetJudiciary()
        {

            //Act
           
            IActionResult result = await _controller.GetJudiciary();
            var okObjectResult = result as OkObjectResult;
            var summary = okObjectResult?.Value as IEnumerable<JudiciarySummaryDto>;

            //Assert
            Assert.True(summary?.Count() > 3);
        }



    }
}