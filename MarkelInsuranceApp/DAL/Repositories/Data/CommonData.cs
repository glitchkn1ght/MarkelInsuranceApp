namespace MarkelInsuranceApp.CommonData
{
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Company;
    using System;
    using System.Collections.Generic;

    public class CommonTestData
    {
        public List<Company> Companies = new List<Company>
        {
            new Company{Id = 101, Name="Universal Exports", Address1="10 Downing Street", Address2="Westminster",Address3="London",PostCode="E1 1ab",Country="England",Active=true, InsuranceEndDate=DateTime.Parse("31/12/2023")},
            new Company{Id = 101, Name="Aperture Science", Address1="0451 HL Road", Address2="Borealis",Address3="California",PostCode="90210",Country="USA",Active=true, InsuranceEndDate=DateTime.Parse("31/12/2024") },
            new Company{Id = 101, Name="Acme Corp", Address1="3 Diagon Alley", Address2="Muggleford",Address3="London",PostCode="E2 2RP",Country="England",Active=true, InsuranceEndDate=DateTime.Parse("31/12/2025")}
        };

        public List<InsuranceClaim> Claims = new List<InsuranceClaim>
        {
            new InsuranceClaim{UCR="JAM1234",CompanyId=101,ClaimDate=DateTime.Parse("02/01/2022"), LossDate=DateTime.Parse("01/01/2022"), AssuredName="JM113344", IncurredLoss=500M ,Closed=false},
            new InsuranceClaim{UCR="JAM5678",CompanyId=101,ClaimDate=DateTime.Parse("02/02/2022"), LossDate=DateTime.Parse("01/02/2022"), AssuredName="JM224455", IncurredLoss=125M ,Closed=true},
            new InsuranceClaim{UCR="JAM1138",CompanyId=101,ClaimDate=DateTime.Parse("02/03/2022"), LossDate=DateTime.Parse("01/03/2022"), AssuredName="JM335566", IncurredLoss=400M ,Closed=false},

            new InsuranceClaim{UCR="BAR1038",CompanyId=102,ClaimDate=DateTime.Parse("02/01/2021"), LossDate=DateTime.Parse("01/01/2021"), AssuredName="BR112233", IncurredLoss=50M ,Closed=true},
            new InsuranceClaim{UCR="BAR2069",CompanyId=102,ClaimDate=DateTime.Parse("02/02/2021"), LossDate=DateTime.Parse("01/02/2021"), AssuredName="BR223344", IncurredLoss=400M ,Closed=false},

            new InsuranceClaim{UCR="STARK1969",CompanyId=103,ClaimDate=DateTime.Parse("02/01/2021"), LossDate=DateTime.Parse("01/01/2021"), AssuredName="BR334455", IncurredLoss=100M ,Closed=false}
        };
    }
}
