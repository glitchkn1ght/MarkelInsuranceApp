using MarkelInsuranceApp.Models.Company;
using MarkelInsuranceApp.Models.Response;
using MarkelInsuranceApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MarkelInsuranceApp.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly ILogger<ClaimsController> Logger;
        private readonly IClaimsService ClaimsService;

        public ClaimsController(ILogger<ClaimsController> logger, IClaimsService claimsService)
        {
           this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
           this.ClaimsService = claimsService ?? throw new ArgumentNullException(nameof(claimsService));
        }

        [HttpGet("{UCR}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Company))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseStatus))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseStatus))]
        public async Task<IActionResult> Get(string universalClaimsReference)
        {
            try 
            {
                ClaimResponse claimReponse = new ClaimResponse();

                claimReponse = await this.ClaimsService.GetSingleClaimByUCR(universalClaimsReference);

                return new OkObjectResult(claimReponse);
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"[Operation=Get(Company)], Status=Failed, Message=Exeception thrown: {ex.Message}");

                return new ObjectResult(new ResponseStatus(500, "Internal Server Error")) { StatusCode = 500 };
            }
        }
    }
}
