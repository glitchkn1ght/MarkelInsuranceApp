namespace MarkelInsuranceApp.Models.Response
{
    using System;

    public class ClaimResponse
    {
        public ClaimResponse()
        {
            this.ResponseStatus = new ResponseStatus();
        }
        public ResponseStatus ResponseStatus { get; set; }

        public string UniversalClaimsReference { get; set; }

        public int? CompanyId { get; set; } = null;

        public DateTime? DateOfClaim { get; set; } = null;

        public DateTime? DateOfLoss { get; set; } = null;

        public string AssuredName { get; set; }

        public decimal? IncurredLossAmount { get; set; } = null;

        public int? ClaimAgeInDays { get; set; } = null;

        public bool? HasClaimBeenClosed { get; set; } = null;
    }
}
