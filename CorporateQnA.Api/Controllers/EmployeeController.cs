using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Data.Models;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeServices;

        public EmployeeController(IEmployeeService employeeServices)
        {
            this._employeeServices = employeeServices;
        }

        [HttpGet("all")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IEnumerable<EmployeeListItem> GetAllEmployees()
        {
            return this._employeeServices.GetAllEmployees();
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public EmployeeListItem GetEmployeeById(Guid id)
        {
            return this._employeeServices.GetEmployeeById(id);
        }

        [HttpGet("location")]
        public IEnumerable<LocationDropdown> GetLocations()
        {
            return this._employeeServices.GetLocations();
        }

        [HttpGet("department")]
        public IEnumerable<Dropdown> GetDepartments()
        {
            return this._employeeServices.GetDepatments();
        }

        [HttpGet("designation")]
        public IEnumerable<Dropdown> GetDesignation()
        {
            return this._employeeServices.GetDesignations();
        }
    }
}
