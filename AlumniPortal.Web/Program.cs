using AlumniPortal.Application.Contract;
using AlumniPortal.Application.Implementation;
using AlumniPortal.Application.Middleware;
using AlumniPortal.Application.Repositories;
using AlumniPortal.Domain.Auth;
using AlumniPortal.Infrastructure.DbContext;
using AlumniPortal.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
});
builder.Services.AddIdentity<ApplicationUser, Role>()
        .AddMongoDbStores<ApplicationUser, Role, Guid>(builder.Configuration
        .GetConnectionString("MongoDb"), builder.Configuration
        .GetConnectionString("AlumniDatabaseName"));
builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAlumniEventMongoDatabase, AlumniEventMongoDatabase>();
builder.Services.AddSingleton<IAlumniEventRepository, AlumniEventRepository>();
//builder.Services.AddTransient<IDateTimeService, DateTimeService>();
//builder.Services.AddTransient<IAccountService, AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CustomExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
