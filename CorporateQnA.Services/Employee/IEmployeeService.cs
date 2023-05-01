using CorporateQnA.Data.Models.Employee.Views;
using CorporateQnA.Data.Models.Employee;

namespace CorporateQnA.Services.Interfaces
{
    public interface IEmployeeService
    {
        public EmployeeDetailsView GetEmployeeById(Guid id);

        public IEnumerable<EmployeeDetailsView> GetAllEmployees();

        public void AddEmployee(Employee newEmployee);
    }
}
