namespace MarkelInsuranceApp.Models.Response
{
    using MarkelInsuranceApp.Models.Claim;
    using System;

    public class ClaimResponse : ResponseStatus 
    {
        public ClaimResponse()
        {
            this.ResponseStatus = new ResponseStatus();
        }
        public ResponseStatus ResponseStatus { get; set; }

        public string UniversalClaimsReference { get; set; }

        public int CompanyId { get; set; }

        public DateTime DateOfClaim { get; set; }

        public DateTime DateOfLoss { get; set; }

        public string AssuredName { get; set; }

        public decimal IncurredLossAmount { get; set; }

        public int ClaimAgeInDays { get; set; }

        public bool HasClaimBeenClosed { get; set; }
    }
}
