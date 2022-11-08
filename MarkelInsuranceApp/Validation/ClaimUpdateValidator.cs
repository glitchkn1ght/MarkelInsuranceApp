namespace MarkelInsuranceApp.Validation
{
    using MarkelInsuranceApp.Interfaces.Validation;
    using MarkelInsuranceApp.Models.Claim;
    using Microsoft.Extensions.Logging;
    using System;

    public class ClaimUpdateValidator : IInputValidator<InsuranceClaim>
    {
        private readonly ILogger<ClaimUpdateValidator> Logger;

        public ClaimUpdateValidator(ILogger<ClaimUpdateValidator> logger)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool ValidateInput(InsuranceClaim input)
        {
            string ValidationErrors ="";

            if (input.CompanyId == null)
            {
                ValidationErrors += "[CompanyId,]";
            }

            if (input.ClaimDate == default(DateTime))
            {
                ValidationErrors += "[ClaimDate,]";
            }

            if (input.ClaimDate == default(DateTime))
            {
                ValidationErrors += "[LossDate],";
            }

            if (string.IsNullOrWhiteSpace(input.AssuredName))
            {
                ValidationErrors += "[AssurredName],";
            }

            if (input.IncurredLoss < 0 || input.IncurredLoss == null)
            {
                ValidationErrors += "[AssurredName],";
            }

            if (input.Closed == null)
            {
                ValidationErrors += "[Closed]";
            }

            this.Logger.LogError($"[Operation=ValidateInput(ClaimUpdateValidator)], Status=Failure, Message=Validation of Insurance Claim failed, Failures={ValidationErrors}");

            if (string.IsNullOrWhiteSpace(ValidationErrors))
            {
                return true;
            }

            return false;
        }
    }
}
