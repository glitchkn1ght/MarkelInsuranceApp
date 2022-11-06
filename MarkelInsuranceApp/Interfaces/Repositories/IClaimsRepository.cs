using MarkelInsuranceApp.Models.Claim;

namespace MarkelInsuranceApp.Interfaces.Repositories
{
    public interface IClaimsRepository
    {
        public InsuranceClaim Get(string universalClaimsReference);

        public void Update(InsuranceClaim updatedClaim);
    }
}
