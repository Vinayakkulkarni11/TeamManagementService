namespace TeamManagementService.Services.BusinessUnitService
{
    public class BusinessUnitService : IBusinessUnit
    {
        private DataContext _dataContext;

        public BusinessUnitService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ServiceResponse<BusinessUnit>> AddBusinessUnitAsync(BusinessUnit businessUnit)
        {            
            _dataContext.BusinessUnits.Add(businessUnit);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<BusinessUnit>()
            {
                Data = businessUnit,
                Message = "Business Unit added successfully"
            };
        }

        public async Task<ServiceResponse<BusinessUnitMember>> AttachBUMemberToBusinessUnitAsync(BusinessUnitMember businessUnitMember)
        {
            _dataContext.BusinessUnitMembers.Add(businessUnitMember);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<BusinessUnitMember>()
            {
               Data  = businessUnitMember,
               Message = "Member added to Business Unit"

            };
        }

        public async Task<ServiceResponse<IActionResult>> DetachBUMemberFromBusinessUnitAsync(int BUM_Id)
        {
            ServiceResponse<IActionResult> response = new ServiceResponse<IActionResult>();

            var buMember = await _dataContext.BusinessUnitMembers.FindAsync(BUM_Id);
            if (buMember == null)
            {
                response.Message = "Member doesn't exist";
                response.Success = false;   
                return response;
            }
            if(buMember.IsManager)
            {
                response.Message = "A Manager cannot be detached from a team";
                response.Success = false;
                return response;
            }

            _dataContext.BusinessUnitMembers.Remove(buMember);
            await _dataContext.SaveChangesAsync();
            
            response.Success = true;
            response.Message = "Member detached";
            return response;
        }

        public async Task<ServiceResponse<BusinessUnit>> UpdateBusinessUnitAsync(BusinessUnit businessUnit)
        {
            ServiceResponse<BusinessUnit> response = new ServiceResponse<BusinessUnit>();

            var BUtoUpdate = await _dataContext.BusinessUnits.FirstOrDefaultAsync(bu => bu.BU_Id == businessUnit.BU_Id);
            if (BUtoUpdate != null)
            {
                BUtoUpdate.BU_Description = businessUnit.BU_Description;
                BUtoUpdate.Active = businessUnit.Active;
                BUtoUpdate.BU_Name = businessUnit.BU_Name;
                BUtoUpdate.BU_Type = businessUnit.BU_Type;

                await _dataContext.SaveChangesAsync();

                response.Message = "Updated sucessfully";
                response.Data = BUtoUpdate;
            }
            else
            {
                response.Message = "Business Unit Not found";
                response.Success =false;
            }

            return response;
            
        }

        public async Task<ServiceResponse<BusinessUnitCategory>> AddBusinessUnitCategoryAsync(BusinessUnitCategory businessUnitCategory)
        {
           await _dataContext.BusinessUnitCategories.AddAsync(businessUnitCategory);
           await _dataContext.SaveChangesAsync();

            return new ServiceResponse<BusinessUnitCategory>()
            {
                Data = businessUnitCategory,
                Message = "Business Unit Category Added"
            };
        }

        public async Task<ServiceResponse<IEnumerable<BusinessUnit>>> GetAllBusinessUnitsAsync()
        {
            var units = await _dataContext.BusinessUnits.ToListAsync();
            return new ServiceResponse<IEnumerable<BusinessUnit>>()
            {
                Data = units,
            };
        }

        public async Task<ServiceResponse<IEnumerable<BusinessUnitMember>>> GetAllBusinessUnitMembersAsync()
        {
            var members = await _dataContext.BusinessUnitMembers.ToListAsync();
            return new ServiceResponse<IEnumerable<BusinessUnitMember>>()
            {
                Data = members
            };

        }

        public async Task<ServiceResponse<IEnumerable<BusinessUnitCategory>>> GetAllBusinessUnitCategoriesAsync()
        {
            var categories = await _dataContext.BusinessUnitCategories.ToListAsync();
            return new ServiceResponse<IEnumerable<BusinessUnitCategory>>()
            {
                Data = categories
            };
        }
    }
}
