using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeamManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly IBusinessUnit _businessUnitService;
        

        public BusinessUnitController(IBusinessUnit businessUnit)
        {
            _businessUnitService = businessUnit;
            
        }

        [HttpPost("BusinessUnit")]        
        public async Task<ActionResult<ServiceResponse<BusinessUnit>>> AddBusinessUnit(BusinessUnit businessUnit)
        {
            var response =  await _businessUnitService.AddBusinessUnitAsync(businessUnit);
            return Ok(response);            
        }

        [HttpPost("BusinessUnitMember")]        
        public async Task<ActionResult<ServiceResponse<BusinessUnitMember>>> AttachBusinessUnitMember(BusinessUnitMember businessUnitMember)
        {
            var response = await _businessUnitService.AttachBUMemberToBusinessUnitAsync(businessUnitMember);
            return Ok(response);
        }

        [HttpDelete("BusinessUnitMember")]
        public async Task<ActionResult<ServiceResponse<string>>> DetachBusinessUnitMember(int BUM_Id)
        {
            var response = await _businessUnitService.DetachBUMemberFromBusinessUnitAsync(BUM_Id);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut("BusinessUnit")]
        public async Task<ActionResult<ServiceResponse<BusinessUnit>>> UpdateBusinessUnit(BusinessUnit businessUnit)
        {
            var response = await _businessUnitService.UpdateBusinessUnitAsync(businessUnit);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("BusinessUnitCategory")]
        public async Task<ActionResult<ServiceResponse<BusinessUnit>>> AddBusinessUnitCategory(BusinessUnitCategory businessUnitCategory)
        {
            var response = await _businessUnitService.AddBusinessUnitCategoryAsync(businessUnitCategory);
            return Ok(response);
        }


        [HttpGet("GetAllBusinessUnits")]
        public async Task<ActionResult<ServiceResponse<BusinessUnit>>> GetAllBusinessUnits()
        {
            var response = await _businessUnitService.GetAllBusinessUnitsAsync();
            return Ok(response);
        }

        [HttpGet("GetAllBusinessUnitMembers")]
        public async Task<ActionResult<ServiceResponse<BusinessUnit>>> GetAllBusinessUnitMembers()
        {
            var response = await _businessUnitService.GetAllBusinessUnitMembersAsync();
            return Ok(response);
        }

        [HttpGet("GetAllBusinessUnitCategories")]
        public async Task<ActionResult<ServiceResponse<BusinessUnit>>> GetAllBusinessUnitCategories()
        {
            var response = await _businessUnitService.GetAllBusinessUnitCategoriesAsync();
            return Ok(response);
        }

    }
}