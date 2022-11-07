﻿namespace MarkelInsuranceApp.DependancyResolution
{
    using MarkelInsuranceApp.DAL.Polly.ConnectionFactory;
    using MarkelInsuranceApp.DAL.Polly.Policies;
    using MarkelInsuranceApp.Interfaces.Mappers;
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Interfaces.Service;
    using MarkelInsuranceApp.Interfaces.Validation;
    using MarkelInsuranceApp.Mappers;
    using MarkelInsuranceApp.Repositories;
    using MarkelInsuranceApp.Service;
    using MarkelInsuranceApp.Validation;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IInputValidator<string>, StringInputValidator>();

            services.AddTransient<IPollyRetryPolicy, PollyRetryPolicy>();
            services.AddTransient<IPollyConnectionFactory, PollySqlConnectionFactory>();

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
