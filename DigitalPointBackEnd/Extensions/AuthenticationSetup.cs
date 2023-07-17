using DigitalPoint.Identity.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DigitalPointBackEnd.Extensions
{
    public static class AuthenticationSetup
    {
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            var JwtAppSettings = configuration.GetSection(nameof(JwtOptions));

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtOptions:SecurityKey").Value));

            //Requisitos de Token
            var tokenValidationParameters = new TokenValidationParameters { 
                ValidateIssuer = true,
                ValidIssuer = configuration.GetSection("JwtOption:Issuer").Value,
                ValidateAudience = true, 
                ValidAudience = configuration.GetSection("JwtOption:Audience").Value,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey
            };

            //Configuração de geração de Token
            services.Configure<JwtOptions>(options => {
                options.Issuer = JwtAppSettings[nameof(JwtOptions.Issuer)];
                options.Audience = JwtAppSettings[nameof(JwtOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            });

            //Requisitos de geração de senha senha
            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
            });

            //Adicionando autenticação
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {

                options.TokenValidationParameters = tokenValidationParameters;
            });
        }

    }
}
