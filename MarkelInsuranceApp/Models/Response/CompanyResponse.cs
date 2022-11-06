﻿using MarkelInsuranceApp.Models.Common;
using System;

namespace MarkelInsuranceApp.Models.Response
{
    public class CompanyResponse
    {
        public CompanyResponse()
        {
            CompanyAddress = new Address();
            ResponseStatus = new ResponseStatus();
        }
        public ResponseStatus ResponseStatus { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public Address CompanyAddress { get; set; } 

        public bool HasActiveInsurancePolicy { get; set; }

        public string InsuranceEndDate { get; set; }
    }
}
