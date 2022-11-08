namespace MarkelInsuranceApp.Models.Response
{
    using System.Collections.Generic;
    using MarkelInsuranceApp.Models.Response.Mapped;

    public class MultiClaimResponse
    {
        public MultiClaimResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.Claims = new List<MappedClaim>();
        }
        public ResponseStatus ResponseStatus { get; set; }

        public List<MappedClaim> Claims { get; set; }
    }
}
