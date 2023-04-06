using AuthorizationService;
using AuthorizationService.Options;
using DatabaseInfrastructure;
using Interfaces;
using Interfaces.ServiceLayers;
using Interfaces.ServiceLayersInterfaces;
using MediatorInfrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
//builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DefaultConnection"));
builder.Services.RegisterDatabaseInfrastructure(builder.Configuration);
builder.Services.RegisterMediatorInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
app.UseAuthorization();

app.MapControllers();
app.Run();
