using SavingsDev.API.Enums;

namespace SavingsDev.API.Entities
{
    public class Operation
    {
        public Operation(decimal value, OperationType type)
        {
            Id = new Random().Next(1, 1000);
            Value = value;
            Type = type;
            OperationDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public decimal Value { get; private set; }
        public OperationType Type { get; private set; }
        public DateTime OperationDate { get; set; }
    }
}