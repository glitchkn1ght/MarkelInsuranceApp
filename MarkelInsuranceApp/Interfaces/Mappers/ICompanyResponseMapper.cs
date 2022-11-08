namespace MarkelInsuranceApp.Interfaces.Mappers
{
    using MarkelInsuranceApp.Models.Company;
    using MarkelInsuranceApp.Models.Response.Mapped;

    public interface ICompanyResponseMapper
    {
        public MappedCompany MapCompanyResponse(Company company);
    }
}
