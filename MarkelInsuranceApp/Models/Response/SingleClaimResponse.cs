namespace MarkelInsuranceApp.Models.Response
{
    using System;
    using System.Collections.Generic;
    using MarkelInsuranceApp.Models.Response.Mapped;

    public class SingleClaimResponse
    {
        public SingleClaimResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.Claim = new MappedClaim();
        }
        public ResponseStatus ResponseStatus { get; set; }

        public MappedClaim Claim { get; set; }
    }
}
