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

        [HttpGet("{uniqueClaimsReference}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClaimResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseStatus))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseStatus))]
        public async Task<IActionResult> Get(string uniqueClaimsReference)
        {
            try 
            {
                ClaimResponse claimReponse = new ClaimResponse();

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

        
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClaimResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseStatus))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseStatus))]
        public async Task<IActionResult> Update([FromBody] InsuranceClaim claimToUpdate)
        {
            try
            {
                ClaimResponse claimReponse = new ClaimResponse();

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
