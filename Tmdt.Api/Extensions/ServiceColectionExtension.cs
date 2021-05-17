using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Tmdt.Infrastructure.Identity.Data;
using Tmdt.Infrastructure.Identity.Entities;
using Tmdt.Infrastructure.Identity.Interfaces;
using Tmdt.Infrastructure.Identity.Services;
using Tmdt.Infrastructure.Persistence.Data;

namespace Tmdt.Api.Extensions
{
    public static class ServiceColectionExtension
    {
        public static void AddContextInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite(configuration.GetConnectionString("ApplicationDb")));

            services.AddDbContext<IdentityContext>(options => options.UseSqlite(configuration.GetConnectionString("IdentityDb")));
            services.AddIdentity<User, IdentityRole>(options =>
            {

            })
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JWTSettings:Issuer"],
                        ValidAudience = configuration["JWTSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                    };
                });
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
