namespace MarkelInsuranceApp.Repositories
{
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Models.Company;
    using System;

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
