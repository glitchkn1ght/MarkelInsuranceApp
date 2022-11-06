using MarkelInsuranceApp.Models.Company;

namespace MarkelInsuranceApp.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        public Company Get(int companyId);
    }

}
