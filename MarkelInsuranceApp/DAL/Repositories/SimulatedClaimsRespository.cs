namespace MarkelInsuranceApp.Repositories
{
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Models.Claim;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class SimulatedClaimsRespository : IClaimsRepository
    {
        List<InsuranceClaim> ClaimsDB = new List<InsuranceClaim>
        {
           
        };

        public async Task<InsuranceClaim> Get(string universalClaimsReference)
        {
            var result =  this.ClaimsDB.FirstOrDefault(x => x.UCR == universalClaimsReference);

            return result;
        }

        public async Task<IEnumerable<InsuranceClaim>> GetAllByCompany(int companyId)
        {
            IEnumerable<InsuranceClaim> results = this.ClaimsDB.Where(x => x.CompanyId == companyId);

            return results;
        }

        public async Task<int> Update(InsuranceClaim claimToUpdate)
        {
            var result = from x in this.ClaimsDB where x.UCR == claimToUpdate.UCR select x;

            if(result.FirstOrDefault() != null)
            {
                result.First().CompanyId = claimToUpdate.CompanyId;
                result.First().ClaimDate = claimToUpdate.ClaimDate;
                result.First().LossDate = claimToUpdate.LossDate;
                result.First().AssuredName = claimToUpdate.AssuredName;
                result.First().IncurredLoss = claimToUpdate.IncurredLoss;
                result.First().Closed = claimToUpdate.Closed;

                return 1;
            }

            return -101;
        }
    }
}
