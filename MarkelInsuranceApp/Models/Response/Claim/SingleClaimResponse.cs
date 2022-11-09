namespace MarkelInsuranceApp.Models.Response.Claim
{
    using MarkelInsuranceApp.Models.Response.Common;
    using MarkelInsuranceApp.Models.Response.Mapped;

    public class SingleClaimResponse : BaseResponse
    {
        public SingleClaimResponse() :base()
        {
            Claim = new MappedClaim();
        }

        public MappedClaim Claim { get; set; }
    }
}