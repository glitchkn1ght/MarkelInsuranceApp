namespace MarkelInsuranceApp.Controllers
{
    using MarkelInsuranceApp.Interfaces.Service;
    using MarkelInsuranceApp.Interfaces.Validation;
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response;
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
        private readonly IInputValidator<string> InputValidator;
        private readonly IClaimsService ClaimsService;
       
        public ClaimsController(ILogger<ClaimsController> logger, IInputValidator<string> inputValidator, IClaimsService claimsService)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.InputValidator = inputValidator ?? throw new ArgumentNullException(nameof(inputValidator));
            this.ClaimsService = claimsService ?? throw new ArgumentNullException(nameof(claimsService));
        }

        [HttpGet("GetSingleClaimByUCR/{uniqueClaimsReference}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleClaimResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(SingleClaimResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(SingleClaimResponse))]
        public async Task<IActionResult> GetSingleClaimByUCR(string uniqueClaimsReference)
        {
            try 
            {
                SingleClaimResponse claimReponse = new SingleClaimResponse();

                if (!this.InputValidator.ValidateInput(uniqueClaimsReference))
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

                return new ObjectResult(new ResponseStatus(500, "Internal Server Error")) { StatusCode = 500 };
            }
        }

        [HttpGet("GetAllClaimsByCompany/{companyId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MultiClaimResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MultiClaimResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MultiClaimResponse))]
        public async Task<IActionResult> GetAllClaimsByCompany(int companyId)
        {
            try
            {
                MultiClaimResponse multiClaimReponse = new MultiClaimResponse();

                multiClaimReponse = await this.ClaimsService.GetAllClaimsForCompany(companyId);

                return new OkObjectResult(multiClaimReponse);
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"[Operation=Get(Company)], Status=Failed, Message=Exeception thrown: {ex.Message}");

                return new ObjectResult(new ResponseStatus(500, "Internal Server Error")) { StatusCode = 500 };
            }
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleClaimResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(SingleClaimResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(SingleClaimResponse))]
        public async Task<IActionResult> Update([FromBody] InsuranceClaim claimToUpdate)
        {
            try
            {
                SingleClaimResponse claimReponse = new SingleClaimResponse();

                claimReponse = await this.ClaimsService.UpdateClaim(claimToUpdate);

                return new OkObjectResult(claimReponse.ResponseStatus);
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"[Operation=Get(Claims)], Status=Failed, Message=Exeception thrown: {ex.Message}");

                return new ObjectResult(new ResponseStatus(500, "Internal Server Error")) { StatusCode = 500 };
            }
        }
    }
}
