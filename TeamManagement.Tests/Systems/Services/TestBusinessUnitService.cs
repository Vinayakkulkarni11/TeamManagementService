using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagement.Tests.MockData;
using TeamManagementService.Data;
using TeamManagementService.Services.BusinessUnitService;
using Xunit;

namespace TeamManagement.Tests.Systems.Services
{
    public class TestBusinessUnitService : IDisposable
    {
        private readonly DataContext _dataContext;
        public TestBusinessUnitService()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _dataContext = new DataContext(options);
            _dataContext.Database.EnsureCreated();

        }


        [Fact]
        public async Task GetAllBusinessUnitMembers_ShouldAddBusinessUnit()
        {

            ///Arrange
            var sut = new BusinessUnitService(_dataContext);
            var buToAdd = BusinessUnitMockData.GetBusinesUnitForPost();


            ///Act
             await sut.AddBusinessUnitAsync(buToAdd);


            ///Assert
            Assert.True(buToAdd.BU_Id > 0);

        }


        public void Dispose()
        {
            _dataContext.Database.EnsureDeleted();
            _dataContext.Dispose();            
        }
    }
}
