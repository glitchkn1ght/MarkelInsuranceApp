namespace MarkelInsuranceApp.Mappers
{
    using MarkelInsuranceApp.Interfaces.Mappers;
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response;
    using System;

    public class ClaimsResponseMapper : IClaimsResponseMapper
    {
        public ClaimResponse MapClaimResponse(InsuranceClaim insuranceClaim)
        {
            ClaimResponse result = new ClaimResponse();

            result.UniversalClaimsReference = insuranceClaim.UCR;
            result.CompanyId = insuranceClaim.CompanyId;
            result.DateOfClaim = insuranceClaim.ClaimDate;
            result.DateOfLoss = insuranceClaim.LossDate;
            result.AssuredName = insuranceClaim.AssuredName;
            result.IncurredLossAmount = insuranceClaim.IncurredLoss;
            result.HasClaimBeenClosed = insuranceClaim.Closed;
            result.ClaimAgeInDays = Convert.ToInt32((DateTime.Now - insuranceClaim.ClaimDate).TotalDays);

            return result;
        }
    }
}
