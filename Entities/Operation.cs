using SavingsDev.API.Enums;

namespace SavingsDev.API.Entities
{
    public class Operation
    {
        public Operation(decimal value, OperationType type, int idObjective)
        {
            Value = value;
            Type = type;
            IdObjective = idObjective;
            OperationDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public decimal Value { get; private set; }
        public OperationType Type { get; private set; }
        public DateTime OperationDate { get; set; }
        public int IdObjective { get; set; }
    }
}