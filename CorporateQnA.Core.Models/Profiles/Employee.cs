using AutoMapper;
using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Data.Models.Employee.Views;

namespace CorporateQnA.Core.Models.Profiles
{
    public class Employee : Profile
    {
        public Employee()
        {
            CreateMap<EmployeeDetailsView, EmployeeListItem>().ReverseMap();

            CreateMap<RegisterModel, Data.Models.Employee.Employee>().ReverseMap();
        }
    }
}
