using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopBridge.Controllers;
using ShopBridge.DTOs;
using ShopBridge.Interfaces;
using System.Threading.Tasks;

namespace ShopBridge.Test
{
    [TestClass]
    public class CountryGwpTest
    {
        [TestMethod]
        [DataRow(true)] //Happy flow
        [DataRow(false)] //return null from repo
        [DataRow(true,true)] //return nothing 
        public async Task FetchGwpDetails(bool isSavedAllSuccessed, bool returnNotFound = false)
        {
            //1. Arrange
            Mock<ICountryGwpRepository> mockRepository = new Mock<ICountryGwpRepository>();
            
            CountryGwpDto countryGwpDto = new CountryGwpDto
            {
                Country = "Ind",
                LOB = string.Empty,
                startYear = isSavedAllSuccessed ? 2008: 2010,
                endYear = 2015
            };

            CountryGwpToReturnDto countryGwpToReturnDto = null;
            if (!returnNotFound)
            {
                countryGwpToReturnDto = new CountryGwpToReturnDto
                {
                    liability = 634545022.9,
                    transport = 446001906.1
                };
            }

            mockRepository.Setup(x => x.FetchGwpDetails(It.IsAny<CountryGwpDto>())).Returns(() => countryGwpToReturnDto);

            CountryGwpController countryGwpController = new CountryGwpController(mockRepository.Object);

            //2. Act
            var actualObjResult = await countryGwpController.FetchGwpDetails(countryGwpDto);

            //3. Assert
            actualObjResult.Should().NotBeNull();

            int? status;
            if (actualObjResult as NotFoundResult != null || actualObjResult as BadRequestResult != null || actualObjResult as OkResult != null)
                status = ((StatusCodeResult)actualObjResult).StatusCode;
            else
                status = ((ObjectResult)actualObjResult).StatusCode;

            if (!isSavedAllSuccessed)
                Assert.IsTrue(status == 400);
            else if(returnNotFound)
                Assert.IsTrue(status == 404);
            else
                Assert.IsTrue(status == 200);
        }
    }
}
