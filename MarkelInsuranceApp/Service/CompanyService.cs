using MarkelInsuranceApp.Interfaces.Mappers;
using MarkelInsuranceApp.Interfaces.Repositories;
using MarkelInsuranceApp.Interfaces.Service;
using MarkelInsuranceApp.Mappers;
using MarkelInsuranceApp.Models.Company;
using MarkelInsuranceApp.Models.Response;
using MarkelInsuranceApp.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MarkelInsuranceApp.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ILogger<CompanyService> Logger;
        private readonly ICompanyRepository CompanyRepository;
        private readonly ICompanyResponseMapper CompanyResponseMapper;

        public CompanyService(ILogger<CompanyService> logger, ICompanyRepository companyRepository, ICompanyResponseMapper companyResponseMapper)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.CompanyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            this.CompanyResponseMapper = companyResponseMapper ?? throw new ArgumentNullException(nameof(companyResponseMapper));
        }

        public async Task<CompanyResponse> GetCompany(int CompanyId)
        {
            CompanyResponse companyResponse = new CompanyResponse();

            Company company = this.CompanyRepository.Get(CompanyId);

            if(company == null)
            {
                companyResponse.ResponseStatus.Code = -101;
                companyResponse.ResponseStatus.Message = "Could not find Company for this CompanyId";
            }

            else
            {
                companyResponse = this.CompanyResponseMapper.MapCompanyResponse(company);
            }

            return companyResponse;
        }
    }
}
