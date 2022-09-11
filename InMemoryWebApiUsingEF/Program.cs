using ApplianceAPI.Models;
using ElectroApiTest.Models;
using ElectroApiTest.Models.DataManager;
using ElectroApiTest.Models.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDataRepository, ApplianceManager>();

builder.Services.AddScoped<IDataVMRepository<ApplianceCustomerVM>, ApplianceStatusManager>();

builder.Services.AddControllers();

builder.Services.AddMemoryCache();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ElectroContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/ApplianceStatus", (IDataVMRepository<ApplianceCustomerVM> ApplianceStatusManager) =>
{
    return ApplianceStatusManager.GetAll();
});

app.MapPost("/ApplianceStatus", (IDataRepository _ApplianceManager) =>
{
    _ApplianceManager.Add();
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 

app.Run();

public partial class Program { }

