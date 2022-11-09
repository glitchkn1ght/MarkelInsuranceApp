namespace MarkelInsuranceApp.Models.Response.Common
{
    public abstract class BaseResponse
    {
        public BaseResponse()
        {
            ResponseStatus = new ResponseStatus();
        }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
