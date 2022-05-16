global using Microsoft.AspNetCore.Mvc;
global using TeamManagementService.Models;

namespace TeamManagementService.Services.BusinessUnitService
{
    public interface IBusinessUnit
    {
        Task<ServiceResponse<BusinessUnit>> AddBusinessUnitAsync(BusinessUnit businessUnit);

        Task<ServiceResponse<BusinessUnit>> UpdateBusinessUnitAsync(BusinessUnit businessUnit);

        Task<ServiceResponse<BusinessUnitMember>> AttachBUMemberToBusinessUnitAsync(BusinessUnitMember businessUnitMember);

        Task<ServiceResponse<IActionResult>> DetachBUMemberFromBusinessUnitAsync(int BUM_Id);
        Task<ServiceResponse<BusinessUnitCategory>> AddBusinessUnitCategoryAsync(BusinessUnitCategory businessUnitCategory);
        Task<ServiceResponse<IEnumerable<BusinessUnit>>> GetAllBusinessUnitsAsync();
        Task<ServiceResponse<IEnumerable<BusinessUnitMember>>> GetAllBusinessUnitMembersAsync();
        Task<ServiceResponse<IEnumerable<BusinessUnitCategory>>> GetAllBusinessUnitCategoriesAsync();




    }
}
