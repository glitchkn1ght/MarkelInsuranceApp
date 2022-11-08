using MarkelInsuranceApp.Models.Response.Mapped;

namespace MarkelInsuranceApp.Models.Response
{
    public class CompanyResponse
    {
        public CompanyResponse()
        {
            Company = new MappedCompany();
            ResponseStatus = new ResponseStatus();
        }
        public ResponseStatus ResponseStatus { get; set; }

        public MappedCompany Company { get; set; }
    }
}
