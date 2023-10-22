using ASP_DOTNET_CORE_WEB_API.Automapper;
using ASP_DOTNET_CORE_WEB_API.Data;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;
using ASP_DOTNET_CORE_WEB_API.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PlayerDBContext>(options=> {
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameConnectionString"));
});
builder.Services.AddScoped<IPLayerDataRepositories, PLayerDataRepository>();
builder.Services.AddScoped<IAccountDataRepositories, AccountDataRepositories>();
builder.Services.AddScoped<IPersonalDataRepositories, PersonalDataRepositories>();

builder.Services.AddAutoMapper(typeof(PlayerDataMapper));

var app = builder.Build();

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
