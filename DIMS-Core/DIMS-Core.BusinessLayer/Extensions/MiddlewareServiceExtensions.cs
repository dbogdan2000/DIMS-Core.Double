using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Services;
using DIMS_Core.DataAccessLayer.Extensions;
using DIMS_Core.Identity.Extensions;
using DIMS_Core.Mailer.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DIMS_Core.BusinessLayer.Extensions
{
    public static class MiddlewareServiceExtensions
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserProfileService, UserProfileService>();
            services.AddTransient<IDirectionService, DirectionService>();
            services.AddTransient<IVUserProfileService, VUserProfileService>();

            services.AddDatabaseDependencies()
                    .AddIndentityDependencies()
                    .AddMailerDependencies();

            return services;
        }

        public static IServiceCollection AddAutomapperProfiles(this IServiceCollection services, params Assembly[] otherMapperAssemblies)
        {
            var assemblies = new List<Assembly>(otherMapperAssemblies)
                             {
                                 Assembly.GetExecutingAssembly()
                             };
            services.AddAutoMapper(assemblies);

            return services;
        }

        public static IServiceCollection AddCustomSolutionConfigs(
            this IServiceCollection services,
            IConfiguration configuration,
            params Assembly[] otherMapperAssemblies)
        {
            services.AddDependencyInjections()
                    .AddDatabaseContext(configuration)
                    .AddAutomapperProfiles(otherMapperAssemblies)
                    .AddIdentityContext();

            return services;
        }
    }
}