namespace MarkelInsuranceApp.Models.Response.Claim
{
    using MarkelInsuranceApp.Models.Response.Common;
    using MarkelInsuranceApp.Models.Response.Mapped;

    public class SingleClaimResponse
    {
        public SingleClaimResponse()
        {
            ResponseStatus = new ResponseStatus();
            Claim = new MappedClaim();
        }
        public ResponseStatus ResponseStatus { get; set; }

        public MappedClaim Claim { get; set; }
    }
}