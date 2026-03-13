namespace LibrarySystem.Core.Patterns.Strategy
{
    public interface IFineStrategy
    {
        decimal CalculateFine(int overdueDays);
        string StrategyName { get; } 
    }
}