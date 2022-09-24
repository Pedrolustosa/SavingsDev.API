namespace SavingsDev.API.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base("Saldo insuficiente!") { }
    }
}