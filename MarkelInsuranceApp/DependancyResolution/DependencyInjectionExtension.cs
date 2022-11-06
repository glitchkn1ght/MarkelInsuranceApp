
namespace MarkelInsuranceApp.DependancyResolution
{
    using MarkelInsuranceApp.Service;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IClaimsService, ClaimsService>();
            return services;
        }
    }
}
