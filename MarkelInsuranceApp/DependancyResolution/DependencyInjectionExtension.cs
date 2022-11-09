namespace MarkelInsuranceApp.DependancyResolution
{
    using MarkelInsuranceApp.DAL.Polly.ConnectionFactory;
    using MarkelInsuranceApp.DAL.Polly.Policies;
    using MarkelInsuranceApp.Interfaces.Mappers;
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Interfaces.Service;
    using MarkelInsuranceApp.Interfaces.Validation;
    using MarkelInsuranceApp.Mappers;
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Repositories;
    using MarkelInsuranceApp.Service;
    using MarkelInsuranceApp.Validation;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IInputValidator<string>, StringInputValidator>();
            services.AddScoped<IInputValidator<InsuranceClaim>, ClaimUpdateValidator>();

            services.AddTransient<IPollyRetryPolicy, PollyRetryPolicy>();
            services.AddTransient<IPollyConnectionFactory, PollySqlConnectionFactory>();


            //To Use Simulated Repos uncomment these lines
            services.AddScoped<IClaimsRepository, SimulatedClaimsRespository>();
           services.AddScoped<ICompanyRepository, SimulatedCompanyRepository>();

            //To Use Simulated Repos comment out these lines
            //services.AddScoped<IClaimsRepository, ClaimsRespository>();
            //services.AddScoped<ICompanyRepository, CompanyRepository>();


            services.AddScoped<IClaimsResponseMapper, ClaimsResponseMapper>();
            services.AddScoped<IClaimsService, ClaimsService>();

            services.AddScoped<ICompanyResponseMapper, CompanyResponseMapper>();
            services.AddScoped<ICompanyService, CompanyService>();

            return services;
        }
    }
}
