using DigitalPoint.Application.Interfaces.Services;
using DigitalPoint.Domain.Entities;
using DigitalPoint.Identity.Services;
using DigitalPoint.Infra.Context;
using Microsoft.AspNetCore.Identity;
using DigitalPointBackEnd.Extensions;

namespace DigitalPointBackEnd.Ioc
{
    public static class NativeInjectorConfig {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddScoped<IIdentityService, IdentityService>();

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DigitalPointContext>()
                .AddDefaultTokenProviders();

            services.AddSwagger();
            services.AddAuthentication(configuration);

        }
    }
}
