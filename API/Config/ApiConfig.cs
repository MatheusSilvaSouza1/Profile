﻿using Infra;
using Microsoft.EntityFrameworkCore;

namespace API.Config
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WriteContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            services.AddCors();
        }
    }
}