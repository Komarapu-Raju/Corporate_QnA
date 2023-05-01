using CorporateQnA.Data.Models.Employee;
using CorporateQnA.Data.Models.Employee.Views;
using CorporateQnA.DbContext;
using CorporateQnA.Services.Interfaces;
using Dapper.Contrib.Extensions;
using System.Data;

namespace CorporateQnA.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbConnection _db;

        public EmployeeService(ApplicationDbContext db)
        {
            this._db = db.GetConnection();
        }

        public EmployeeDetailsView GetEmployeeById(Guid id)
        {
            return this._db.Get<EmployeeDetailsView>(id);
        }

        public IEnumerable<EmployeeDetailsView> GetAllEmployees()
        {
            return this._db.GetAll<EmployeeDetailsView>();
        }

        public void AddEmployee(Employee newEmployee)
        {
            this._db.Insert(newEmployee);
        }
    }
}
