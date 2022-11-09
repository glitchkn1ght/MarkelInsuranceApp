namespace MarkelInsuranceApp.Repositories
{
    using MarkelInsuranceApp.CommonData;
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Models.Claim;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class SimulatedClaimsRespository : IClaimsRepository
    {
        CommonTestData data = new CommonTestData();

        public async Task<InsuranceClaim> Get(string universalClaimsReference)
        {
            var result =  this.data.Claims.FirstOrDefault(x => x.UCR == universalClaimsReference);

            return result;
        }

        public async Task<IEnumerable<InsuranceClaim>> GetAllByCompany(int companyId)
        {
            IEnumerable<InsuranceClaim> results = this.data.Claims.Where(x => x.CompanyId == companyId);

            return results;
        }

        public async Task<int> Update(InsuranceClaim claimToUpdate)
        {
            var result = from x in this.data.Claims where x.UCR == claimToUpdate.UCR select x;

            if(result.FirstOrDefault() != null)
            {
                result.First().CompanyId = claimToUpdate.CompanyId;
                result.First().ClaimDate = claimToUpdate.ClaimDate;
                result.First().LossDate = claimToUpdate.LossDate;
                result.First().AssuredName = claimToUpdate.AssuredName;
                result.First().IncurredLoss = claimToUpdate.IncurredLoss;
                result.First().Closed = claimToUpdate.Closed;

                return 0;
            }

            return -101;
        }
    }
}
