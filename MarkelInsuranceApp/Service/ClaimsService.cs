using MarkelInsuranceApp.Controllers;
using MarkelInsuranceApp.Mappers;
using MarkelInsuranceApp.Models.Claim;
using MarkelInsuranceApp.Models.Company;
using MarkelInsuranceApp.Models.Response;
using MarkelInsuranceApp.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MarkelInsuranceApp.Service
{
    public interface IClaimsService
    {
        public Task<ClaimResponse> GetSingleClaimByUCR(string universalClaimsReference);

        public Task<List<InsuranceClaim>> GetClaimsForCompany(int CompanyId);
        
        public void UpdateClaim(InsuranceClaim claimToUpdate);
    }
    
    public class ClaimsService : IClaimsService
    {
        private readonly ILogger<ClaimsService> Logger;
        private readonly IClaimsRepository ClaimsRepository;
        private readonly IClaimsResponseMapper ClaimsMapper;


        public ClaimsService(ILogger<ClaimsService> logger, IClaimsRepository claimsRepository, IClaimsResponseMapper claimsMapper)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.ClaimsRepository = claimsRepository ?? throw new ArgumentNullException(nameof(claimsRepository));
            this.ClaimsMapper = claimsMapper ?? throw new ArgumentNullException(nameof(claimsMapper));
        }

        public async Task<ClaimResponse> GetSingleClaimByUCR(string universalClaimsReference)
        {
            ClaimResponse claimResponse = new ClaimResponse();

            InsuranceClaim insuranceClaim = this.ClaimsRepository.Get(universalClaimsReference);

            if (string.IsNullOrWhiteSpace(insuranceClaim.UCR))
            {
                claimResponse.Code = -101;
                claimResponse.Message = "Could not find Claim for this UCR";
            }
            else
            {
                claimResponse = this.ClaimsMapper.MapClaimResponse(insuranceClaim);
            }

            return claimResponse;
        }

        public async Task<List<InsuranceClaim>> GetClaimsForCompany(int CompanyId)
        {
            List<InsuranceClaim> claims = new List<InsuranceClaim>();

            return claims;
        }

        public void UpdateClaim(InsuranceClaim claimToUpdate)
        {
            this.ClaimsRepository.Update(claimToUpdate);
        }
    }
}
