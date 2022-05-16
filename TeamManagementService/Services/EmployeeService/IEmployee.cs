namespace TeamManagementService.Services.EmployeeService
{
    public interface IEmployee
    {
        Task<ServiceResponse<IEnumerable<Employee>>> SearchEmployeeAsync(string criteriaValue);
        Task<ServiceResponse<IEnumerable<Employee>>> GetEmployeeByNameAsync(string name);
        Task<ServiceResponse<IEnumerable<Employee>>> GetEmployeeByEmailAsync(string email);
        Task<ServiceResponse<Employee>> AddEmployeeAsync(Employee employee);
    }
}
