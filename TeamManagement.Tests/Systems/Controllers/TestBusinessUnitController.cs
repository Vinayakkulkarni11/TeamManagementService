using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagement.Tests.MockData;
using TeamManagementService.Controllers;
using TeamManagementService.Services.BusinessUnitService;
using Xunit;

namespace TeamManagement.Tests.Systems.Controllers
{
    public class TestBusinessUnitController
    {       
        [Fact]
        public async Task GetAllBusinessUnitMembers_ShouldReturnTrueSuccess()
        {
            ///Arrange
            var businessUnitService = new Mock<IBusinessUnit>();
            businessUnitService.Setup(bu => bu.GetAllBusinessUnitsAsync()).ReturnsAsync(BusinessUnitMockData.GetAllBusinessUnits);
            var sut = new BusinessUnitController(businessUnitService.Object);

            ///Act
            var result = await sut.GetAllBusinessUnits();

            ///Assert
            result.Result.GetType().Should().Be(typeof(OkObjectResult));

        }

             
    }
}
