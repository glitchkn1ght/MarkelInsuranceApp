namespace MarkelInsuranceApp.Interfaces.Mappers
{
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response;

    public interface IClaimsResponseMapper
    {
        public ClaimResponse MapClaimResponse(InsuranceClaim insuranceClaim);
    }
}
