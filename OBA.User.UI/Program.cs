using BOA.User.Persistance.Repositories.AdminTools;
using BOA.User.Persistance.Repositories.Auth;
using BOA.User.Persistance.Repositories.User;
using BOA.User.Persistance.Repositories.UserResourcesManage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OBA.User.Core.Interfaces;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Core.Models;
using OBA.User.Core.Services;
using OBA.User.Infrastructure.Data.DbContexti;
using OBA.User.Presentation.ErrorAndLogRepos.Error;
using OBA.User.Presentation.ErrorAndLogRepos.LOg;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:5211", "https://localhost:7109")
            .AllowAnyHeader()
            .AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Guga's CRUD", Version = "v1" });

   
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "ავტორიზაცია",
        Description = "გთხოვთ შეიყვანოთ ტოკენი",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    };

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "გთხოვთ შეიყვანოთ ტოკენი",
        Name = "ავტორიზაცია",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme
        {
            Reference=new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        }, new List<string>() }
    });
});
builder.Services.AddScoped<IAuthService, AuthServices>();
builder.Services.AddScoped<IauthRepos, AuthRepos>();
builder.Services.AddScoped<IerrorRepos, ErrorRepos>();
builder.Services.AddScoped<IErrorservice, ErrorServices>();
builder.Services.AddScoped<ILogRepos, LoggerRepos>();
builder.Services.AddScoped<ILoggerServices, LoggerServices>();
builder.Services.AddScoped<IuserRepos, UserRepositorie>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IRegUserRepos, ManageResourcesRepos>();
builder.Services.AddScoped<IregUserServices, RegUserServices>();
builder.Services.AddScoped<IAdminRepos, AdminRepos>();
builder.Services.AddScoped<IAdminService, AdminServices>();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("GugasConnect"));
});

builder.Services.AddIdentity<Useri,Identityroleb>(io =>
{
    io.Password.RequiredLength = 5;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(ops =>
{
    ops.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    ops.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(ops =>
{
    ops.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:key").Value)),
    };
});
builder.Services.AddAuthorization(ops =>
{
    ops.AddPolicy("UserOnly", policy => policy.RequireRole("USER"));
});
builder.Services.AddAuthorization(ops =>
{
    ops.AddPolicy("AdminOnly", policy => policy.RequireRole("ADMIN"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
