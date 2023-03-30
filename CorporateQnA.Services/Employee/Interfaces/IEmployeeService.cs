using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Data.Models.Employee.Views;

namespace CorporateQnA.Services.Interfaces
{
    public interface IEmployeeService
    {
        public IEnumerable<EmployeeDetailsView> GetAllEmployees();

        public EmployeeDetailsView GetEmployeeById(Guid id);
    }
}
