using Entities.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace ApiBodas.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureEntityFramework(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConecction"));
            });
        }




    }
}
