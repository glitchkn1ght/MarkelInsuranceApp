namespace MarkelInsuranceApp.Controllers
{
    using MarkelInsuranceApp.Interfaces.Service;
    using MarkelInsuranceApp.Interfaces.Validation;
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response.Claim;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly ILogger<ClaimsController> Logger;
        private readonly IInputValidator<string> StringInputValidator;
        private readonly IInputValidator<InsuranceClaim> ClaimsInputValidator;
        private readonly IClaimsService ClaimsService;
       
        public ClaimsController(    ILogger<ClaimsController> logger, 
                                    IInputValidator<string> stringInputValidator,
                                    IInputValidator<InsuranceClaim> claimsInputValidator,
                                    IClaimsService claimsService)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.StringInputValidator = stringInputValidator ?? throw new ArgumentNullException(nameof(stringInputValidator));
            this.ClaimsInputValidator = claimsInputValidator ?? throw new ArgumentNullException(nameof(claimsInputValidator));
            this.ClaimsService = claimsService ?? throw new ArgumentNullException(nameof(claimsService));
        }

        [HttpGet("GetSingleClaimByUCR/{uniqueClaimsReference}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleClaimResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(SingleClaimResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(SingleClaimResponse))]
        public async Task<IActionResult> GetSingleClaimByUCR(string uniqueClaimsReference)
        {
            SingleClaimResponse claimReponse = new SingleClaimResponse();

            try 
            {
                if (!this.StringInputValidator.ValidateInput(uniqueClaimsReference))
                {
                    claimReponse.ResponseStatus.Code = -102;
                    claimReponse.ResponseStatus.Message = "Validation of Unique Claims Reference failed, please check input.";

                    return new BadRequestObjectResult(claimReponse.ResponseStatus);
                }

                claimReponse = await this.ClaimsService.GetSingleClaimByUCR(uniqueClaimsReference);

                return new OkObjectResult(claimReponse);
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"[Operation=Get(Company)], Status=Failed, Message=Exeception thrown: {ex.Message}");

                claimReponse.ResponseStatus.Code = 500;
                claimReponse.ResponseStatus.Message = "Internal Server Error";

                return new ObjectResult(claimReponse) { StatusCode = 500 };
            }
        }

        [HttpGet("GetAllClaimsByCompany/{companyId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MultiClaimResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MultiClaimResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MultiClaimResponse))]
        public async Task<IActionResult> GetAllClaimsByCompany(int companyId)
        {
            MultiClaimResponse multiClaimReponse = new MultiClaimResponse();
            try
            {
                multiClaimReponse = await this.ClaimsService.GetAllClaimsForCompany(companyId);

                return new OkObjectResult(multiClaimReponse);
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"[Operation=Get(Company)], Status=Failed, Message=Exeception thrown: {ex.Message}");

                multiClaimReponse.ResponseStatus.Code = 500;
                multiClaimReponse.ResponseStatus.Message = "Internal Server Error";

                return new ObjectResult(multiClaimReponse) { StatusCode = 500 };
            }
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClaimUpdateResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ClaimUpdateResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ClaimUpdateResponse))]
        public async Task<IActionResult> Update([FromBody] InsuranceClaim claimToUpdate)
        {
            ClaimUpdateResponse claimUpdateResponse = new ClaimUpdateResponse();
            
            try
            {
                if (!this.ClaimsInputValidator.ValidateInput(claimToUpdate))
                {
                    claimUpdateResponse.ResponseStatus.Code = -121;
                    claimUpdateResponse.ResponseStatus.Message = "Validation of Insurance Claim failed, please check input.";

                    return new BadRequestObjectResult(claimUpdateResponse.ResponseStatus);
                }

                claimUpdateResponse = await this.ClaimsService.UpdateClaim(claimToUpdate);

                return new OkObjectResult(claimUpdateResponse.ResponseStatus);
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"[Operation=Get(Claims)], Status=Failed, Message=Exeception thrown: {ex.Message}");

                claimUpdateResponse.ResponseStatus.Code = 500;
                claimUpdateResponse.ResponseStatus.Message = "Internal Server Error";

                return new ObjectResult(claimUpdateResponse) { StatusCode = 500 };
            }
        }
    }
}
