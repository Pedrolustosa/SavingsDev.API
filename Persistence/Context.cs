using SavingsDev.API.Entities;

namespace SavingsDev.API.Persistence
{
    public class Context
    {
        public List<FinancialObjective> Objectives { get; set; }

        public Context()
        {
            Objectives = new List<FinancialObjective>();
        }
    }
}