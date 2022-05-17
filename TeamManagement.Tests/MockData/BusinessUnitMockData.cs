using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementService.Models;

namespace TeamManagement.Tests.MockData
{
    public class BusinessUnitMockData
    {
        public static ServiceResponse<IEnumerable<BusinessUnit>> GetAllBusinessUnits()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<BusinessUnit>>();

            serviceResponse.Success = true;

            serviceResponse.Data = new List<BusinessUnit>()
            {
                new BusinessUnit()
                {
                    BU_Id =1,
                    BU_Description = "Rocks BU",
                    BU_Name = "Rocks",
                    BU_Type = BusinessUnitType.UW

                },
                new BusinessUnit()
                {
                    BU_Id =2,
                    BU_Description = "Sales BU",
                    BU_Name = "Sales",
                    BU_Type = BusinessUnitType.UWS

                }
            };
            return serviceResponse;
        }

        public static BusinessUnit GetBusinesUnitForPost()
        {
            return new BusinessUnit()
            {
                BU_Name = "Test BU" + Guid.NewGuid(),
                BU_Description = "Unit testing BU",
                BU_Type = BusinessUnitType.UWS
            };
        }
    }
}
