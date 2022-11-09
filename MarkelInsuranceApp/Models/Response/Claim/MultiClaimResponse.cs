namespace MarkelInsuranceApp.Models.Response.Claim
{
    using System.Collections.Generic;
    using MarkelInsuranceApp.Models.Response.Common;
    using MarkelInsuranceApp.Models.Response.Mapped;

    public class MultiClaimResponse : BaseResponse
    {
        public MultiClaimResponse() : base()
        {
            Claims = new List<MappedClaim>();
        }

        public List<MappedClaim> Claims { get; set; }
    }
}
