namespace MarkelInsuranceApp.Service
{
    using MarkelInsuranceApp.Interfaces.Mappers;
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Interfaces.Service;
    using MarkelInsuranceApp.Models.Company;
    using MarkelInsuranceApp.Models.Response.Company;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

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

        public async Task<CompanyResponse> GetCompanyById(int CompanyId)
        {
            CompanyResponse companyResponse = new CompanyResponse();

            Company company = await this.CompanyRepository.Get(CompanyId);

            if(company == null)
            {
                companyResponse.ResponseStatus.Code = -101;
                companyResponse.ResponseStatus.Message = $"No matching rows found in database for companyId {CompanyId}.";
                this.Logger.LogWarning($"[Operation=GetCompanyById(CompanyService)], Status=Success, Message=No matching rows found in database for companyId {CompanyId}.");
            }

            else
            {
                this.Logger.LogInformation($"[Operation=GetCompanyById(CompanyService)], Status=Success, Message=Matching rows found in database for CompanyId {CompanyId}, mapping results.");
                companyResponse.Company = this.CompanyResponseMapper.MapCompanyResponse(company);
            }

            return companyResponse;
        }
    }
}
