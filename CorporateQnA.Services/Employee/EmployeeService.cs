using CorporateQnA.Data.Models.Employee.Views;
using CorporateQnA.Infrastructure.DbContext;
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
            _db = db.GetConnection();
        }

        public EmployeeDetailsView GetEmployeeById(Guid id)
        {
            return _db.Get<EmployeeDetailsView>(id);
        }

        public IEnumerable<EmployeeDetailsView> GetAllEmployees()
        {
            return _db.GetAll<EmployeeDetailsView>();
        }
    }
}
