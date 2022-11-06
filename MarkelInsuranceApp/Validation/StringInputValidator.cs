namespace MarkelInsuranceApp.Validation
{
    using MarkelInsuranceApp.Controllers;
    using MarkelInsuranceApp.Interfaces.Validation;
    using Microsoft.Extensions.Logging;
    using System;

    public class StringInputValidator: IInputValidator<string>
    {
        private readonly ILogger<CompanyController> Logger;

        public StringInputValidator(ILogger<CompanyController> logger)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool ValidateInput(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                this.Logger.LogWarning("$[Operation=ValidateInput(StringInputValidator)], Status=Success, Message=Validation of string input failed.");
                
                return false;
            }

            return true;
        }
    }
}
