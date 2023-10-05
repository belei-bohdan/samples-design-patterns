namespace DesignPatterns.FactoryMethod
{
    internal class MonobankFactory : CreditCardFactory
    {
        protected override ICreditCard Make()
        {
            return new Monobank();
        }
    }
}
