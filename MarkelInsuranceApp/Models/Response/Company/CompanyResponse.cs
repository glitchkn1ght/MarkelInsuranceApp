using MarkelInsuranceApp.Models.Response.Common;
using MarkelInsuranceApp.Models.Response.Mapped;

namespace MarkelInsuranceApp.Models.Response.Company
{
    public class CompanyResponse : BaseResponse
    {
        public CompanyResponse() : base()
        {
            Company = new MappedCompany();
        }

        public MappedCompany Company { get; set; }
    }
}
