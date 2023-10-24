using ASP_DOTNET_CORE_WEB_API.Automapper;
using ASP_DOTNET_CORE_WEB_API.Data;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;
using ASP_DOTNET_CORE_WEB_API.Repositories.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PlayerDBContext>(options=> {
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameConnectionString"));
});

builder.Services.AddDbContext<GameAuthDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameAuthConnectionString"));
});
builder.Services.AddScoped<IPLayerDataRepositories, PLayerDataRepository>();
builder.Services.AddScoped<IAccountDataRepositories, AccountDataRepositories>();
builder.Services.AddScoped<IPersonalDataRepositories, PersonalDataRepositories>();

builder.Services.AddAutoMapper(typeof(PlayerDataMapper));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Gamedb")
    .AddEntityFrameworkStores<GameAuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = 
    new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
