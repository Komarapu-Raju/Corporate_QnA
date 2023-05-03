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

        public EmployeeController(IEmployeeService employeeServices)
        {
            this._employeeServices = employeeServices;
        }

        [HttpGet("all")]
        public IEnumerable<EmployeeListItem> GetAllEmployees()
        {
            return this._employeeServices.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public EmployeeListItem GetEmployeeById(Guid id)
        {
            return this._employeeServices.GetEmployeeById(id);
        }
    }
}
