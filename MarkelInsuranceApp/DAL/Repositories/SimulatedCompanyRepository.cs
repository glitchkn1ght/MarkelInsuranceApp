namespace MarkelInsuranceApp.Repositories
{
    using MarkelInsuranceApp.CommonData;
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Models.Company;
    using System.Linq;
    using System.Threading.Tasks;

    public class SimulatedCompanyRepository : ICompanyRepository
    {
        CommonTestData data = new CommonTestData();

        public async Task<Company> Get(int companyId)
        {
            var result = this.data.Companies.FirstOrDefault(x => x.Id == companyId);

            return result;
        }
    }
}