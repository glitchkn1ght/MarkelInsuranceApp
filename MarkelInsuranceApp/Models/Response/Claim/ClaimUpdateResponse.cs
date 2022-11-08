namespace MarkelInsuranceApp.Models.Response.Claim
{
    using MarkelInsuranceApp.Models.Response.Common;

    public class ClaimUpdateResponse
    {
        public ClaimUpdateResponse()
        {
            ResponseStatus = new ResponseStatus();
        }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
