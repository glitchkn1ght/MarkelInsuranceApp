namespace MarkelInsuranceApp.Interfaces.Repositories
{
    using MarkelInsuranceApp.Models.Company;
    using System.Threading.Tasks;

    public interface ICompanyRepository
    {
        public Task<Company> Get(int companyId);
    }
}
