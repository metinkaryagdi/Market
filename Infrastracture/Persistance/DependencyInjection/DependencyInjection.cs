using Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            // DbContext'i ve UnitOfWork'ü ekliyoruz
            services.AddDbContext<MarketContext>(options =>
                options.UseSqlServer(connectionString));

            // UnitOfWork ve Repository'leri DI'ye ekleyelim
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
