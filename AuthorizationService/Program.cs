using AuthorizationService;
using AuthorizationService.Options;
using DatabaseInfrastructure;
using Interfaces;
using Interfaces.ServiceLayers;
using Interfaces.ServiceLayersInterfaces;
using MediatorInfrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

#region Наши сервисы
builder.Services.RegisterDatabaseInfrastructure(builder.Configuration);
builder.Services.RegisterMediatorInfrastructure();
builder.Services.RegisterConfigurationJWT(builder.Configuration); 
#endregion

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
app.UseAuthentication();


app.MapControllers();
app.Run();
