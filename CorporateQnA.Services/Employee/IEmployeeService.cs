using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Data.Models;
using CorporateQnA.Data.Models.Employee;

namespace CorporateQnA.Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeListItem GetEmployeeById(Guid id);

        IEnumerable<EmployeeListItem> GetAllEmployees();

        void AddEmployee(Employee newEmployee);

        IEnumerable<Dropdown> GetLocations();

        IEnumerable<Dropdown> GetDepatments();

        IEnumerable<Dropdown> GetDesignations();

    }
}
