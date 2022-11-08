using MarkelInsuranceApp.Mappers;
using MarkelInsuranceApp.Models.Claim;
using NUnit.Framework;

namespace MarkelInsuranceAppUnitTests.ControllerTests
{
    public class ClaimsResponseMapperTests
    {
        ClaimsResponseMapper ClaimsResponseMapper;
        InsuranceClaim claim;

        [SetUp]
        public void Setup()
        {
            this.ClaimsResponseMapper = new ClaimsResponseMapper();
            this.claim = new InsuranceClaim
            {



            };
        }

        //[TestCase(new InsuranceClaim())]
        //public void WhenInsuranceClaimFieldIsNull_ThenNoErrorThrown(InsuranceClaim claim)
        //{
           
            
            
        //    Assert.Pass();
        //}
    }
}