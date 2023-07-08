using AlumniPortal.Application;
using AlumniPortal.Application.Contract;
using AlumniPortal.Application.Implementation;
using AlumniPortal.Domain.Auth;
using AlumniPortal.Domain.Settings;
using AlumniPortal.Infrastructure.DbContext;
using Cqrs.Hosts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.FeatureManagement;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
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
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
});

builder.Services.AddSingleton<IApplicationDbContext, ApplicationDbContext>( service => 
new ApplicationDbContext(builder.Configuration.GetConnectionString("MongoDb"), builder.Configuration.GetConnectionString("AlumniDatabaseName")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDateTimeService, DateTimeService>();
builder.Services.AddTransient<IEmailService, MailService>();
builder.Services.AddSingleton<IFeatureManager, FeatureManager>();
builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<RoleManager<Role>>();
builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddSingleton<IImageConverterService, ImgurImageConverterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseMiddleware<CustomExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
