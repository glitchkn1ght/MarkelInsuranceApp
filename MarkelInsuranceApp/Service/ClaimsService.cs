namespace MarkelInsuranceApp.Service
{
    using MarkelInsuranceApp.Interfaces.Mappers;
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Interfaces.Service;
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task<ClaimResponse> GetSingleClaimByUCR(string uniqueClaimsReference)
        {
            ClaimResponse claimResponse = new ClaimResponse();

            InsuranceClaim insuranceClaim = await this.ClaimsRepository.Get(uniqueClaimsReference);

            if (insuranceClaim is null)
            {
                claimResponse.ResponseStatus.Code = -101;
                claimResponse.ResponseStatus.Message = $"No matching rows found in database for UCR {uniqueClaimsReference}.";
                this.Logger.LogWarning($"[Operation=GetSingleClaimByUCR(ClaimsService)], Status=Success, Message=No Matching rows found in database for UCR {uniqueClaimsReference}");
            }
            else
            {
                this.Logger.LogInformation($"[Operation=GetSingleClaimByUCR(ClaimsService)], Status=Success, Message=Matching rows found in database for UCR {uniqueClaimsReference}, mapping results.");
                claimResponse = this.ClaimsMapper.MapClaimResponse(insuranceClaim);
            }

            return claimResponse;
        }

        public async Task<List<InsuranceClaim>> GetClaimsForCompany(int companyId)
        {
            List<InsuranceClaim> claims = new List<InsuranceClaim>();

            claims = (await this.ClaimsRepository.GetAllByCompany(companyId)).ToList();

            if(claims.Count == 0)
            {

            }

            return claims;
        }

        public async Task<ClaimResponse> UpdateClaim(InsuranceClaim claimToUpdate)
        {
            ClaimResponse claimResponse = new ClaimResponse();

            int result = await this.ClaimsRepository.Update(claimToUpdate); 
            
            if (!(result == 0))
            {
                claimResponse.ResponseStatus.Code = -121;
                claimResponse.ResponseStatus.Message = $"No matching rows found to update in the database for UCR {claimToUpdate.UCR}";
                this.Logger.LogWarning($"[Operation=UpdateClaim(ClaimsService)], Status=Success, Message=No matching rows found to update in the database for UCR {claimToUpdate.UCR}");
            }

            return claimResponse;  
        }
    }
}
