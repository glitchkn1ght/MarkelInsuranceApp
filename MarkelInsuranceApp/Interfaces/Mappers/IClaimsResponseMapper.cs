using MarkelInsuranceApp.Models.Claim;
using MarkelInsuranceApp.Models.Response;

namespace MarkelInsuranceApp.Interfaces.Mappers
{
    public interface IClaimsResponseMapper
    {
        public ClaimResponse MapClaimResponse(InsuranceClaim insuranceClaim);
    }
}
