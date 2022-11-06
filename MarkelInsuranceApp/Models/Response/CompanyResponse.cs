using MarkelInsuranceApp.Models.Common;
using System;

namespace MarkelInsuranceApp.Models.Response
{
    public class CompanyResponse : ResponseStatus
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public Address CompanyAddress { get; set; } 

        public bool HasActiveInsurancePolicy { get; set; }

        public string InsuranceEndDate { get; set; }
    }
}
