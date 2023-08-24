using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Services;
using DigitalMenu.Core.Interfaces;
using DigitalMenu.Infrastructure.Persistence;
using DigitalMenu.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Services
            services.AddScoped<IServiceProduct, ServiceProduct>();

            //Repositories
            services.AddScoped<IRepositoryProduct, RepositoryProduct>();

            return services;
        }
    }
}
