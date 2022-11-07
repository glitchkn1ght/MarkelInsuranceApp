﻿namespace MarkelInsuranceApp.Interfaces.Service
{
    using MarkelInsuranceApp.Models.Response;
    using System.Threading.Tasks;
    
    public interface ICompanyService
    {
        public Task<CompanyResponse> GetCompanyById(int CompanyId);
    }

}
