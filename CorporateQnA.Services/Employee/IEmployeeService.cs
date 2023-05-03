using CorporateQnA.Core.Models.Employees.ViewModels;

namespace CorporateQnA.Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeListItem GetEmployeeById(Guid id);

        IEnumerable<EmployeeListItem> GetAllEmployees();
    }
}
