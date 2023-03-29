﻿using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CorporateQnA.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbConnection _db;

        public EmployeeService(ApplicationDbContext db)
        {
            this._db = db.GetConnection();
        }
        public EmployeeListItem GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeListItem> GetEmployeeList()
        {
            throw new NotImplementedException();
        }
    }
}
