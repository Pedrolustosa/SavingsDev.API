using SavingsDev.API.Enums;

namespace SavingsDev.API.Models
{
    public class OperationInputModel
    {
        public decimal Value { get; set; }
        public OperationType Type { get; set; }
    }
}