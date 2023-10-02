namespace DesignPatterns.Decorator
{
    internal class Espresso : ICoffee
    {
        public string Name { get; }
        public int Amount { get; }

        public Espresso(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        public decimal GetCost()
        {
            return Amount * 10;
        }

        public string GetDescription()
        {
            return Name;
        }
    }
}