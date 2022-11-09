namespace MarkelInsuranceApp.Validation
{
    using MarkelInsuranceApp.Interfaces.Validation;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Text.RegularExpressions;

    public class StringInputValidator: IInputValidator<string>
    {
        private readonly ILogger<StringInputValidator> Logger;

        public StringInputValidator(ILogger<StringInputValidator> logger)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool ValidateInput(string input)
        {
            input = input.Trim().Replace(" ","");

            if (string.IsNullOrWhiteSpace(input) || input == "\"\"" || input == "\'\'")
            {
                this.Logger.LogWarning("[Operation=ValidateInput(StringInputValidator)], Status=Success, Message=Validation of string input failed.");
                
                return false;
            }

            return true;
        }
    }
}
