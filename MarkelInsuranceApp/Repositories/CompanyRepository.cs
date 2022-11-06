using System;
using System.ComponentModel.Design;
using MarkelInsuranceApp.Models.Claim;
using MarkelInsuranceApp.Models.Company;

namespace MarkelInsuranceApp.Repositories
{
    public interface ICompanyRepository
    {
        public Company Get(int companyId);
    }

    public class CompanyRepository : ICompanyRepository
    {
        public Company Get(int companyId)
        {
            Company company = new Company
            {
                Id = companyId,
                Name = "Universal Exports",
                Address1 = "10 Downing Street",
                Address2 = "Westminister",
                Address3 = "London",
                Country = "England",
                PostCode = "EC2 123",
                Active = true,
                InsuranceEndDate = DateTime.Now
            };

            return company;
        }
    }
}
