using AuthorizationService;
using DatabaseInfrastructure;
using MediatorInfrastructure;

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
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.Run();
