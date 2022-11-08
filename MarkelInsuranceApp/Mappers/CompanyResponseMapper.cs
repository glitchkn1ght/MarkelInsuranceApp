namespace MarkelInsuranceApp.Mappers
{
    using MarkelInsuranceApp.Interfaces.Mappers;
    using MarkelInsuranceApp.Models.Company;
    using MarkelInsuranceApp.Models.Response;
    using MarkelInsuranceApp.Models.Response.Mapped;

    public class CompanyResponseMapper : ICompanyResponseMapper
    {
        public MappedCompany MapCompanyResponse(Company company)
        {
            MappedCompany result = new MappedCompany();

            result.CompanyId = company.Id;
            result.CompanyName = company.Name;
            result.CompanyAddress.AddressLine1 = company.Address1;
            result.CompanyAddress.AddressLine2 = company.Address2;
            result.CompanyAddress.AddressLine3 = company.Address3;
            result.CompanyAddress.PostCode = company.PostCode;
            result.CompanyAddress.Country = company.Country;
            result.HasActiveInsurancePolicy = company.Active;
            result.InsuranceEndDate = company.InsuranceEndDate;
            
            return result;
        }
    }
}
