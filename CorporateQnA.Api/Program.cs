using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Implementations;
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

var app = builder.Build();

//user3

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
