using Projects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Aspire;
using Google.Protobuf.WellKnownTypes;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        // var postgres = builder.AddPostgres("postgres");
        // var postgresdb = postgres.AddDatabase("postgresdb");

        // builder.AddProject<Projects.Subutai_WebApi>("webapi").WithReference(postgresdb);

        var postgres = builder.AddPostgres("postgres")
                      .WithPgAdmin();

        var postgresdb = postgres.AddDatabase("postgresdb");

        var exampleProject = builder.AddProject<Projects.Subutai_WebApi>("webapi")
                            .WithReference(postgresdb);


        builder.Build().Run();
    }
}