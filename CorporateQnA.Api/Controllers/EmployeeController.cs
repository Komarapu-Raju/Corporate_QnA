using AutoMapper;
using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeServices;

        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeServices, IMapper mapper)
        {
            this._employeeServices = employeeServices;
            this._mapper = mapper;
        }

        [HttpGet("all")]
        public IEnumerable<EmployeeListItem> GetAllEmployees()
        {
            var employeeList = this._employeeServices.GetAllEmployees();
            return this._mapper.Map<IEnumerable<EmployeeListItem>>(employeeList);
        }

        [HttpGet("{id}")]
        public EmployeeListItem GetEmployeeById(Guid id)
        {
            var employee = this._employeeServices.GetEmployeeById(id);
            return this._mapper.Map<EmployeeListItem>(employee);
        }
    }
}
