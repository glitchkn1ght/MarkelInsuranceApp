using MarkelInsuranceApp.Models.Company;
using System;
using System.Threading.Tasks;

namespace MarkelInsuranceApp.Service
{
    public interface ICompanyService
    {
        public Task<Company> GetCompany(int CompanyId);
    }


    public class CompanyService : ICompanyService
    {
        public async Task<Company> GetCompany(int CompanyId)
        {

        }
    }
}
