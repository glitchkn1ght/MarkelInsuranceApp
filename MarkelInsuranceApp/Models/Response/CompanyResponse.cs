namespace MarkelInsuranceApp.Models.Response
{
    using MarkelInsuranceApp.Models.Common;

    public class CompanyResponse
    {
        public CompanyResponse()
        {
            CompanyAddress = new Address();
            ResponseStatus = new ResponseStatus();
        }
        public ResponseStatus ResponseStatus { get; set; }

        public int? CompanyId { get; set; } = null;

        public string CompanyName { get; set; }

        public Address CompanyAddress { get; set; }

        public bool? HasActiveInsurancePolicy { get; set; } = null;

        public string InsuranceEndDate { get; set; }
    }
}
