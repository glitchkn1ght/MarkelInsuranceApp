using MarkelInsuranceApp.Models.Common;
using System;

namespace MarkelInsuranceApp.Models.Response.Mapped
{
    public class MappedCompany
    {
        public MappedCompany()
        {
            CompanyAddress = new Address();
        }

        public int? CompanyId { get; set; } = null;

        public string CompanyName { get; set; }

        public Address CompanyAddress { get; set; }

        public bool? HasActiveInsurancePolicy { get; set; } = null;

        public DateTime? InsuranceEndDate { get; set; }
    }
}
