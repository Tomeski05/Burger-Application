using BurgerApp.DataAccess;
using BurgerApp.DataAccess.Repositories;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.BusinessLayer.Helpers
{
    public static class DomainModule
    {
        public static IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BurgerContext>(
                x => x.UseSqlServer(connectionString)
                );

            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Burger>, BurgerRepository>();
            services.AddTransient<IRepository<Feedback>, FeedbackRepository>();


            return services;
        }
    }
}
