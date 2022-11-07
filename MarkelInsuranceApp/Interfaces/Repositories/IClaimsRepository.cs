namespace MarkelInsuranceApp.Interfaces.Repositories
{
    using MarkelInsuranceApp.Models.Claim;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClaimsRepository
    {
        public Task<InsuranceClaim> Get(string universalClaimsReference);

        public Task<IEnumerable<InsuranceClaim>> GetAllByCompany(int companyId);

        public Task<int> Update(InsuranceClaim claimToUpdate);
    }
}
