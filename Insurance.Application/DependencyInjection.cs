using Microsoft.Extensions.DependencyInjection;
using Insurance.Application.Services.ClaimTypeService;
using Insurance.Application.Services.CompanyService;
using Insurance.Application.Services.ClaimService;
using System.Reflection;

namespace Insurance.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IClaimTypeService, ClaimTypeService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IClaimService, ClaimService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
