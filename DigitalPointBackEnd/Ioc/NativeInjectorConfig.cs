using DigitalPoint.Identity.Services;
using DigitalPoint.Infra.Context;
using Microsoft.AspNetCore.Identity;
using DigitalPointBackEnd.Extensions;
using DigitalPoint.Application.Interfaces.Identity;
using DigitalPoint.Domain.Services;
using DigitalPoint.Application.Interfaces.WorkPoints.cs;
using DigitalPoint.Domain.Entities;

namespace DigitalPointBackEnd.Ioc
{
    public static class NativeInjectorConfig {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IWorkPointService, WorkPointsService>();

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DigitalPointContext>()
                .AddDefaultTokenProviders();

            services.AddSwagger();
            services.AddAuthentication(configuration);

        }
    }
}
