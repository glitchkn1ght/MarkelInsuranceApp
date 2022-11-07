using MarkelInsuranceApp.Models.Claim;
using System.Threading.Tasks;

namespace MarkelInsuranceApp.Interfaces.Repositories
{
    public interface IClaimsRepository
    {
        public Task<InsuranceClaim> Get(string universalClaimsReference);

        public Task<int> Update(InsuranceClaim claimToUpdate);
    }
}
