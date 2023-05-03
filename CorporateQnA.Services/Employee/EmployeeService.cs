using AutoMapper;
using CorporateQnA.Core.Models.Employees.ViewModels;
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

        public readonly IMapper _mapper;

        public EmployeeService(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db.GetConnection();
            this._mapper = mapper;
        }

        public EmployeeListItem GetEmployeeById(Guid id)
        {
            var employee = this._db.Get<EmployeeDetailsView>(id);
            return this._mapper.Map<EmployeeListItem>(employee);
        }

        public IEnumerable<EmployeeListItem> GetAllEmployees()
        {
            var employeeList = this._db.GetAll<EmployeeDetailsView>();
            return this._mapper.Map<IEnumerable<EmployeeListItem>>(employeeList);
        }
    }
}
