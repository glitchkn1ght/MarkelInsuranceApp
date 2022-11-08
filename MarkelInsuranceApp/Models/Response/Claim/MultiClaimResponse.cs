namespace MarkelInsuranceApp.Models.Response.Claim
{
    using System.Collections.Generic;
    using MarkelInsuranceApp.Models.Response.Common;
    using MarkelInsuranceApp.Models.Response.Mapped;

    public class MultiClaimResponse
    {
        public MultiClaimResponse()
        {
            ResponseStatus = new ResponseStatus();
            Claims = new List<MappedClaim>();
        }
        public ResponseStatus ResponseStatus { get; set; }

        public List<MappedClaim> Claims { get; set; }
    }
}
