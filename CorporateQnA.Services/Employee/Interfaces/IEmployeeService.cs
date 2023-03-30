using CorporateQnA.Core.Models.Employees.ViewModels;

namespace CorporateQnA.Services.Interfaces
{
    public interface IEmployeeService
    {
        public IEnumerable<EmployeeListItem> GetEmployeeList();

        public EmployeeListItem GetEmployeeById(Guid id);
    }
}
