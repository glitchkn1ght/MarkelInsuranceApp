namespace MarkelInsuranceApp.Interfaces.Mappers
{
    using MarkelInsuranceApp.Models.Company;
    using MarkelInsuranceApp.Models.Response;

    public interface ICompanyResponseMapper
    {
        public CompanyResponse MapCompanyResponse(Company company);
    }
}
