using DigitalPoint.Identity.Services;
using DigitalPoint.Infra.Context;
using Microsoft.AspNetCore.Identity;
using DigitalPointBackEnd.Extensions;
using DigitalPoint.Application.Interfaces.Identity;
using DigitalPoint.Domain.Services;
using DigitalPoint.Application.Interfaces.WorkPoints;
using DigitalPoint.Domain.Entities;
using DigitalPoint.Application.Interfaces.BaseRepository;
using DigitalPoint.Infrastructure.Repositories;

namespace DigitalPointBackEnd.Ioc
{
    public static class NativeInjectorConfig {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IWorkPointRepository, WorkPointRepository>();
            services.AddScoped<IWorkPointService, WorkPointService>();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DigitalPointContext>()
                .AddDefaultTokenProviders();

            services.AddSwagger();
            services.AddAuthentication(configuration);

        }
    }
}
