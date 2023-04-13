﻿using KGD.Application.Contracts;
using KGD.Domain.Entity;
using KGD.Infrastructure.Persistence;
using KGD.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KGD.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, string url)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddDbContextPool<DataContext>(options => options
                .UseSqlite(url));

            services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddEntityFrameworkStores<DataContext>()
           .AddDefaultTokenProviders();
        }
    }
}
