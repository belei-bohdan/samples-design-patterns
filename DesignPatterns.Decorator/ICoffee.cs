namespace DesignPatterns.Decorator
{
    public interface ICoffee
    {
        abstract string Name { get; }
        abstract int Amount { get; }

        string GetDescription();
        decimal GetCost();
        virtual void DisplayReceipt()
            => Console.WriteLine($"{GetDescription()}: {GetCost():$#.00}");
    }
}
