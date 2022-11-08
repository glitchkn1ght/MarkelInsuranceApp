namespace MarkelInsuranceApp.Interfaces.Mappers
{
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response.Mapped;

    public interface IClaimsResponseMapper
    {
        public MappedClaim MapClaimResponse(InsuranceClaim insuranceClaim);
    }
}
