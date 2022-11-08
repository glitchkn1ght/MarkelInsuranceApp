namespace MarkelInsuranceApp.Interfaces.Service
{
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClaimsService
    {
        public Task<SingleClaimResponse> GetSingleClaimByUCR(string universalClaimsReference);

        public Task<MultiClaimResponse> GetAllClaimsForCompany(int CompanyId);

        public Task<SingleClaimResponse> UpdateClaim(InsuranceClaim claimToUpdate);
    }
}
