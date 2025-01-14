using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Subutai.Domain.Ports;
using Subutai.Repository.SqlRepository.Repositories;

namespace Subutai.Service
{
    public static class ServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
                services.AddSingleton<IProjectEntityRepository, ProjectEntityRepository>();

                return services;
        }
    }
}