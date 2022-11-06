namespace MarkelInsuranceApp.Repositories
{
    using System;
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Models.Claim;

    public class ClaimsRespository : IClaimsRepository
    {
        public InsuranceClaim Get(string universalClaimsReference)
        {
            InsuranceClaim claim = new InsuranceClaim
            {
                UCR = universalClaimsReference,
                CompanyId = 101,
                ClaimDate = DateTime.Parse("02/01/2022"),
                LossDate = DateTime.Parse("01/01/2022"),
                AssuredName = "Someone1231",
                IncurredLoss = 100.00M,
                Closed = false
            };

            return claim;
        }

        public void Update(InsuranceClaim updatedClaim)
        {

        }
    }
}
