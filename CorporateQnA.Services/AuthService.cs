using AutoMapper;
using CorporateQnA.Core.Models;
using CorporateQnA.Data.Models.Employee;
using CorporateQnA.Data.Models.Employee.Views;
using CorporateQnA.DbContext;
using CorporateQnA.Services.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace CorporateQnA.Services
{
    public class AuthService : IAuthService
    {
        public readonly IDbConnection _db;

        public readonly UserManager<IdentityUser> _userManager;

        public readonly IEmployeeService _employeeService;

        public readonly ITokenService _tokenService;

        public readonly IMapper _mapper;

        public AuthService(ApplicationDbContext db ,UserManager<IdentityUser> userManager, IEmployeeService employeeService, IMapper mapper, ITokenService tokenService)
        {
            this._db = db.GetConnection();
            this._userManager = userManager;
            this._mapper = mapper;
            this._employeeService = employeeService;
            this._tokenService = tokenService;
        }

        public async Task<response> Login(LoginModel model)
        {
            var user = await this._userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new response() { Status= "failed", StatusMessage = "User not found"};
            }
            var checkPassword = await this._userManager.CheckPasswordAsync(user, model.Password);
            if (!checkPassword)
            {
                return new response() { Status = "failed", StatusMessage = "Credentials didn't match" };
            }

            Guid activeEmployeeId = await this._db.QueryFirstOrDefaultAsync<Guid>("Select id from Employee where userId = @userId", new { userId = user.Id });

            var token = this._tokenService.GenerateToken(user);
            return new response() { Status = "success", StatusMessage = "Login Successfull",Token = token, ActiveEmployeeId = activeEmployeeId };
        }

        public async Task<response> Register(RegisterModel model)
        {
            var user = await this._userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                return new response() { Status = "failed", StatusMessage = "User with emailId already exists" };
            }
            var newUser = new IdentityUser() { Email = model.Email, UserName = model.Email };
            var result = await this._userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                var newlyAddedUser = await this._userManager.FindByEmailAsync(model.Email);
                var newEmployee = this._mapper.Map<Employee>(model);

                newEmployee.UserId = Guid.Parse(newlyAddedUser.Id);

                this._employeeService.AddEmployee(newEmployee);

                return new response { Status = "success", StatusMessage = "Registration successfull", Token = token };
            }
            return new response() { Status = "failed", StatusMessage = "Registration failed" };
        }
    }
}
