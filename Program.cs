
using InfinionAPI.Data;
using InfinionAPI.Interface;
using InfinionAPI.Mapping;
using InfinionAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using User.Management.Service.Models;
using User.Management.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InfinionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("InfinionConnectionStrings"))); 
builder.Services.AddScoped<IUserInterface, UserService>();
//For Identification
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<InfinionDbContext>().AddDefaultTokenProviders();

//For Authentication


builder.Services.Configure<IdentityOptions>(opts => opts.SignIn.RequireConfirmedEmail = true);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});

var emailConfig= builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);



builder.Services.AddScoped<IEmailServices, EmailServices>();

builder.Services.AddAutoMapper(typeof(Mapper));
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
