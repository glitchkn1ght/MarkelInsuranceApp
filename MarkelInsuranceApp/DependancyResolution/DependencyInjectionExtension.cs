namespace MarkelInsuranceApp.DependancyResolution
{
    using MarkelInsuranceApp.Interfaces.Mappers;
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Interfaces.Service;
    using MarkelInsuranceApp.Mappers;
    using MarkelInsuranceApp.Repositories;
    using MarkelInsuranceApp.Service;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClaimsRepository, ClaimsRespository>();
            services.AddScoped<IClaimsResponseMapper, ClaimsResponseMapper>();
            services.AddScoped<IClaimsService, ClaimsService>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyResponseMapper, CompanyResponseMapper>();
            services.AddScoped<ICompanyService, CompanyService>();

            return services;
        }
    }
}
