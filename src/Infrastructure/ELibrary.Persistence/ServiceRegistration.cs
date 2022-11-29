﻿using ELibrary.Application.Abstractions.EntityFramework;
using ELibrary.Persistence.Contexts.EntityFramework;
using ELibrary.Persistence.Services.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ELibrary.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-VAJ090L\\SQLEXPRESS;Initial Catalog=ELibraryDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddScoped<IEfService, EfService>();
            return services;
        }
    }
}