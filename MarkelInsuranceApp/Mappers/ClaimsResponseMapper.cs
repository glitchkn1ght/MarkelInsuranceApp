namespace MarkelInsuranceApp.Mappers
{
    using MarkelInsuranceApp.Interfaces.Mappers;
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response.Mapped;
    using System;

    public class ClaimsResponseMapper : IClaimsResponseMapper
    {
        public MappedClaim MapClaimResponse(InsuranceClaim insuranceClaim)
        {
            MappedClaim result = new MappedClaim();

            result.UniversalClaimsReference = insuranceClaim.UCR;
            result.CompanyId = insuranceClaim.CompanyId;
            result.DateOfClaim = (insuranceClaim.ClaimDate == default(DateTime) ? null : (DateTime?)insuranceClaim.ClaimDate);
            result.DateOfLoss = (insuranceClaim.LossDate == default(DateTime) ? null : (DateTime?)insuranceClaim.LossDate);
            result.AssuredName = insuranceClaim.AssuredName;
            result.IncurredLossAmount = insuranceClaim.IncurredLoss;
            result.HasClaimBeenClosed = insuranceClaim.Closed;

            if(!(insuranceClaim.ClaimDate == null || insuranceClaim.ClaimDate == default(DateTime)))
            {
                result.ClaimAgeInDays = (int)(DateTime.Now - (DateTime)insuranceClaim.ClaimDate).TotalDays;
            }

            else
            {
                result.ClaimAgeInDays = 0;
            }

            return result;
        }
    }
}
