namespace MarkelInsuranceApp.Interfaces.Service
{
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response.Claim;
    using System.Threading.Tasks;

    public interface IClaimsService
    {
        public Task<SingleClaimResponse> GetSingleClaimByUCR(string universalClaimsReference);

        public Task<MultiClaimResponse> GetAllClaimsForCompany(int CompanyId);

        public Task<ClaimUpdateResponse> UpdateClaim(InsuranceClaim claimToUpdate);
    }
}
