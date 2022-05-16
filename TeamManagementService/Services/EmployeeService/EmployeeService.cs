namespace TeamManagementService.Services.EmployeeService
{
    public class EmployeeService : IEmployee
    {
        private readonly DataContext _dataContext;
        public EmployeeService(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }

        public async Task<ServiceResponse<IEnumerable<Employee>>> SearchEmployeeAsync(string criteriaValue)
        {
            ServiceResponse<IEnumerable<Employee>> response = new ServiceResponse<IEnumerable<Employee>>();

            var employees = await _dataContext.Employees
                            .Where(e => e.FirstName.Contains(criteriaValue)
                            || e.LastName.Contains(criteriaValue)
                            || e.EmailAddress.Contains(criteriaValue)).ToListAsync();

            if (employees == null)
            {
                response.Success = false;
                response.Message = "Employee Not Found";
                return response;
            }

            response.Data = employees;
            return response;

        }

        public async Task<ServiceResponse<IEnumerable<Employee>>> GetEmployeeByEmailAsync(string email)
        {
            ServiceResponse<IEnumerable<Employee>> response = new ServiceResponse<IEnumerable<Employee>>();

            var employees = await _dataContext.Employees
                            .Where(e => e.EmailAddress.Contains(email)).ToListAsync();
                                                        
            if (employees == null)
            {
                response.Success = false;
                response.Message = "Employee Not Found";
                return response;
            }

            response.Data = employees;
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Employee>>> GetEmployeeByNameAsync(string name)
        {
            ServiceResponse<IEnumerable<Employee>> response = new ServiceResponse<IEnumerable<Employee>>();

            var employees = await _dataContext.Employees
                            .Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name)).ToListAsync();
                            

            if (employees == null)
            {
                response.Success = false;
                response.Message = "Employee Not Found";
                return response;
            }

            response.Data = employees;
            return response;
        }
        
        public async Task<ServiceResponse<Employee>> AddEmployeeAsync(Employee employee)
        {
            await _dataContext.Employees.AddAsync(employee);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<Employee>()
            { 
                Data = employee,
                Message = "Employee added successfully"                
            };
        }
    }
}
