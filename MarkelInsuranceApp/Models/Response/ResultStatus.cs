namespace MarkelInsuranceApp.Models.Response
{
    public class ResponseStatus
    {
        public ResponseStatus()
        {
            this.Code = 0;
            this.Message = "Success";
        }

        public ResponseStatus(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
