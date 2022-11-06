namespace MarkelInsuranceApp.Interfaces.Validation
{
    public interface IInputValidator<T>
    {
        public bool ValidateInput(T input);
    }
}
