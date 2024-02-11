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
    public class CabinetControllerTest
    {
        
        CabinetController _controller;
      
        public CabinetControllerTest()
        {

            GovLookupDBContext context;
            ICabinetService service;
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
            service = new CabinetService(repository, mapper);           
            _controller = new CabinetController(null, service, mapper);

        }


        [Fact]
        public async void GetCabinetByid()
        {
            //Arrange
            var valid_cabinetSearchValue = "36";
            var invalid_cabinetSearchValue = "1000";
           
            //Act
            var errorResult = await _controller.GetCabinet(invalid_cabinetSearchValue);
            var successResult = await  _controller.GetCabinet(valid_cabinetSearchValue);
            var detail = (successResult as ObjectResult).Value as CabinetDetailDto;

            //Assert
            Assert.IsType<OkObjectResult>(successResult);
            Assert.IsType<NotFoundResult>(errorResult);
            Assert.Equal("36", detail?.Id);
        }



        [Fact]
        public async void GetCabinet()
        {

            //Act
            IActionResult result = await _controller.GetCabinet();           
            var okObjectResult = result as OkObjectResult;       
            var cabinet = okObjectResult?.Value as IEnumerable<CabinetSummaryDto>;
         
            //Assert           
            Assert.True(cabinet?.Count() > 3 ) ;
        }


       


       
    
    }
}