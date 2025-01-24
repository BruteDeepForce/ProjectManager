using Subutai.Domain.Ports;
using Subutai.Repository.SqlRepository.Contexts;
using Subutai.Repository.SqlRepository.Repositories;
using Subutai.Service;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Aspire.Npgsql.EntityFrameworkCore.PostgreSQL;
using Subutai.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens; // TokenValidationParameters ve SymmetricSecurityKey için
using System.Text; 
using Blazored.LocalStorage;


namespace Subutai.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.AddServiceDefaults();

        
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();



        // // PostgreSQL Local veritabanı bağlantısını yapılandırma ayarları
        //builder.Services.AddDbContext<SubutaiContext>(options =>
        //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), x=> x.MigrationsAssembly("Subutai.Repository.SqlRepository")));   


        
        // builder.Services.AddDbContext<AuthenticationContext>(options =>                     // Add AuthenticationContext to the services container
        // options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        // x => x.MigrationsAssembly("Subutai.Repository.SqlRepository")));

        builder.AddNpgsqlDbContext<AuthenticationContext>("ProjectDb");
        builder.Services.AddIdentity<AuthEntity, AppRoleEntity>( options =>  // Add Identity to the services container
        {
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 2;
            options.Password.RequireNonAlphanumeric = false;

        }).AddEntityFrameworkStores<AuthenticationContext>().AddDefaultTokenProviders();
        
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
             options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
               options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!))
             };
        });

        builder.Services.AddAuthorization();

        builder.AddNpgsqlDbContext<SubutaiContext>("ProjectDb");
        //builder.Services.AddServiceDependencies();
        builder.Services.AddScoped<ISubutaiContext, SubutaiContext>();
        builder.Services.AddScoped<IProjectEntityRepository, ProjectEntityRepository>();
        builder.Services.AddScoped<IUserEntityRepository, UserEntityRepository>();
        builder.Services.AddScoped<IAuthEntityControl, AuthEntityControl>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
    
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
