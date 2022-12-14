using SavingsDev.API.Enums;
using SavingsDev.API.Exceptions;

namespace SavingsDev.API.Entities
{
    public class FinancialObjective
    {
        private const decimal YIELD = 0.03m;

        public FinancialObjective(string? title, string? description, decimal? valueObject)
        {
            Title = title;
            Description = description;
            ValueObject = valueObject;
            CreationDate = DateTime.Now;
            Operations = new List<Operation>();
        }

        public int Id { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public decimal? ValueObject { get; private set; }
        public DateTime CreationDate { get; private set; }

        public List<Operation> Operations { get; private set; }
        public decimal Balance => GetBalance();

        public void PerformOperation(Operation operation)
        {
            if (operation.Type == OperationType.Withdraw && Balance < operation.Value)
                throw new InsufficientFundsException();

            Operations.Add(operation);
        }

        public decimal GetBalance()
        {
            var totalDeposit = Operations.Where(o => o.Type == OperationType.Deposit).Sum(d => d.Value);
            var totalWithdraw = Operations.Where(o => o.Type == OperationType.Withdraw).Sum(s => s.Value);

            return totalDeposit - totalWithdraw;
        }

        public void Render()
        {
            var valueIncome = Balance * YIELD;

            Console.WriteLine($"Balance: {Balance}, Yield: {valueIncome}");

            var Withdraw = new Operation(valueIncome, OperationType.Deposit, Id);

            Operations.Add(Withdraw);
        }
    }
}