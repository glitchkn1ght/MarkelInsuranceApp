namespace MarkelInsuranceApp.Interfaces.Service
{
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClaimsService
    {
        public Task<ClaimResponse> GetSingleClaimByUCR(string universalClaimsReference);

        public Task<List<InsuranceClaim>> GetClaimsForCompany(int CompanyId);

        public void UpdateClaim(InsuranceClaim claimToUpdate);
    }
}
