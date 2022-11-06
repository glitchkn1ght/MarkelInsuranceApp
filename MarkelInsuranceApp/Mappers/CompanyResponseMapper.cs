using MarkelInsuranceApp.Interfaces.Mappers;
using MarkelInsuranceApp.Models.Company;
using MarkelInsuranceApp.Models.Response;

namespace MarkelInsuranceApp.Mappers
{
    public class CompanyResponseMapper : ICompanyResponseMapper
    {
        public CompanyResponse MapCompanyResponse(Company company)
        {
            CompanyResponse mappedResponse = new CompanyResponse();

            mappedResponse.CompanyId = company.Id;
            mappedResponse.CompanyName = company.Name;
            mappedResponse.CompanyAddress.AddressLine1 = company.Address1;
            mappedResponse.CompanyAddress.AddressLine2 = company.Address2;
            mappedResponse.CompanyAddress.AddressLine3 = company.Address3;
            mappedResponse.CompanyAddress.PostCode = company.PostCode;
            mappedResponse.CompanyAddress.Country = company.Country;
            mappedResponse.HasActiveInsurancePolicy = company.Active;
            mappedResponse.InsuranceEndDate = company.InsuranceEndDate.ToString();
            
            return mappedResponse;
        }
    }
}
