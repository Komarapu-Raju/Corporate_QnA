using AutoMapper;
using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Data.Models.Employee.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateQnA.Core.Models.Profiles
{
    public class Employee : Profile
    {
        public Employee()
        {
            CreateMap<EmployeeDetailsView,EmployeeListItem>();
        }
    }
}
