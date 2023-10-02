namespace DesignPatterns.Decorator
{
    internal abstract class CoffeeDecorator : ICoffee
    {
        protected readonly ICoffee _coffee;

        protected CoffeeDecorator(ICoffee coffee)
        {
            this._coffee = coffee;
        }

        public virtual string Name => this._coffee.Name;
        public int Amount => this._coffee.Amount;


        public virtual decimal GetCost()
        {
            return _coffee.GetCost();
        }

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }
    }
}
