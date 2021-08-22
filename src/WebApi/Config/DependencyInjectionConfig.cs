using Business.Interfaces;
using Business.Services;
using Data.Context;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();            
                        
            services.AddScoped<IProdutoService, ProdutoService>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();

            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
