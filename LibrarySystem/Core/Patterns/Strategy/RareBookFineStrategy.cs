using System;

namespace LibrarySystem.Core.Patterns.Strategy
{
    public class RareBookFineStrategy : IFineStrategy
    {
        public string StrategyName => "Rare";

        public decimal CalculateFine(int overdueDays)
        {
            return Math.Max(0, overdueDays * 50m); 
        }
    }
}