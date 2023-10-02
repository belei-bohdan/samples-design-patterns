namespace DesignPatterns.Decorator
{
    internal sealed class MilkCoffee : CoffeeDecorator
    {
        public MilkCoffee(ICoffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " with milk";
        }

        public override decimal GetCost()
        {
            return base.GetCost() + 0.1M * base.Amount;
        }
    }
}
