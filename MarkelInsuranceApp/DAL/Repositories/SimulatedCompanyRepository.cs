namespace MarkelInsuranceApp.Repositories
{
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Models.Company;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SimulatedCompanyRepository : ICompanyRepository
    {
        List<Company> companyDB = new List<Company>
        {

        };

        public async Task<Company> Get(int companyId)
        {
            var result = this.companyDB.FirstOrDefault(x => x.Id == companyId);

            return result;
        }
    }
}