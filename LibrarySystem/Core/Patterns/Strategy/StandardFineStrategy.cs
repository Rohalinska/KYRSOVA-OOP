using System;

namespace LibrarySystem.Core.Patterns.Strategy
{
    public class StandardFineStrategy : IFineStrategy
    {
        public string StrategyName => "Standard";

        public decimal CalculateFine(int overdueDays)
        {
            return Math.Max(0, overdueDays * 10m); 
        }
    }
}