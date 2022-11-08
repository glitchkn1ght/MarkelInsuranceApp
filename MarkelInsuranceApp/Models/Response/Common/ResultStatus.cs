namespace MarkelInsuranceApp.Models.Response.Common
{
    public class ResponseStatus
    {
        public ResponseStatus()
        {
            Code = 0;
            Message = "Success";
        }

        public ResponseStatus(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
