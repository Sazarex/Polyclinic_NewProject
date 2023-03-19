using Interfaces.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;
using Polyclinic.Database;
using Shed.CoreKit.WebApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebApiRedirect("api/account", new WebApiEndpoint<IAuthService>(new System.Uri("http://localhost:5001")));
app.UseAuthorization();

app.MapControllers();

app.Run();
