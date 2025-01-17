using Projects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Aspire;
using Google.Protobuf.WellKnownTypes;
using Swashbuckle.AspNetCore;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var db = builder.AddPostgres("db").WithPgAdmin().WithDataVolume();

        var projectdb = db.AddDatabase("ProjectDb");

        builder.AddProject<Projects.Subutai_WebApi>("webapi").WithReference(projectdb);

        // builder.AddProject<Projects.Subutai_WebApi>("webapi").WithSwaggerUI();

        builder.Build().Run();
    }
}