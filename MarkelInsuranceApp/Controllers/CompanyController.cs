﻿namespace MarkelInsuranceApp.Controllers
{
    using MarkelInsuranceApp.Interfaces.Service;
    using MarkelInsuranceApp.Models.Response;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> Logger;
        private readonly ICompanyService CompanyService;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.CompanyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
        }

        [HttpGet("{companyId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CompanyResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CompanyResponse))]
        public async Task<IActionResult> Get(int companyId)
        {
            try 
            {
                CompanyResponse companyResponse = new CompanyResponse();

                this.Logger.LogInformation($"[Operation=Get(Company)], Status=Success, Message=Attempting to retrieve data for Company with id {companyId}");

                companyResponse = await this.CompanyService.GetCompanyById(companyId);
                
                return new OkObjectResult(companyResponse);
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"[Operation=Get(Company)], Status=Failed, Message=Exeception thrown: {ex.Message}");

                return new ObjectResult(new ResponseStatus(500, "Internal Server Error")) { StatusCode = 500 };
            }
        }
    }
}
