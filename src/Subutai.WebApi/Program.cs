using Subutai.Domain.Ports;
using Subutai.Repository.SqlRepository.Contexts;
using Subutai.Repository.SqlRepository.Repositories;
using Subutai.Service;
using Microsoft.EntityFrameworkCore;



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

        // // PostgreSQL veritabanı bağlantısını yapılandırma
        // builder.Services.AddDbContext<SubutaiContext>(options =>
        // options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), x=> x.MigrationsAssembly("Subutai.Repository.SqlRepository")));   

        builder.Services.AddServiceDependencies();
        builder.Services.AddScoped<ISubutaiContext, SubutaiContext>();
        builder.Services.AddScoped<IProjectEntityRepository, ProjectEntityRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
