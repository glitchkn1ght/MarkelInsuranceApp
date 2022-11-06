using MarkelInsuranceApp.Models.Company;
using MarkelInsuranceApp.Models.Response;

namespace MarkelInsuranceApp.Interfaces.Mappers
{
    public interface ICompanyResponseMapper
    {
        public CompanyResponse MapCompanyResponse(Company company);
    }
}
