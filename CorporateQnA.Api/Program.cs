using CorporateQnA.Core.Models.Profiles;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services;
using CorporateQnA.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ApplicationDbContext>();

builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddScoped<IAnswerService, AnswerService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<Category>();
    options.AddProfile<Question>();
    options.AddProfile<Answer>();
    options.AddProfile<Employee>();
});

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("AllowAllHeaders", options =>
    {
        options.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllHeaders");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
