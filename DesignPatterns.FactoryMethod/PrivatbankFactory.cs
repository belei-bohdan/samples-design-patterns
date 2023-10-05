namespace DesignPatterns.FactoryMethod
{
    internal class PrivatbankFactory : CreditCardFactory
    {
        protected override ICreditCard Make()
        {
            return new Privatbank();
        }
    }
}
